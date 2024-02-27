namespace ChatApi.Dtos
{
    public class UserDto : DtoBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string PhonePrefix { get; set; }
    }
}
