namespace BeFit_API.Model
{
    public class CombineSpecialFood_SelectedFood
    {
        public SpecialFood CombinedSpecialFood { get; set; } = new SpecialFood();
        public SelectedFood CombinedSelectedFood { get; set; } = new SelectedFood();
    }
}
