namespace ChatApi.GraphQL.Users
{
    public record AddUserInput
    (
        string Name, 
        string Email, 
        string UserName, 
        string Phone, 
        string PhonePrefix
    );    
}
