using System.ComponentModel.DataAnnotations.Schema;

namespace BeFit_API.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string? ProfileUrl { get; set; } = string.Empty;
        [NotMapped]
        public IFormFile? ProfilePhoto { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool IsActive { get; set;}
        
    }
}
