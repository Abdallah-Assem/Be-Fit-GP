using BeFit_API.Data;
using BeFit_API.Model;
using Microsoft.AspNetCore.Mvc;
using Azure.Core;
using Microsoft.Extensions.Options;
using System.Text.Json;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace BeFit_API.Controllers
{
    public class FoodController : Controller
    {
        private readonly WebsiteDbContext _dbContext;
        public FoodController(WebsiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("api/get-food{query}")]
        public async Task<ActionResult<Food>> Get(string query)
        {
            Food food = new Food();

            string apiUrl = "https://api.calorieninjas.com/v1/nutrition?query=";
            string apiKey = "NSY0K/87CknrbifvUzURYg==adexvTtlOnDiCXdN";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);

                HttpResponseMessage response = client.GetAsync(apiUrl + query).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;

                    dynamic jsonResponse = JsonConvert.DeserializeObject(responseBody);

                    if (responseBody != "{"+"\"items\": []}")
                    {
                        food.name = jsonResponse.items[0].name;
                        food.calories = jsonResponse.items[0].calories;
                        food.serving_size_g = jsonResponse.items[0].serving_size_g;
                        food.fat_total_g = jsonResponse.items[0].fat_total_g;
                        food.fat_saturated_g = jsonResponse.items[0].fat_saturated_g;
                        food.protein_g = jsonResponse.items[0].protein_g;
                        food.sodium_mg = jsonResponse.items[0].sodium_mg;
                        food.potassium_mg = jsonResponse.items[0].potassium_mg;
                        food.cholesterol_mg = jsonResponse.items[0].cholesterol_mg;
                        food.carbohydrates_total_g = jsonResponse.items[0].carbohydrates_total_g;
                        food.fiber_g = jsonResponse.items[0].fiber_g;
                        food.sugar_g = jsonResponse.items[0].sugar_g;
                        return Ok(food);
                    }else
                    {
                        return BadRequest("Food Not Found");
                    }
                }
                else
                {
                    return BadRequest("Food Not Found");
                }

            }
        }
        [HttpGet]
        [Route("api/get-selected-food/{id}")]
        public async Task<ActionResult<List<SelectedFood>>> GetSelectedFood(Guid id)
        {
            List<SelectedFood> selectedFoods= await _dbContext.SelectedFood.Where(x => x.UserId == id && x.IsActive == true && x.TimeCreated.Day == DateTime.Now.Day).ToListAsync();
            return Ok(selectedFoods);
        }


        [HttpPost]
        [Route("api/add-selected-food")]
        public async Task<IActionResult> AddSelectedFood([FromBody] CombineFood_SelectedFood Food_SelectedFood)
        {
            if (
                Food_SelectedFood.CombinedSelectedFood.UserId == Guid.Empty
                && string.IsNullOrEmpty(Food_SelectedFood.CombinedFood.name)
                && Food_SelectedFood.CombinedSelectedFood.Weight <= 0
                && Food_SelectedFood.CombinedSelectedFood.Quantity <= 0
                && string.IsNullOrEmpty(Food_SelectedFood.CombinedSelectedFood.Meal)
                )
            {
                return BadRequest();
            }
            Food_SelectedFood.CombinedSelectedFood.Id = Guid.NewGuid();
            Food_SelectedFood.CombinedSelectedFood.TimeCreated = DateTime.Now;
            Food_SelectedFood.CombinedSelectedFood.IsActive = true;
            Food_SelectedFood.CombinedSelectedFood.FoodName = Food_SelectedFood.CombinedFood.name;
            Food_SelectedFood.CombinedSelectedFood.Calories =
                ((Food_SelectedFood.CombinedFood.calories * Food_SelectedFood.CombinedSelectedFood.Weight) / 100) * Food_SelectedFood.CombinedSelectedFood.Quantity;
            Food_SelectedFood.CombinedSelectedFood.Fats =
                ((Food_SelectedFood.CombinedFood.fat_total_g * Food_SelectedFood.CombinedSelectedFood.Weight) / 100) * Food_SelectedFood.CombinedSelectedFood.Quantity;
            Food_SelectedFood.CombinedSelectedFood.Carbs =
                ((Food_SelectedFood.CombinedFood.carbohydrates_total_g * Food_SelectedFood.CombinedSelectedFood.Weight) / 100) * Food_SelectedFood.CombinedSelectedFood.Quantity;
            Food_SelectedFood.CombinedSelectedFood.Protein =
                ((Food_SelectedFood.CombinedFood.protein_g * Food_SelectedFood.CombinedSelectedFood.Weight) / 100) * Food_SelectedFood.CombinedSelectedFood.Quantity;


            await _dbContext.SelectedFood.AddAsync(Food_SelectedFood.CombinedSelectedFood);
            await _dbContext.SaveChangesAsync();
            return Ok(Food_SelectedFood.CombinedSelectedFood);
        }
        [HttpPost]
        [Route("api/add-special-food-to-selected-food")]
        public async Task<IActionResult> AddSpecialFoodToSelectedFood([FromBody] CombineSpecialFood_SelectedFood SpecialFood_SelectedFood)
        {
            if (
                SpecialFood_SelectedFood.CombinedSelectedFood.UserId == Guid.Empty
                && string.IsNullOrEmpty(SpecialFood_SelectedFood.CombinedSpecialFood.Name)
                && SpecialFood_SelectedFood.CombinedSelectedFood.Weight <= 0
                && SpecialFood_SelectedFood.CombinedSelectedFood.Quantity <= 0
                && string.IsNullOrEmpty(SpecialFood_SelectedFood.CombinedSelectedFood.Meal)
                )
            {
                return BadRequest();
            }
            SpecialFood_SelectedFood.CombinedSelectedFood.Id = Guid.NewGuid();
            SpecialFood_SelectedFood.CombinedSelectedFood.TimeCreated = DateTime.Now;
            SpecialFood_SelectedFood.CombinedSelectedFood.IsActive = true;
            SpecialFood_SelectedFood.CombinedSelectedFood.FoodName = SpecialFood_SelectedFood.CombinedSpecialFood.Name;
            SpecialFood_SelectedFood.CombinedSelectedFood.Calories =
                ((SpecialFood_SelectedFood.CombinedSpecialFood.Calories * SpecialFood_SelectedFood.CombinedSelectedFood.Weight) / 100) * SpecialFood_SelectedFood.CombinedSelectedFood.Quantity;
            SpecialFood_SelectedFood.CombinedSelectedFood.Carbs =
                ((SpecialFood_SelectedFood.CombinedSpecialFood.Carbs * SpecialFood_SelectedFood.CombinedSelectedFood.Weight) / 100) * SpecialFood_SelectedFood.CombinedSelectedFood.Quantity;
            SpecialFood_SelectedFood.CombinedSelectedFood.Fats =
                ((SpecialFood_SelectedFood.CombinedSpecialFood.Fats * SpecialFood_SelectedFood.CombinedSelectedFood.Weight) / 100) * SpecialFood_SelectedFood.CombinedSelectedFood.Quantity;
            SpecialFood_SelectedFood.CombinedSelectedFood.Protein =
                ((SpecialFood_SelectedFood.CombinedSpecialFood.Protein * SpecialFood_SelectedFood.CombinedSelectedFood.Weight) / 100) * SpecialFood_SelectedFood.CombinedSelectedFood.Quantity;

            await _dbContext.SelectedFood.AddAsync(SpecialFood_SelectedFood.CombinedSelectedFood);
            await _dbContext.SaveChangesAsync();
            return Ok(SpecialFood_SelectedFood.CombinedSelectedFood);
        }

        [HttpGet]
        [Route("api/get-special-food/{userid}")]
        public async Task<ActionResult<List<SpecialFood>>> GetSpecialFood(Guid userid)
        {
            List<SpecialFood> specialFood = await _dbContext.SpecialFood.Where(x => x.UserId == userid && x.IsActive == true).ToListAsync();
            return Ok(specialFood);
        }

        [HttpGet]
        [Route("api/get-one-special-food/{id}")]
        public async Task<ActionResult<SpecialFood>> GetOneSpecialFood(Guid id)
        {
            var specialdb = await _dbContext.SpecialFood.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
            if (specialdb == null)
            {
                return BadRequest("Special Food doesn't exist");
            }
            return Ok(specialdb);
        }
        
        [HttpPost]
        [Route("api/add-special-food")]
        public async Task<IActionResult> AddSpecialFood([FromBody] SpecialFood specialFood)
        {
            if (
                specialFood.UserId == Guid.Empty
                && string.IsNullOrEmpty(specialFood.Name)
                && specialFood.Calories <= 0
                && specialFood.Fats <= 0
                && specialFood.Carbs <= 0
                && specialFood.Protein <= 0
                )
            {
                return BadRequest("no special food");
            }
            specialFood.Id = Guid.NewGuid();
            specialFood.IsActive = true;
            await _dbContext.SpecialFood.AddAsync(specialFood);
            await _dbContext.SaveChangesAsync();
            return Ok(specialFood);
        }
        [HttpGet]
        [Route("api/delete-selected-food/{id}")]
        public async Task<IActionResult> deleteSelectedFood(Guid id)
        {
            var deletedSelectedFood = await _dbContext.SelectedFood.FindAsync(id);
            deletedSelectedFood.IsActive = false;
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        [Route("api/delete-special-food/{id}")]
        public async Task<IActionResult> deleteSpecialFood(Guid id)
        {
            var deletedSpecialFood = await _dbContext.SpecialFood.FindAsync(id);
            deletedSpecialFood.IsActive = false;
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
