using BeFit_Website.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace BeFit_Website.Pages.FoodInfo
{
    public class SpecialFoodModel : PageModel
    {
        IConfiguration config = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .AddEnvironmentVariables()
           .Build();

        public List<SpecialFood> specialFoodList { get; set; } = new();

        public SpecialFood specialFood { get; set; } = new();
        public CombineSpecialFood_SelectedFood SpecialFood_SelectedFood { get; set; } = new();
        public async Task OnGet()
        {
            var currentUser = HttpContext.Session.GetString("Id");
            var httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
            var client = httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);
            var request = await client.GetStringAsync("api/get-special-food/" + currentUser.ToString().Replace("\"", ""));

            if (request != null)
            {
                //var stringData = request.Content.ReadAsStringAsync().Result();
                specialFoodList = JsonConvert.DeserializeObject<List<SpecialFood>>(request);
            }
        }
        public async Task<IActionResult> OnPostAddSpecialFood(SpecialFood specialFood)
        {
            var currentUser = HttpContext.Session.GetString("Id");
            specialFood.UserId = Guid.Parse(currentUser.ToString().Replace("\"", ""));
            var httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
            var client = httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);
            var jsoncategory = JsonConvert.SerializeObject(specialFood);
            var content = new StringContent(jsoncategory, Encoding.UTF8, "application/json");
            var request = await client.PostAsync("/api/add-special-food", content);
            if (request.IsSuccessStatusCode)
            {

                return RedirectToPage("");
            }
            //else
            //{
            //    string error = request.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            //    return RedirectToPage("", new { errorMessage = error });
            //}
            return new NoContentResult();
        }
        public async Task<IActionResult> OnPostSelect(Guid itemid,CombineSpecialFood_SelectedFood SpecialFood_SelectedFood)
        {
            var httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
            var client = httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);
            var request = await client.GetAsync("/api/get-one-special-food/" + itemid);
            if (request.IsSuccessStatusCode)
            {
                var stringData = request.Content.ReadAsStringAsync().Result;
                HttpContext.Session.SetString("SelectedSpecialFood", stringData);
                var selectedSpecialFood = JsonConvert.DeserializeObject<SpecialFood>(stringData);
                var currentUser = HttpContext.Session.GetString("Id");

                SpecialFood_SelectedFood.CombinedSelectedFood.UserId = Guid.Parse(currentUser.ToString().Replace("\"", ""));


                SpecialFood_SelectedFood.CombinedSpecialFood = selectedSpecialFood;

                 httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
                 client = httpClient.CreateClient();
                client.BaseAddress = new Uri(config["BaseAddress"]);
                var jsoncategory = JsonConvert.SerializeObject(SpecialFood_SelectedFood);
                var content = new StringContent(jsoncategory, Encoding.UTF8, "application/json");
                 request = await client.PostAsync("api/add-special-food-to-selected-food", content);

                if (request.IsSuccessStatusCode)
                {
                    return RedirectToPage("");
                }
            }
            return new NoContentResult();
        }
        public async Task<IActionResult> OnPostDeleteSpecialFood(Guid itemid)
        {
            var httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
            var client = httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);
            var request = await client.GetAsync("/api/delete-special-food/" + itemid);
            if (request.IsSuccessStatusCode)
            {
                return RedirectToPage("");
            }
            return new NoContentResult();
        }

    }
}
