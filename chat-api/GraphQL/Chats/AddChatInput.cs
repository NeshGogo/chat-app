using ChatApi.Entities;

namespace ChatApi.GraphQL.Chats
{
    public record AddChatInput
    (
        string? Name,
        List<string> UserIds
    );
}
