using BeFit_API.Data;
using BeFit_API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeFit_API.Controllers
{
    public class UserController : Controller
    {
        private readonly WebsiteDbContext _dbContext;
        public UserController(WebsiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        [Route("api/add-user")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            var loggedUser = await _dbContext.User.FirstOrDefaultAsync(x => x.UserName == user.UserName && x.IsActive == true);

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
            //TODO
            user.ProfilePicture = null;
            user.Id = Guid.NewGuid();
            user.IsActive = true;
            await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return Ok(user.Id);
        }

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
            //Calculate BMR (Mifflin-St Jeor)
            double BMR = 0;
            double TDEE = 0;
            if (userMacros.Gender == "Male")
            {
                BMR = (double)(5 + (10 * userMacros.Weight) + (6.25 * userMacros.Height) - (5 * userMacros.Age));
            } else
            {
                BMR = (double)((10 * userMacros.Weight) + (6.25 * userMacros.Height) - (5 * userMacros.Age) - 161);
            }
            //Calculate TDEE
            if (userMacros.ActivityLevel == "Sedentary") { TDEE = (double)(BMR * 1.2); }
            else if (userMacros.ActivityLevel == "Lightly") { TDEE = (double)(BMR * 1.375); }
            else if (userMacros.ActivityLevel == "Moderately") { TDEE = (double)(BMR * 1.55); }
            else if (userMacros.ActivityLevel == "Very") { TDEE = (double)(BMR * 1.725); }
            else if (userMacros.ActivityLevel == "Extra") { TDEE = (double)(BMR * 1.9); }
            //Calculate Daily Calories
            if (userMacros.Goal == "Maintain") { userMacros.DailyCalories = Math.Ceiling(TDEE); }
            else if (userMacros.Goal == "Lose") { userMacros.DailyCalories = Math.Ceiling(TDEE - 300); }
            else { userMacros.DailyCalories = Math.Ceiling(TDEE + 300); }
            //Calculate Daily Protein
            if (userMacros.ActivityLevel == "Sedentary" || userMacros.ActivityLevel == "Lightly") { userMacros.DailyProtein = Math.Ceiling((double)(userMacros.Weight * 0.8)); }
            else if (userMacros.ActivityLevel == "Moderately") { userMacros.DailyProtein = Math.Ceiling((double)(userMacros.Weight * 1.2)); }
            else if (userMacros.ActivityLevel == "Very") { userMacros.DailyProtein = Math.Ceiling((double)(userMacros.Weight * 1.5)); }
            else if (userMacros.ActivityLevel == "Extra") { userMacros.DailyProtein = Math.Ceiling((double)(userMacros.Weight * 2.0)); }
            //Calculate Daily Fats
            userMacros.DailyFats = Math.Ceiling(((double)((userMacros.DailyCalories * 0.3)/9)));
            //Calculate Daily Carbs
            userMacros.DailyCarbs = Math.Ceiling(((double)((userMacros.DailyCalories * 0.5) / 4)));


            await _dbContext.UserMacros.AddAsync(userMacros);
            await _dbContext.SaveChangesAsync();
            return Ok();
        } 
    }
}
