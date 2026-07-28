using EnterpriseAppAI.Infrastructure.AI.RAG.Models;

namespace EnterpriseAppAI.Infrastructure.AI.RAG.Interfaces;

public interface IEmbeddingService
{
    Task GenerateEmbeddingsAsync(
        IReadOnlyList<DocumentChunk> chunks,
        CancellationToken cancellationToken = default);
}