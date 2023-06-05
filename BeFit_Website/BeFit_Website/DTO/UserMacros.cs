using System.ComponentModel.DataAnnotations;

namespace BeFit_Website.DTO
{
    public class UserMacros
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        
        [Range(110, 300, ErrorMessage = "Enter Valid Height")]
        public double Height { get; set; }
        [Range(30, 600, ErrorMessage = "Enter Valid Weight")]
        public double Weight { get; set; }
        [Range(5, 100, ErrorMessage = "Enter Valid Age")]
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Goal { get; set; } = string.Empty;
        public string ActivityLevel { get; set; } = string.Empty;
        public string Disease { get; set; } = string.Empty;
        public double DailyCalories { get; set; }
        public double DailyFats { get; set; }
        public double DailyCarbs { get; set; }
        public double DailyProtein { get; set; }
        public bool IsActive { get; set; }
    }
}
