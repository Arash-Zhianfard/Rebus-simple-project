namespace Common.Models
{
    public record SendEmail
    {
        public string Email { get; set; }
        public string Content { get; set; }
    }
}