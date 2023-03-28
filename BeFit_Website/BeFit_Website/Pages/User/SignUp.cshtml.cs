using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using BeFit_Website.DTO;

namespace BeFit_Website.Pages.User
{
    public class SignUpModel : PageModel
    {
        
        IConfiguration config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .AddEnvironmentVariables()
               .Build();
        
        
        public async Task OnGet()
        {
            Man man = new Man();
            man.UserName = "admin";
            var httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
            var client = httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);
            var jsoncategory = JsonConvert.SerializeObject(man);
            var content = new StringContent(jsoncategory, Encoding.UTF8, "application/json");
            var request = await client.PostAsync("/api/add-user", content);

            if (request.IsSuccessStatusCode)
            {
               // var stringdata = request.Content.ReadAsStringAsync().Result;
               // HttpContext.Session.SetString("LoggedUser", stringdata);
               // Loggedpatient = JsonConvert.DeserializeObject<Patient>(stringdata);
            }
        }
    }
}
