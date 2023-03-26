namespace BeFit_API.Model
{
    public class UserMacros
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Goal { get; set; } = string.Empty;
        public int ActivityLevel { get; set; } 
        public double DailyCalories { get; set; }
        public double DailyFats { get; set;}
        public double DailyCarbs { get; set;}
        public double DailyProtein { get; set; }
        public bool IsActive { get; set; }
    }
}
