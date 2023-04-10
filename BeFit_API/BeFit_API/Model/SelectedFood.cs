namespace BeFit_API.Model
{
    public class SelectedFood
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FoodName { get; set; } = string.Empty;
        public double Weight { get; set;}
        public int Quantity { get; set;}
        public double Calories { get; set; }
        public double Fats { get; set; }
        public double Carbs { get; set; }
        public double Protein { get; set; }
        public string Meal { get; set; } = string.Empty;
        public DateTime TimeCreated { get; set;}
        public bool IsActive { get; set;}
    }
}
