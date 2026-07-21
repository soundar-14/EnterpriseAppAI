namespace EnterpriseAppAI.Infrastructure.AI.Services;

using EnterpriseAppAI.Application.AI.Interfaces;
using EnterpriseAppAI.Application.AI.Models;
using Microsoft.Extensions.Logging;

public class ChatService : IChatService
{
    private readonly ILogger<ChatService> _logger;

    public ChatService(ILogger<ChatService> logger)
    {
        _logger = logger;
    }

    public async Task<ChatResponse> AskAsync(ChatRequest request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Chat request received: {UserMessage}", request.UserMessage);

        // Simulate async work (placeholder - no actual AI yet)
        await Task.Delay(100, cancellationToken);

        var response = new ChatResponse
        {
            Answer = "This is a placeholder response. Azure OpenAI will be integrated tomorrow.",
            ConversationHistory = new List<ChatMessage>
            {
                new()
                {
                    Role = MessageRole.User,
                    Content = request.UserMessage,
                    Timestamp = DateTime.UtcNow
                },
                new()
                {
                    Role = MessageRole.Assistant,
                    Content = "This is a placeholder response. Azure OpenAI will be integrated tomorrow.",
                    Timestamp = DateTime.UtcNow
                }
            },
            Model = "placeholder",
            TokensUsed = 0
        };

        _logger.LogInformation("Chat response generated successfully");
        return response;
    }
}
