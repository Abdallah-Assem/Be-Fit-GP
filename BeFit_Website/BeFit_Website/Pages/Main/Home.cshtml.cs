using BeFit_Website.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace BeFit_Website.Pages.Main
{
    public class HomeModel : PageModel
    {
        IConfiguration config = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .AddEnvironmentVariables()
           .Build();

        public UserMacros userMacros { get; set; } = new();
        public List<SelectedFood> selectedFoodList { get; set; } = new();
        public UserMacrosDTO userMacrosDTO { get; set; } = new();
        public async Task OnGet()
        {
            // call user macros
            var currentUser = HttpContext.Session.GetString("Id");
            var httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
            var client = httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);
            var request = await client.GetAsync("api/get-user-macros/" + currentUser.ToString().Replace("\"", ""));

            if (request.IsSuccessStatusCode)
            {
                var stringData = request.Content.ReadAsStringAsync().Result;
                userMacros = JsonConvert.DeserializeObject<UserMacros>(stringData);
                request = await client.GetAsync("api/get-user-calories/" + currentUser.ToString().Replace("\"", ""));
                if (request.IsSuccessStatusCode)
                {
                    var stringData2 = request.Content.ReadAsStringAsync().Result;
                    userMacrosDTO = JsonConvert.DeserializeObject<UserMacrosDTO>(stringData2);
                    request = await client.GetAsync("api/get-selected-food/" + currentUser.ToString().Replace("\"", ""));
                    if (request.IsSuccessStatusCode)
                    {
                        var stringData3 = request.Content.ReadAsStringAsync().Result;
                        selectedFoodList = JsonConvert.DeserializeObject<List<SelectedFood>>(stringData3);
                    }
                }
            }
        }
        public async Task<IActionResult> OnPostDeleteSelectedFood(Guid itemid)
        {
            var httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
            var client = httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);
            var request = await client.GetAsync("/api/delete-selected-food/" + itemid);
            if (request.IsSuccessStatusCode)
            {
                return RedirectToPage("");
            }
            return new NoContentResult();
        }


    }
}
