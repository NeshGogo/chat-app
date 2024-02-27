namespace ChatApi.Dtos
{
    public class MessageDto : DtoBase
    {
        public Guid UserId { get; set; }
        public Guid ChatId { get; set; }
        public string Content { get; set; }

        public UserDto? User { get; set; }
    }
}