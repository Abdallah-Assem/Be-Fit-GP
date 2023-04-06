using BeFit_Website.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace BeFit_Website.Pages.Main
{
    public class HomeModel : PageModel
    {
        IConfiguration config = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .AddEnvironmentVariables()
           .Build();
        public void OnGet()
        {
            var currentUser = HttpContext.Session.GetString("Id");

        }

        
    }
}
