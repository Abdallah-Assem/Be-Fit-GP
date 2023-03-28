namespace BeFit_Website.DTO
{
    public class Man
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? ProfilePicture { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
