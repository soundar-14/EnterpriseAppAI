using EnterpriseAppAI.Infrastructure.AI.RAG.Interfaces;
using EnterpriseAppAI.Infrastructure.AI.RAG.Models;

namespace EnterpriseAppAI.Infrastructure.AI.RAG.Services;

/// <summary>
/// Splits large document text into overlapping chunks.
/// </summary>
public sealed class TextChunkingService : ITextChunkingService
{
    public IReadOnlyList<DocumentChunk> ChunkDocument(
        string documentName,
        string text,
        int chunkSize = 1000,
        int overlap = 200)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(documentName);
        ArgumentException.ThrowIfNullOrWhiteSpace(text);

        if (chunkSize <= overlap)
        {
            throw new ArgumentException(
                "Chunk size must be greater than overlap.");
        }

        var chunks = new List<DocumentChunk>();

        var chunkNumber = 1;

        var start = 0;

        while (start < text.Length)
        {
            var length = Math.Min(chunkSize, text.Length - start);

            var chunkText = text.Substring(start, length);

            chunks.Add(new DocumentChunk
            {
                Id = Guid.NewGuid().ToString(),
                DocumentName = documentName,
                ChunkNumber = chunkNumber++,
                Content = chunkText
            });

            start += chunkSize - overlap;
        }

        return chunks;
    }
}