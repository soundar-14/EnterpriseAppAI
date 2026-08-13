using EnterpriseAppAI.Infrastructure.AI.RAG.Interfaces;
using EnterpriseAppAI.Infrastructure.AI.RAG.Models;
using Microsoft.Extensions.Logging;

namespace EnterpriseAppAI.Infrastructure.AI.RAG.Services;

public sealed class RagService : IRagService
{
    private readonly IAzureAISearchService _searchService;
    private readonly ILogger<RagService> _logger;
    private readonly HRAssistantPromptService _hrAssistantPromptService;
    public RagService(
        IAzureAISearchService searchService,
        HRAssistantPromptService hrAssistantPromptService,
        ILogger<RagService> logger)
    {
        _searchService = searchService;
        _hrAssistantPromptService = hrAssistantPromptService;
        _logger = logger;
    }

    public async Task<RagResponse> AskAsync(
        string question,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Received RAG question: {Question}", question);

        var (context, chunks) = await RetrieveContextAsync(
        question,
        cancellationToken);

        _logger.LogInformation("Retrieved {ChunkCount} chunks from Azure AI Search.", chunks.Count);

        if (chunks.Count == 0)
        {
            return new RagResponse
            {
                Answer = "No relevant information was found.",
                Sources = []
            };
        }

        _logger.LogInformation("Sending prompt to Azure OpenAI.");

        var response = await _hrAssistantPromptService.InvokeAsync(context, question, cancellationToken);

        _logger.LogInformation("Answer generated successfully.");

        var answer = response.GetValue<string>() ?? string.Empty;

        return new RagResponse
        {
            Answer = answer,
            Sources = chunks
                        .Select(c => new RagSource
                        {
                            DocumentName = c.DocumentName,
                            ChunkNumber = c.ChunkNumber
                        })
                        .ToList()
        };
    }

    private async Task<(string Context, IReadOnlyList<DocumentChunk> Chunks)> RetrieveContextAsync(
    string question,
    CancellationToken cancellationToken)
    {
        var chunks = await _searchService.HybridSearchAsync(
            question,
            top: 5,
            cancellationToken);


        var context = string.Join(
            Environment.NewLine + Environment.NewLine,
            chunks.Select(c => c.Content));

        return (context, chunks);
    }
}