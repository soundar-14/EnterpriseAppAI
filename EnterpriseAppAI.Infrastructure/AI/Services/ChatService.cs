namespace EnterpriseAppAI.Infrastructure.AI.Services;

using EnterpriseAppAI.Application.AI.Interfaces;
using EnterpriseAppAI.Application.AI.Models;
using EnterpriseAppAI.Infrastructure.AI.Plugins;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

/// <summary>
/// ChatService orchestrates AI chat processing using Semantic Kernel.
/// 
/// Architecture Flow:
/// 1. Receives ChatRequest with user message
/// 2. Creates Kernel 
/// 3. Gets IChatCompletionService from kernel
/// 4. Sends message to Azure OpenAI via SK
/// 5. Returns ChatResponse with answer
/// </summary>
public class ChatService : IChatService
{
    private readonly ILogger<ChatService> _logger;

    private readonly Kernel _kernel;

    private readonly IServiceProvider _serviceProvider;

    public ChatService(
        ILogger<ChatService> logger,
        Kernel kernel,
        IServiceProvider serviceProvider)
    {
        _logger = logger;
        _kernel = kernel;
        _serviceProvider = serviceProvider;
    }



    public async Task<ChatResponse> AskAsync(ChatRequest request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Chat request received: {UserMessage}", request.UserMessage);
        var history = new ChatHistory();

        foreach (var message in request.ConversationHistory)
        {
            switch (message.Role.ToString().ToLower())
            {
                case "system":
                    history.AddSystemMessage(message.Content);
                    break;

                case "assistant":
                    history.AddAssistantMessage(message.Content);
                    break;

                default:
                    history.AddUserMessage(message.Content);
                    break;
            }
        }

        history.AddUserMessage(request.UserMessage);
 

        _kernel.RegisterPlugins(_serviceProvider);

        var executionSettings =
            ChatExecutionSettingsFactory.Create();

        var chatCompletionService =
            _kernel.GetRequiredService<IChatCompletionService>();

        var response =
            await chatCompletionService.GetChatMessageContentAsync(
                history,
                executionSettings,
                _kernel,
                cancellationToken);

        var tokensUsed = 0;

        if (response.Metadata?.TryGetValue("usage", out var usage) == true)
        {
            if (usage is System.Collections.Generic.Dictionary<string, object> usageDict && usageDict.TryGetValue("total_tokens", out var tokens))
            {
                tokensUsed = Convert.ToInt32(tokens);
            }
        }

        var chatResponse = new ChatResponse
        {
            Answer = response.Content ?? string.Empty,
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
                        Content = response.Content ?? string.Empty,
                        Timestamp = DateTime.UtcNow
                    }
                },
            Model = "azure-openai",
            TokensUsed = tokensUsed,
            CreatedAt = DateTime.UtcNow
        };

        return chatResponse;

    }
}
