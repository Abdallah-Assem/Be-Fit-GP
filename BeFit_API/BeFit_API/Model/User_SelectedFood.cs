namespace BeFit_API.Model
{
    public class User_SelectedFood
    {
        public Guid Id { get; set; }
        public Guid SelectedFoodId { get; set; }
        public Guid UserId { get; set; }
        public double RemainingCalories { get; set; }
        public double RemainingFats { get; set; }
        public double RemainingCarbs { get; set; }
        public double RemainingProtein { get; set; }
    }
}
