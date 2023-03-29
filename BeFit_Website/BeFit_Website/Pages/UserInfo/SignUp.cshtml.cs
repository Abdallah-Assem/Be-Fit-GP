using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using BeFit_Website.DTO;

namespace BeFit_Website.Pages.UserInfo
{
    public class SignUpModel : PageModel
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
        
        public void OnGet() { }
        public async Task<IActionResult> OnPost(User user)
        {

                var httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
                var client = httpClient.CreateClient();
                client.BaseAddress = new Uri(config["BaseAddress"]);
                var jsoncategory = JsonConvert.SerializeObject(user);
                var content = new StringContent(jsoncategory, Encoding.UTF8, "application/json");
                var request = await client.PostAsync("/api/add-user", content);
            
            if (request.IsSuccessStatusCode)
            {
                string id = request.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                HttpContext.Session.SetString("Id", id);
                
                
                return RedirectToPage("/UserInfo/UserMacros");
            }
            Msg = "User Already Exists";
            Status = "error";
            RedirectToPage("");
            return Page();
        }
    }
}
