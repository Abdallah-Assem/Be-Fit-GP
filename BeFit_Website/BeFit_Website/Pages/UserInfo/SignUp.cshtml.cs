using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using BeFit_Website.DTO;
using System.Net.Mime;
using System.Net.Http.Headers;

namespace BeFit_Website.Pages.UserInfo
{
    public class SignUpModel : PageModel
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
        
        public void OnGet() { }
        public async Task<IActionResult> OnPost(User user)
        {

                var httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
                var client = httpClient.CreateClient();
                client.BaseAddress = new Uri(config["BaseAddress"]);
                var jsoncategory = JsonConvert.SerializeObject(user);
                var formData = new MultipartFormDataContent();
                formData = await MappingContent(formData, user);
                //var content = new StringContent(jsoncategory, Encoding.UTF8, "application/json");
                var request = await client.PostAsync("/api/add-user", formData);
            
            if (request.IsSuccessStatusCode)
            {
                string id = request.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                HttpContext.Session.SetString("Id", id);
                
                
                return RedirectToPage("/UserInfo/UserMacros");
            }
            Msg = "User Already Exists";
            Status = "error";
            RedirectToPage("");
            return Page();
        }
        private async Task<MultipartFormDataContent> MappingContent(MultipartFormDataContent multipartFormDataContent, User user)
        {
            multipartFormDataContent.Add(new StringContent(user.Id.ToString(), Encoding.UTF8, MediaTypeNames.Text.Plain), "Id");
            multipartFormDataContent.Add(new StringContent(user.UserName, Encoding.UTF8, MediaTypeNames.Text.Plain), "UserName");
            multipartFormDataContent.Add(new StringContent(user.Email, Encoding.UTF8, MediaTypeNames.Text.Plain), "Email");
            multipartFormDataContent.Add(new StringContent(user.Password, Encoding.UTF8, MediaTypeNames.Text.Plain), "Password");
            
            if (user.ProfilePhoto != null)
            {
                
                    var fileContent = new StreamContent(user.ProfilePhoto.OpenReadStream());
                    fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(user.ProfilePhoto.ContentType);
                    multipartFormDataContent.Add(fileContent, "ProfilePhoto", user.ProfilePhoto.FileName);
            }
            return multipartFormDataContent;
        }
    }
}
