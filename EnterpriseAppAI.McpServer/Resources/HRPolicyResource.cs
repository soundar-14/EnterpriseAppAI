using EnterpriseAppAI.Infrastructure.AI.RAG.Interfaces;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace EnterpriseAppAI.McpServer.Resources;

public sealed class HRPolicyResource
{
    private readonly IAzureAISearchService _searchService;

    public HRPolicyResource(
        IAzureAISearchService searchService)
    {
        _searchService = searchService;
    }

    [McpServerResource(
        UriTemplate = "hrpolicy://policy",
        Name = "HR Policy",
        MimeType = "text/plain")]
    [Description(
        "Provides the current HR policy content from Azure AI Search.")]
    public async Task<string> GetHRPolicyAsync(
        CancellationToken cancellationToken = default)
    {
        var chunks = await _searchService.GetDocumentChunksAsync(
            "HRPolicy.pdf",
            cancellationToken);

        if (chunks.Count == 0)
        {
            return "HR policy information could not be found.";
        }

        return string.Join(
            Environment.NewLine + Environment.NewLine,
            chunks
                .OrderBy(x => x.ChunkNumber)
                .Select(x => x.Content));
    }
}