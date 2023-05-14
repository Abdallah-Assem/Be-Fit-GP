namespace BeFit_API.Model
{
    public class SpecialFood
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }
        public double Fats { get; set; }
        public double Carbs { get; set; }
        public double Protein { get; set; }
        public bool IsActive { get; set; }
    }
}
