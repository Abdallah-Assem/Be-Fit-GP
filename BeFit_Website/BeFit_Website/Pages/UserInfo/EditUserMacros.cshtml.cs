using BeFit_Website.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace BeFit_Website.Pages.UserInfo
{
    public class EditUserMacrosModel : PageModel
    {
        IConfiguration config = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .AddEnvironmentVariables()
           .Build();
        public UserMacros userMacros { get; set; } = new();
        public async Task OnGet()
        {
            var currentUser = HttpContext.Session.GetString("Id");
            var httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
            var client = httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);
            var request = await client.GetAsync("api/get-user-Macros/" + currentUser.ToString().Replace("\"", ""));

            if (request.IsSuccessStatusCode)
            {
                var stringData = request.Content.ReadAsStringAsync().Result;
                userMacros = JsonConvert.DeserializeObject<UserMacros>(stringData);
            }

        }
        public async Task<IActionResult> OnPost(UserMacros userMacros, Guid id)
        {
            var currentUser = HttpContext.Session.GetString("Id");
            var httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
            var client = httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);
            var jsoncategory = JsonConvert.SerializeObject(userMacros);
            var content = new StringContent(jsoncategory, Encoding.UTF8, "application/json");
            var request = await client.PutAsync($"/api/edit-user-macros{currentUser.ToString().Replace("\"", "")}", content);
            if (request.IsSuccessStatusCode)
            {
                
            }
            return RedirectToPage("/Main/Home");
        }
    }
}
