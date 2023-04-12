using BeFit_Website.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
namespace BeFit_Website.Pages.UserInfo
{
    public class EditUserModel : PageModel
    {

        IConfiguration config = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .AddEnvironmentVariables()
           .Build();

        [TempData]
        public string Msg { get; set; } = String.Empty;
        [TempData]
        public string Status { get; set; } = String.Empty;
        public User user { get; set; } = new();
        public async Task OnGet()
        {
            var currentUser = HttpContext.Session.GetString("Id");
            var httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
            var client = httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);
            var request = await client.GetAsync("api/get-user-data/" + currentUser.ToString().Replace("\"", ""));

            if (request.IsSuccessStatusCode)
            {
                var stringData = request.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<User>(stringData);
            }

        }
        public async Task<IActionResult> OnPost(User user)
        {
            var currentUser = HttpContext.Session.GetString("Id");
            var httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
            var client = httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);
            var jsoncategory = JsonConvert.SerializeObject(user);
            var content = new StringContent(jsoncategory, Encoding.UTF8, "application/json");
            var request = await client.PutAsync($"/api/edit-user-data{currentUser.ToString().Replace("\"", "")}", content);
            if (request.IsSuccessStatusCode) { 
                return RedirectToPage("/Main/Home");
            }
            Msg = "User Already Exists";
            Status = "error";
            RedirectToPage("");
            return Page();
        }
    }

}



