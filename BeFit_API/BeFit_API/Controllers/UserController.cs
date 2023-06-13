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
            var Userdb = await _dbContext.User.SingleOrDefaultAsync(x => x.Id == Userid);
            Userdb.LastUpdate = DateTime.Now;
            var today = DateTime.Today;
            UserOldMacros.Age = today.Year - userNewMacros.DateOfBirth.Year;
            UserOldMacros.Height = userNewMacros.Height;
            UserOldMacros.Weight = userNewMacros.Weight;
            UserOldMacros.Age = userNewMacros.Age;
            UserOldMacros.ActivityLevel = userNewMacros.ActivityLevel;
            UserOldMacros.Goal = userNewMacros.Goal;
            UserOldMacros.Disease = userNewMacros.Disease;
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
        [Route("api/check-last-update{checkedUserId}")]
        public async Task<IActionResult> CheckLastUpdate(Guid checkedUserId)
        {
            var now = DateTime.Now;
            var userdb = await _dbContext.User.FirstOrDefaultAsync(x => x.Id == checkedUserId);
            if (userdb == null)
            {
                return BadRequest("This user doesn't exist");
            }
            //To select update time :
            if (now.Subtract(userdb.LastUpdate).Days >= 30)
            {
                return BadRequest("This user need update");
            }else
            {
            return Ok("This user up-to-date");
            }

        }

        //sign up new user

        [HttpPost]
        [Route("api/add-user")]
        public async Task<IActionResult> AddUser([FromBody] CombineUser_UserMacros User_UserMacros)
        {

            var loggedUser = await _dbContext.User.FirstOrDefaultAsync(x => x.UserName == User_UserMacros.CombinedUser.UserName && x.IsActive == true);

            if (loggedUser != null)
            {
                return BadRequest("User Already Exists");
            }
            if (
                string.IsNullOrEmpty(User_UserMacros.CombinedUser.UserName)
                && string.IsNullOrEmpty(User_UserMacros.CombinedUser.Email)
                && string.IsNullOrEmpty(User_UserMacros.CombinedUser.Password)
                && string.IsNullOrEmpty(User_UserMacros.CombinedUserMacros.Goal)
                && User_UserMacros.CombinedUserMacros.Height <= 0
                && User_UserMacros.CombinedUserMacros.Weight <= 0
                && string.IsNullOrEmpty(User_UserMacros.CombinedUserMacros.Gender)
                && string.IsNullOrEmpty(User_UserMacros.CombinedUserMacros.ActivityLevel)
                )
            {
                return BadRequest("Data can not be empty");
            }

            User_UserMacros.CombinedUser.Id = Guid.NewGuid();
            User_UserMacros.CombinedUser.ProfileUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685433119/New_User_ProfilePic_jyinbz.png";
            User_UserMacros.CombinedUser.LastUpdate = DateTime.Now;
            var today = DateTime.Today;
            User_UserMacros.CombinedUserMacros.Age = today.Year - User_UserMacros.CombinedUserMacros.DateOfBirth.Year;
            User_UserMacros.CombinedUserMacros.UserId = User_UserMacros.CombinedUser.Id;
            User_UserMacros.CombinedUser.IsActive = true;
            User_UserMacros.CombinedUser.Role = "User";
            User_UserMacros.CombinedUserMacros.IsActive = true;
            User_UserMacros.CombinedUserMacros.Id = Guid.NewGuid();
            CalcMacros calc = new CalcMacros();
            calc.Calculate(User_UserMacros.CombinedUserMacros);

            await _dbContext.User.AddAsync(User_UserMacros.CombinedUser);
            await _dbContext.UserMacros.AddAsync(User_UserMacros.CombinedUserMacros);
            await _dbContext.SaveChangesAsync();
            return Ok(User_UserMacros.CombinedUser.Id);
        }
        [HttpGet]
        [Route("api/get-user-calories/{id}")]
        public async Task<IActionResult> GetUserMacros(Guid id)
        {
            var dailyMacros = await _dbContext.UserMacros.SingleOrDefaultAsync(x => x.UserId == id);
            if (dailyMacros == null)
                return BadRequest("this user doesnt have macros");
            var dailySelectedFood = await _dbContext.SelectedFood.Where(x => x.UserId == id && x.IsActive == true && x.TimeCreated.Day == DateTime.Now.Day).ToListAsync();
            UserMacrosDTO userMacrosDTO = new UserMacrosDTO
            {
                RemainingDailyCalories = dailyMacros.DailyCalories,
                RemainingDailyCarbs = dailyMacros.DailyCarbs,
                RemainingDailyFats = dailyMacros.DailyFats,
                RemainingDailyProtein = dailyMacros.DailyProtein
            };
            foreach (var dailyFood in dailySelectedFood)
            {
                userMacrosDTO.RemainingDailyCalories -= dailyFood.Calories;
                userMacrosDTO.RemainingDailyCarbs -= dailyFood.Carbs;
                userMacrosDTO.RemainingDailyFats -= dailyFood.Fats;
                userMacrosDTO.RemainingDailyProtein -= dailyFood.Protein;
            }
            return Ok(userMacrosDTO);
        }
    }
}
