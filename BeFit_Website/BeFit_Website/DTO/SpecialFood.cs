using System.ComponentModel.DataAnnotations;

namespace BeFit_Website.DTO
{
    public class SpecialFood
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        [Range(0, 10000, ErrorMessage = "Enter Valid Calories")]
        public double Calories { get; set; }
        [Range(0, 1000, ErrorMessage = "Enter Valid Fats")]
        public double Fats { get; set; }
        [Range(0, 1000, ErrorMessage = "Enter Valid Carbs")]
        public double Carbs { get; set; }
        [Range(0, 1000, ErrorMessage = "Enter Valid Protein")]
        public double Protein { get; set; }
        public bool IsActive {get; set; }
    }
}
