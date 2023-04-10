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
            }
        }

        
    }
}
