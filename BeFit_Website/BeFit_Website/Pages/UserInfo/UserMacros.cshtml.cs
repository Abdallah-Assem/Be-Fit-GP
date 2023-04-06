using BeFit_Website.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace BeFit_Website.Pages.UserInfo
{
    public class UserMacrosModel : PageModel
    {
        IConfiguration config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .AddEnvironmentVariables()
               .Build();


        public UserMacros userMacros { get; set; } = new();
        
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(UserMacros userMacros)
        {
            var currentUser = HttpContext.Session.GetString("Id");
             
                if (currentUser != null)
                {
                    userMacros.UserId = Guid.Parse(currentUser.ToString().Replace("\"", ""));
                    var httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
                    var client = httpClient.CreateClient();
                    client.BaseAddress = new Uri(config["BaseAddress"]);
                    var jsoncategory = JsonConvert.SerializeObject(userMacros);
                    var content = new StringContent(jsoncategory, Encoding.UTF8, "application/json");
                    var request = await client.PostAsync("/api/add-user-macros", content);
                    return RedirectToPage("/UserInfo/Login");
                }
            return Page();
        }
    }
}
