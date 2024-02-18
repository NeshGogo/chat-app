namespace ChatApi.Entities
{
    public class Message : EntityBase
    {
        public Guid UserId { get; set; }
        public Guid ChatId { get; set; }
        public string Content { get; set; }

        public User? User { get; set; }
        public Chat? Chat { get; set; }
    }
}