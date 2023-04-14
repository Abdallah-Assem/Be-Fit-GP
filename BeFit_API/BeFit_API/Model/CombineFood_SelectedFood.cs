namespace BeFit_API.Model
{
    public class CombineFood_SelectedFood
    {
        public Food CombinedFood { get; set; } = new Food();
        public SelectedFood CombinedSelectedFood { get; set; } = new SelectedFood();
    }
}
