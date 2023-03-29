using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeFit_Website.Pages.UserInfo
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
            var currentUser = HttpContext.Session.GetString("Id");
        }
    }
}
