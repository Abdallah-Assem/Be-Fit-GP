using BeFit_Website.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BeFit_Website.Pages.FoodInfo
{
    public class SearchForFoodModel : PageModel
    {
        IConfiguration config = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .AddEnvironmentVariables()
           .Build();

        public Food food { get; set; } = new();
        public string ErrorMessage { get; set; } = string.Empty;

        public CombineFood_SelectedFood Food_SelectedFood { get; set; } = new();
        public SelectedFood SelectedFood { get; set; }
        public List<SpecialFood> SpecialFood { get; set; } = new();
        public async Task OnGet(Food? searchedFood, string? errorMessage)
        {
            food = searchedFood;
            ErrorMessage = errorMessage;

        }


        public async Task<IActionResult> OnPostSearch(Food food)
        {

            var httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
            var client = httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);

            var request = await client.GetAsync($"/api/get-food{food.name}");
            if (request.IsSuccessStatusCode)
            {
                var stringData = request.Content.ReadAsStringAsync().Result;
                food = JsonConvert.DeserializeObject<Food>(stringData);
                HttpContext.Session.SetString("SearchedFood", stringData);
                return RedirectToPage("", food);
            }
            else
            {
                string error = request.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return RedirectToPage("", new { errorMessage = error });
            }
            return new NoContentResult();
        }
        public async Task<IActionResult> OnPostAddFood(CombineFood_SelectedFood Food_SelectedFood)
        {

            var currentUser = HttpContext.Session.GetString("Id");

            Food_SelectedFood.CombinedSelectedFood.UserId = Guid.Parse(currentUser.ToString().Replace("\"", ""));
            //calling the searched food to pop up
            var stringData = HttpContext.Session.GetString("SearchedFood");
            var searchedFood = JsonConvert.DeserializeObject<Food>(stringData);
            Food_SelectedFood.CombinedFood = searchedFood;

            //continue calling api
            var httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
            var client = httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);
            var jsoncategory = JsonConvert.SerializeObject(Food_SelectedFood);
            var content = new StringContent(jsoncategory, Encoding.UTF8, "application/json");
            var request = await client.PostAsync("api/add-selected-food", content);

            if (request.IsSuccessStatusCode)
            {
                return RedirectToPage("");
            }

            return new NoContentResult();

        }
    }
}
