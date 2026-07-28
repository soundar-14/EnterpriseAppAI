namespace EnterpriseAppAI.Infrastructure.AI.RAG.Models;

/// <summary>
/// Represents one chunk of a document that will be indexed
/// into Azure AI Search.
/// </summary>
public sealed class DocumentChunk
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string DocumentName { get; set; } = string.Empty;

    public int ChunkNumber { get; set; }

    public string Content { get; set; } = string.Empty;

    public float[] Embedding { get; set; } = [];
}