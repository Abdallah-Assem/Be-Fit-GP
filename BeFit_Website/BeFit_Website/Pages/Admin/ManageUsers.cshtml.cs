using BeFit_Website.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace BeFit_Website.Pages.Admin
{
    public class ManageUsersModel : PageModel
    {
        IConfiguration config = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .AddEnvironmentVariables()
           .Build();
        public List<User> usersList { get; set; } = new();
        public async Task OnGet()
        {
            var currentUser = HttpContext.Session.GetString("Id");
            var httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
            var client = httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);
            var request = await client.GetStringAsync("api/get-users");

            if (request != null)
            {
                //var stringData = request.Content.ReadAsStringAsync().Result();
                usersList = JsonConvert.DeserializeObject<List<User>>(request);
            }
        }
        public async Task<IActionResult> OnPostDeleteUser(Guid itemid)
        {
            var httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
            var client = httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);
            var request = await client.GetAsync("/api/delete-user/" + itemid);
            if (request.IsSuccessStatusCode)
            {
                return RedirectToPage("");
            }
            return new NoContentResult();
        }
        public async Task<IActionResult> OnPostRestoreUser(Guid itemid)
        {
            var httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
            var client = httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);
            var request = await client.GetAsync("/api/restore-user/" + itemid);
            if (request.IsSuccessStatusCode)
            {
                return RedirectToPage("");
            }
            return new NoContentResult();
        }
    }
}
