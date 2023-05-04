using BeFit_Website.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace BeFit_Website.Pages.Admin
{
    public class ManageFeedbacksModel : PageModel
    {
        IConfiguration config = new ConfigurationBuilder()
          .AddJsonFile("appsettings.json")
          .AddEnvironmentVariables()
          .Build();
        public List<GetFeedback> feedbackList { get; set; } = new();
        public Feedback Feedback { get; set; } = new();
        public User user { get; set; } = new();
        public async Task OnGet()
        {
            var currentUser = HttpContext.Session.GetString("Id");
            var httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
            var client = httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);
            var request = await client.GetStringAsync("api/get-feedbacks-for-admin");

            if (request != null)
            {
                //var stringData = request.Content.ReadAsStringAsync().Result();
                feedbackList = JsonConvert.DeserializeObject<List<GetFeedback>>(request);
            }
            var request2 = await client.GetAsync("api/get-user-data/" + currentUser.ToString().Replace("\"", ""));

            if (request2.IsSuccessStatusCode)
            {
                var stringData = request2.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<User>(stringData);
            }
        }
        public async Task<IActionResult> OnPostDeleteFeedback(Guid itemid)
        {
            var httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
            var client = httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);
            var request = await client.GetAsync("/api/delete-feedback/" + itemid);
            if (request.IsSuccessStatusCode)
            {
                return RedirectToPage("");
            }
            return new NoContentResult();
        }
        public async Task<IActionResult> OnPostApproveFeedback(Guid itemid)
        {
            var httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
            var client = httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);
            var request = await client.GetAsync("/api/approve-feedback/" + itemid);
            if (request.IsSuccessStatusCode)
            {
                return RedirectToPage("");
            }
            return new NoContentResult();
        }
    }
}
