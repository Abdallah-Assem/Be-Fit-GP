using BeFit_API.Data;
using BeFit_API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeFit_API.Controllers
{
    public class AdminController : Controller
    {
        private readonly WebsiteDbContext _dbContext;
        public AdminController(WebsiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        [Route("api/check-role{id}")]
        public async Task<IActionResult> CheckRole(Guid id)
        {
            var loggedPerson = await _dbContext.User.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true && x.Role == "Admin");
            if (loggedPerson == null)
            {
                return BadRequest("This is User.");
            }
            return Ok(loggedPerson.Id);
        }


        [HttpPost]
        [Route("api/add-admin")]
        public async Task<IActionResult> AddAdmin([FromBody] User user)
        {

            var loggedUser = await _dbContext.User.FirstOrDefaultAsync(x => x.UserName == user.UserName && x.IsActive == true);

            if (loggedUser != null)
            {
                return BadRequest("Admin Already Exists");
            }
            if (
                string.IsNullOrEmpty(user.UserName)
                && string.IsNullOrEmpty(user.Email)
                && string.IsNullOrEmpty(user.Password)
                )
            {
                return BadRequest("Data can not be empty");
            }
            
            user.Id = Guid.NewGuid();
            user.IsActive = true;
            user.Role = "Admin";
            await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return Ok(user.Id);
        }
        [HttpGet]
        [Route("api/get-users")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            List<User> Users = await _dbContext.User.Where(x => x.Role == "User").ToListAsync();
            return Ok(Users);
        }
        [HttpGet]
        [Route("api/delete-user/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var deletedUser = await _dbContext.User.FindAsync(id);
            
            deletedUser.IsActive = false;
            
            var feedbacks = await _dbContext.Feedback.Where(x => x.UserId == id && x.IsActive == true).ToListAsync();

            foreach (var feedback in feedbacks)
            {
                feedback.IsActive = false;
            }

            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        [Route("api/restore-user/{id}")]
        public async Task<IActionResult> RestoreUser(Guid id)
        {
            var UserOldData = await _dbContext.User.FindAsync(id);

            UserOldData.IsActive = true;

            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
