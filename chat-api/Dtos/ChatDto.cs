namespace ChatApi.Dtos
{
    public class ChatDto : DtoBase
    {
        public string? Name { get; set; }

        public IEnumerable<UserDto> Users { get; set; }
        public IEnumerable<MessageDto> Messages { get; set; }
    }
}
