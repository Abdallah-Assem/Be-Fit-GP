using System.ComponentModel.DataAnnotations;

namespace BeFit_Website.DTO
{
    public class SelectedFood
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FoodName { get; set; } = string.Empty;

        [Range(0.1, 10000, ErrorMessage = "Enter Valid Weight")]
        public double Weight { get; set; }
        [Range(1, 100, ErrorMessage = "Enter Valid Quantity")]
        public int Quantity { get; set; }
        public double Calories { get; set; }
        public double Fats { get; set; }
        public double Carbs { get; set; }
        public double Protein { get; set; }
        public string Meal { get; set; } = string.Empty;
        public DateTime TimeCreated { get; set; }
        public bool IsActive { get; set; }
    }
}
