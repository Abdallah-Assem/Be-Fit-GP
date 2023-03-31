using BeFit_Website.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
namespace BeFit_Website.Pages.UserInfo
{
    public class EditUserModel : PageModel
    {

        IConfiguration config = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .AddEnvironmentVariables()
           .Build();
        public User user { get; set; } = new();

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(User user)
        {
            var currentUser = HttpContext.Session.GetString("Id");
            var httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
            var client = httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);
            var jsoncategory = JsonConvert.SerializeObject(user);
            var content = new StringContent(jsoncategory, Encoding.UTF8, "application/json");
          //takeCare
            var request = await client.PostAsync($"api/edit-user-data/{currentUser}", content);
            //if (request.IsSuccessStatusCode)
            //{
            //    string id = request.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            //    HttpContext.Session.SetString("Id", id);


            //    return RedirectToPage("/UserInfo/Index");
            //}
            return RedirectToPage("/Main/Home");
        }
    }
}



