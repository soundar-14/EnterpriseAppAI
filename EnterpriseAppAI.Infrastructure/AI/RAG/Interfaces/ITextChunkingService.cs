using EnterpriseAppAI.Infrastructure.AI.RAG.Models;

namespace EnterpriseAppAI.Infrastructure.AI.RAG.Interfaces;

public interface ITextChunkingService
{
    IReadOnlyList<DocumentChunk> ChunkDocument(
        string documentName,
        string text,
        int chunkSize = 1000,
        int overlap = 200);
}