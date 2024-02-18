using ChatApi.Entities;

namespace ChatApi.GraphQL.Chats
{
    public record AddChatInput
    (
        string? Name,
        User Users
    );
}
