using BeFit_Website.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeFit_Website.Pages.UserInfo
{
    public class LoginModel : PageModel
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
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPost(User user)
        {
            var httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
            var client = httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);
            var jsoncategory = JsonConvert.SerializeObject(user);
            var content = new StringContent(jsoncategory, Encoding.UTF8, "application/json");
            var request = await client.PostAsync("/api/login-user", content);

            if (request.IsSuccessStatusCode)
            {

                string id = request.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                HttpContext.Session.SetString("Id", id);
                request = await client.PostAsync($"/api/check-role{id.ToString().Replace("\"", "")}", content);
                if(request.IsSuccessStatusCode) 
                {
                    return RedirectToPage("/Admin/ManageFeedbacks");
                }
                request = await client.PostAsync($"/api/check-last-update{id.ToString().Replace("\"", "")}", content);
            if (request.IsSuccessStatusCode)
            {
                return RedirectToPage("/Main/Home");
            }
            return RedirectToPage("/UserInfo/FollowUpMessage");


            }
            Msg = "Wrong username or password";
            Status = "error";
            RedirectToPage("");
            return Page();
        }

    }
}
