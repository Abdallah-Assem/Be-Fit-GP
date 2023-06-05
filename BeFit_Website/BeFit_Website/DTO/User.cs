using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeFit_Website.DTO
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? ProfileUrl { get; set; }
        [NotMapped]
        public IFormFile? ProfilePhoto { get; set; }
        public string Role { get; set; } = string.Empty;
        public DateTime LastUpdate { get; set; }
        public bool IsActive { get; set; }
    }
}
