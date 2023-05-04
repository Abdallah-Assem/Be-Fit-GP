namespace BeFit_Website.DTO
{
    public class GetFeedback
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User FeedbackUser { get; set; } = new User();
        public string Message { get; set; } = string.Empty;
        public DateTime TimeCreated { get; set; }
        public bool Approved { get; set; }
        public bool IsActive { get; set; }
    }
}
