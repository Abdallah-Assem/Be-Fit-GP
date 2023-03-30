using BeFit_Website.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeFit_Website.Pages.Main
{
    public class HomeModel : PageModel
    {
        public void OnGet()
        {
            var currentUser = HttpContext.Session.GetString("Id");

        }

        
    }
}
