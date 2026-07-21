namespace EnterpriseAppAI.Application.AI.Interfaces;

using EnterpriseAppAI.Application.AI.Models;

public interface IChatService
{
    Task<ChatResponse> AskAsync(ChatRequest request, CancellationToken cancellationToken = default);
}
