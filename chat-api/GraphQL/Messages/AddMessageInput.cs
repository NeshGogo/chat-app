namespace ChatApi.GraphQL.Messages
{
    public class AddMessageInput
    {
        public Guid UserId { get; set; }
        public Guid ChatId { get; set; }
        public string Content { get; set; }
    }
}
