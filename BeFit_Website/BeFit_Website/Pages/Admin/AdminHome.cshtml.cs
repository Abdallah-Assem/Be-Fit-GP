using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeFit_Website.Pages.Admin
{
    public class AdminHomeModel : PageModel
    {
        public void OnGet()
        {
            var currentAdmin = HttpContext.Session.GetString("Id");
        }
    }
}
