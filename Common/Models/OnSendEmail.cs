namespace Common.Models
{
    public record OnSendEmail
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
    }
}
