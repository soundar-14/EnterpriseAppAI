using EnterpriseAppAI.Infrastructure.AI.RAG.Models;

namespace EnterpriseAppAI.Infrastructure.AI.RAG.Interfaces;

public interface IRagService
{
    Task<RagResponse> AskAsync(
                    string question,
                    CancellationToken cancellationToken = default);
}