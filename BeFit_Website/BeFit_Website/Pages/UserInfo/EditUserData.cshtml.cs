using BeFit_Website.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
namespace BeFit_Website.Pages.UserInfo
{
    public class EditUserModel : PageModel
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
        public async Task OnGet()
        {
            var currentUser = HttpContext.Session.GetString("Id");
            var httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
            var client = httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);
            var request = await client.GetAsync("api/get-user-data/" + currentUser.ToString().Replace("\"", ""));

            if (request.IsSuccessStatusCode)
            {
                var stringData = request.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<User>(stringData);
            }

        }
        public async Task<IActionResult> OnPostEditUser(User user)
        {
            var currentUser = HttpContext.Session.GetString("Id");
            var httpClient = HttpContext.RequestServices.GetService<IHttpClientFactory>();
            var client = httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);
            var jsoncategory = JsonConvert.SerializeObject(user);
            //var content = new StringContent(jsoncategory, Encoding.UTF8, "application/json");
            user.Id = Guid.Parse(currentUser.ToString().Replace("\"", ""));
            var formData = new MultipartFormDataContent();
            formData = await MappingContent(formData, user);
            var request = await client.PutAsync("/api/edit-user-data", formData);
            if (request.IsSuccessStatusCode) { 
                return RedirectToPage("/Main/Home");
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



