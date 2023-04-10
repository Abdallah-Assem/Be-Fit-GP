using BeFit_Website.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BeFit_Website.Pages.Main
{
    public class SearchForFoodModel : PageModel
    {
        IConfiguration config = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .AddEnvironmentVariables()
           .Build();
        public  Food food { get; set; } = new();
        public string ErrorMessage { get; set; } = string.Empty;
        public async Task OnGet(Food? searchedFood,string? errorMessage)
        {
            food = searchedFood;
            ErrorMessage = errorMessage;
        }
        public async Task<IActionResult> OnPost(Food food)
        {
            //var currentUser = HttpContext.Session.GetString("Id");
            var httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
            var client = httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);
            //var jsoncategory = JsonConvert.SerializeObject(user);
            //var content = new StringContent(jsoncategory, Encoding.UTF8, "application/json");
            var request = await client.GetAsync($"/api/get-food{food.name}");
            if (request.IsSuccessStatusCode)
            {
                var stringData = request.Content.ReadAsStringAsync().Result;
                food = JsonConvert.DeserializeObject<Food>(stringData);
                return RedirectToPage("", food);
            }
            else
            {
                string error = request.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return RedirectToPage("", new { errorMessage = error});
            }
        }
    }
}
