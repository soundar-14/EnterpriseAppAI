using EnterpriseAppAI.Infrastructure.AI.RAG.Interfaces;
using EnterpriseAppAI.Infrastructure.AI.RAG.Models;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel.Embeddings;

namespace EnterpriseAppAI.Infrastructure.AI.RAG.Services;

public sealed class EmbeddingService : IEmbeddingService
{
    private readonly ITextEmbeddingGenerationService _embeddingService;
    private readonly ILogger<EmbeddingService> _logger;

    public EmbeddingService(
        ITextEmbeddingGenerationService embeddingService,
        ILogger<EmbeddingService> logger)
    {
        _embeddingService = embeddingService;
        _logger = logger;
    }

    public async Task GenerateEmbeddingsAsync(
        IReadOnlyList<DocumentChunk> chunks,
        CancellationToken cancellationToken = default)
    {
        foreach (var chunk in chunks)
        {
            cancellationToken.ThrowIfCancellationRequested();

            _logger.LogInformation(
                "Generating embedding for Chunk {Chunk}",
                chunk.ChunkNumber);

            var embedding =
                await _embeddingService.GenerateEmbeddingAsync(
                    chunk.Content,
                    cancellationToken: cancellationToken);

            chunk.Embedding = embedding.ToArray();
        }

        _logger.LogInformation(
            "Generated embeddings for {Count} chunks.",
            chunks.Count);
    }
}