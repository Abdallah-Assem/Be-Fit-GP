using BeFit_Website.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace BeFit_Website.Pages.Exercises
{
    public class ShowExercisesModel : PageModel
    {
        IConfiguration config = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .AddEnvironmentVariables()
           .Build();
        public List<Exercise> exercisesList { get; set; } = new();
        public async Task OnGet()
        {
            var currentUser = HttpContext.Session.GetString("Id");
            var httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
            var client = httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);
            var request = await client.GetStringAsync("api/get-exercises");

            if (request != null)
            {
                //var stringData = request.Content.ReadAsStringAsync().Result();
                exercisesList = JsonConvert.DeserializeObject<List<Exercise>>(request);
            }
        }
    }
}
