using BeFit_API.Data;
using BeFit_API.Methods;
using BeFit_API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using BeFit_API.Methods;
using BeFit_API.CloudinarySettings;

namespace BeFit_API.Controllers
{
    public class UserController : Controller
    {
        private readonly WebsiteDbContext _dbContext;
        private readonly IPhoto _photo;
        public UserController(WebsiteDbContext dbContext, IPhoto photo)
        {
            _dbContext = dbContext;
            _photo = photo;
        }

        //show user data
        [HttpGet]
        [Route("api/get-user-data/{id}")]
        public async Task<ActionResult<User>> Get(Guid id)
        {
            var user = await _dbContext.User.FindAsync(id);
            if (user == null)
                return BadRequest("not found");
            return Ok(user);
        }

        //show user macro data
        [HttpGet]
        [Route("api/get-user-macros/{Userid}")]
        public async Task<ActionResult<UserMacros>> GetMacros(Guid Userid)
        {
            var userMacros = await _dbContext.UserMacros.SingleOrDefaultAsync(x => x.UserId == Userid);
            if (userMacros == null)
                return BadRequest("not found");
            return Ok(userMacros);
        }
        //Edit user macros data
        [HttpPut]
        [Route("api/edit-user-macros{Userid}")]
        public async Task<IActionResult> EditUserData(Guid Userid, [FromBody] UserMacros userNewMacros)
        {
            var UserOldMacros = await _dbContext.UserMacros.SingleOrDefaultAsync(x => x.UserId == Userid);

            UserOldMacros.Height = userNewMacros.Height;
            UserOldMacros.Weight = userNewMacros.Weight;
            UserOldMacros.Age = userNewMacros.Age;
            UserOldMacros.ActivityLevel = userNewMacros.ActivityLevel;
            UserOldMacros.Goal = userNewMacros.Goal;
            CalcMacros calc = new CalcMacros();
            calc.Calculate(UserOldMacros);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }


        //Edit user data
        [HttpPut]
        [Route("api/edit-user-data")]
        public async Task<IActionResult> EditUserData([FromForm] User newUser)
        {
            var UserOldData = await _dbContext.User.FindAsync(newUser.Id);
            string url = "";
            if (newUser.ProfilePhoto != null)
            {
                url = await _photo.UploadPhoto(newUser.ProfilePhoto);
                UserOldData.ProfileUrl = url;
            }
            UserOldData.UserName = newUser.UserName;
            UserOldData.Password = newUser.Password;
            UserOldData.Email = newUser.Email;

            await _dbContext.SaveChangesAsync();
            return Ok();
        }


        //login function

        [HttpPost]
        [Route("api/login-user")]
        public async Task<IActionResult> LoginUser([FromBody] User user)
        {
            var userdb = await _dbContext.User.FirstOrDefaultAsync(x => x.UserName == user.UserName && x.IsActive == true);
            if (userdb == null)
            {
                return BadRequest("username isn't correct");
            }
            if (user.Password != userdb.Password)
            {
                return BadRequest("wrong password");
            }
            return Ok(userdb.Id);
        }
        //check if user added his macros or not
        [HttpPost]
        [Route("api/check-usermacros{checkedUserId}")]
        public async Task<IActionResult> CheckUserMacros(Guid checkedUserId)
        {
            var userMacrosdb = await _dbContext.UserMacros.FirstOrDefaultAsync(x => x.UserId == checkedUserId);
            if (userMacrosdb == null)
            {
                return BadRequest("This user doesn't have Macros");
            }
            return Ok("This user have macros");
        }

        //sign up new user

        [HttpPost]
        [Route("api/add-user")]
        public async Task<IActionResult> AddUser([FromForm] User user)
        {

            var loggedUser = await _dbContext.User.FirstOrDefaultAsync(x => x.UserName == user.UserName && x.IsActive == true);
            string url = "";

            if (loggedUser != null)
            {
                return BadRequest("User Already Exists");
            }
            if (
                string.IsNullOrEmpty(user.UserName)
                && string.IsNullOrEmpty(user.Email)
                && string.IsNullOrEmpty(user.Password)
                )
            {
                return BadRequest("Data can not be empty");
            }
            if (user.ProfilePhoto != null)
            {
                 url = await _photo.UploadPhoto(user.ProfilePhoto);
            }
            user.ProfileUrl = url == "" ? null : url;
            user.Id = Guid.NewGuid();
            user.IsActive = true;
            user.Role = "User";
            await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return Ok(user.Id);
        }

        //add macros to user

        [HttpPost]
        [Route("api/add-user-macros")]
        public async Task<IActionResult> AddUserMacros ([FromBody] UserMacros userMacros)
        {
            if (
                string.IsNullOrEmpty(userMacros.Goal)
                && userMacros.UserId == Guid.Empty 
                && userMacros.Height <= 0 
                && userMacros.Weight <= 0 
                && userMacros.Age <= 0
                && string.IsNullOrEmpty(userMacros.Gender)
                && string.IsNullOrEmpty(userMacros.ActivityLevel)
                )
            {
                return BadRequest("Data can not be empty");
            }
            userMacros.IsActive = true;
            userMacros.Id= Guid.NewGuid();
            CalcMacros calc = new CalcMacros(); 
            calc.Calculate(userMacros);
            
            await _dbContext.UserMacros.AddAsync(userMacros);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
