namespace ChatApi.Entities
{
    public class Message : EntityBase
    {
        public string UserId { get; set; }
        public string ChatId { get; set; }
        public string Content { get; set; }

        public User? User { get; set; }
        public Chat? Chat { get; set; }
    }
}