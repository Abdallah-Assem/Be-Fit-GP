using BeFit_API.Data;
using BeFit_API.Model;
using Microsoft.AspNetCore.Mvc;

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
        [Route("api/add-user-macros")]
        public async Task<IActionResult> AddUserMacros (UserMacros userMacros)
        {
            if (string.IsNullOrEmpty(userMacros.Goal)
                && userMacros.UserId == Guid.Empty 
                && userMacros.Height == 0 
                && userMacros.Weight == 0 
                && userMacros.Age == 0
                && string.IsNullOrEmpty(userMacros.Gender)
                && userMacros.ActivityLevel == 0)
            {
                return BadRequest("Data can not be empty");
            }
            //TODO
            userMacros.UserId = Guid.Parse("539b1e75-f5f7-487c-87f5-080e23e20b76");

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
            if (userMacros.ActivityLevel == 1) { TDEE = (double)(BMR * 1.2); }
            else if (userMacros.ActivityLevel == 2) { TDEE = (double)(BMR * 1.375); }
            else if (userMacros.ActivityLevel == 3) { TDEE = (double)(BMR * 1.55); }
            else if (userMacros.ActivityLevel == 4) { TDEE = (double)(BMR * 1.725); }
            else if (userMacros.ActivityLevel == 5) { TDEE = (double)(BMR * 1.9); }
            //Calculate Daily Calories
            if (userMacros.Goal == "Maintain") { userMacros.DailyCalories = Math.Ceiling(TDEE); }
            else if (userMacros.Goal == "Lose") { userMacros.DailyCalories = Math.Ceiling(TDEE - 300); }
            else { userMacros.DailyCalories = Math.Ceiling(TDEE + 300); }
            //Calculate Daily Protein
            if (userMacros.ActivityLevel == 1 || userMacros.ActivityLevel == 2) { userMacros.DailyProtein = Math.Ceiling((double)(userMacros.Weight * 0.8)); }
            else if (userMacros.ActivityLevel == 3) { userMacros.DailyProtein = Math.Ceiling((double)(userMacros.Weight * 1.2)); }
            else if (userMacros.ActivityLevel == 4) { userMacros.DailyProtein = Math.Ceiling((double)(userMacros.Weight * 1.5)); }
            else if (userMacros.ActivityLevel == 5) { userMacros.DailyProtein = Math.Ceiling((double)(userMacros.Weight * 2.0)); }
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
