using System.ComponentModel.DataAnnotations;

namespace BeFit_Website.DTO
{
    public class CombineFood_SelectedFood
    {
        
        public Food CombinedFood { get; set; } = new Food();
        public SelectedFood CombinedSelectedFood { get; set; } = new SelectedFood();
        
    }
}
