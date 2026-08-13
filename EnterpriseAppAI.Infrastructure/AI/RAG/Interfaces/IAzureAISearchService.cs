using EnterpriseAppAI.Infrastructure.AI.RAG.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAppAI.Infrastructure.AI.RAG.Interfaces;

public interface IAzureAISearchService
{
    Task CreateIndexIfNotExistsAsync(
        CancellationToken cancellationToken = default);

    Task UploadDocumentsAsync(
        IReadOnlyList<DocumentChunk> chunks,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<DocumentChunk>> SearchAsync(
        string searchText,
        int top = 5,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<DocumentChunk>> SearchByVectorAsync(
        string query,
        int top = 5,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<DocumentChunk>> HybridSearchAsync(
        string query,
        int top = 5,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<DocumentChunk>> GetDocumentChunksAsync(
     string documentName,
     CancellationToken cancellationToken = default);
}