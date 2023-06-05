namespace BeFit_API.Model
{
    public class UserMacros
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Goal { get; set; } = string.Empty;
        public string ActivityLevel { get; set; } = string.Empty;
        public string Disease { get; set; } = string.Empty;
        public double DailyCalories { get; set; }
        public double DailyFats { get; set;}
        public double DailyCarbs { get; set;}
        public double DailyProtein { get; set; }
        public bool IsActive { get; set; }
    }
}
