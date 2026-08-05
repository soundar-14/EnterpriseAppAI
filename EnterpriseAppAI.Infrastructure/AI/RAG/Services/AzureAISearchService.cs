using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;
using EnterpriseAppAI.Infrastructure.AI.Options;
using EnterpriseAppAI.Infrastructure.AI.RAG.Interfaces;
using EnterpriseAppAI.Infrastructure.AI.RAG.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.SemanticKernel.Embeddings;

namespace EnterpriseAppAI.Infrastructure.AI.RAG.Services;

public sealed class AzureAISearchService : IAzureAISearchService
{
    private readonly AzureAISearchOptions _options;
    private readonly ILogger<AzureAISearchService> _logger;
    private readonly ITextEmbeddingGenerationService _embeddingService;

    public AzureAISearchService(
        IOptions<AzureAISearchOptions> options,
        ILogger<AzureAISearchService> logger,
        ITextEmbeddingGenerationService embeddingService)
    {
        _options = options.Value;
        _logger = logger;
        _embeddingService = embeddingService;
    }

    private SearchIndexClient CreateIndexClient()
    {
        return new SearchIndexClient(
            new Uri(_options.Endpoint),
            new AzureKeyCredential(_options.ApiKey));
    }

    private SearchClient CreateSearchClient()
    {
        return new SearchClient(
            new Uri(_options.Endpoint),
            _options.IndexName,
            new AzureKeyCredential(_options.ApiKey));
    }

    public async Task CreateIndexIfNotExistsAsync(
        CancellationToken cancellationToken = default)
    {
        var indexClient = CreateIndexClient();

        if (await indexClient.GetIndexNamesAsync(cancellationToken)
            .AnyAsync(name => name == _options.IndexName, cancellationToken))
        {
            _logger.LogInformation("Azure AI Search index already exists.");
            return;
        }

        var fields = new List<SearchField>
        {
            new SimpleField(nameof(DocumentChunk.Id), SearchFieldDataType.String)
            {
                IsKey = true,
                IsFilterable = true
            },

            new SearchableField(nameof(DocumentChunk.DocumentName))
            {
                IsFilterable = true
            },

            new SimpleField(nameof(DocumentChunk.ChunkNumber), SearchFieldDataType.Int32)
            {
                IsFilterable = true,
                IsSortable = true
            },

            new SearchableField(nameof(DocumentChunk.Content))
            {
                AnalyzerName = LexicalAnalyzerName.EnLucene
            },

            new SearchField(nameof(DocumentChunk.Embedding),
                SearchFieldDataType.Collection(SearchFieldDataType.Single))
            {
                IsSearchable = true,
                VectorSearchDimensions = 1536,
                VectorSearchProfileName = "vector-profile"
            }
        };

        var index = new SearchIndex(_options.IndexName)
        {
            Fields = fields,

            VectorSearch = new VectorSearch
            {
                Algorithms =
                {
                    new HnswAlgorithmConfiguration("hnsw")
                },

                Profiles =
                {
                    new VectorSearchProfile("vector-profile", "hnsw")
                }
            }
        };

        await indexClient.CreateIndexAsync(index, cancellationToken);

        _logger.LogInformation(
            "Azure AI Search index created successfully.");
    }

    public async Task UploadDocumentsAsync(
        IReadOnlyList<DocumentChunk> chunks,
        CancellationToken cancellationToken = default)
    {
        var client = CreateSearchClient();

        var result = await client.UploadDocumentsAsync(
            chunks,
            new IndexDocumentsOptions(),
            cancellationToken);

        _logger.LogInformation(
            "Uploaded {Count} chunks to Azure AI Search.",
            result.Value.Results.Count);
    }

    public async Task<IReadOnlyList<DocumentChunk>> SearchAsync(
    string searchText,
    int top = 5,
    CancellationToken cancellationToken = default)
    {
        var client = CreateSearchClient();

        var options = new SearchOptions
        {
            Size = top
        };

        var response = await client.SearchAsync<DocumentChunk>(
            searchText,
            options,
            cancellationToken);

        var documents = new List<DocumentChunk>();

        await foreach (var result in response.Value.GetResultsAsync())
        {
            if (result.Document != null)
            {
                documents.Add(result.Document);
            }
        }

        _logger.LogInformation(
            "Keyword search returned {Count} documents.",
            documents.Count);

        return documents;
    }

    public async Task<IReadOnlyList<DocumentChunk>> SearchByVectorAsync(
    string query,
    int top = 5,
    CancellationToken cancellationToken = default)
    {
        // Create Azure AI Search client
        var client = CreateSearchClient();

        // Step 1: Convert the user's query into an embedding
        var queryEmbedding = await _embeddingService.GenerateEmbeddingAsync(
            query,
            cancellationToken: cancellationToken);

        // Step 2: Create vector query
        var vectorQuery = new VectorizedQuery(queryEmbedding)
        {
            KNearestNeighborsCount = top
        };

        vectorQuery.Fields.Add(nameof(DocumentChunk.Embedding));

        // Step 3: Configure search options
        var searchOptions = new SearchOptions
        {
            Size = top
        };

        searchOptions.VectorSearch = new VectorSearchOptions();
        searchOptions.VectorSearch.Queries.Add(vectorQuery);

        // Step 4: Execute vector search
        var response = await client.SearchAsync<DocumentChunk>(
            searchText: null,
            options: searchOptions,
            cancellationToken: cancellationToken);

        // Step 5: Read results
        var documents = new List<DocumentChunk>();

        await foreach (var result in response.Value.GetResultsAsync())
        {
            if (result.Document != null)
            {
                documents.Add(result.Document);
            }
        }

        _logger.LogInformation(
            "Vector search returned {Count} documents.",
            documents.Count);

        return documents;
    }

    public async Task<IReadOnlyList<DocumentChunk>> HybridSearchAsync(
    string query,
    int top = 5,
    CancellationToken cancellationToken = default)
    {
        var client = CreateSearchClient();

        // 1. Generate embedding for the query
        var queryEmbedding = await _embeddingService.GenerateEmbeddingAsync(
            query,
            cancellationToken: cancellationToken);

        // 2. Create vector query
        var vectorQuery = new VectorizedQuery(queryEmbedding)
        {
            KNearestNeighborsCount = top
        };

        vectorQuery.Fields.Add(nameof(DocumentChunk.Embedding));

        // 3. Configure HYBRID search options
        var options = new SearchOptions
        {
            Size = top
        };

        options.VectorSearch = new VectorSearchOptions();
        options.VectorSearch.Queries.Add(vectorQuery);

        // 4. Execute BOTH keyword + vector search
        var response = await client.SearchAsync<DocumentChunk>(
            searchText: query,
            options: options,
            cancellationToken: cancellationToken);

        // 5. Read results
        var documents = new List<DocumentChunk>();

        await foreach (var result in response.Value.GetResultsAsync())
        {
            if (result.Document != null)
            {
                documents.Add(result.Document);
            }
        }

        _logger.LogInformation(
            "Hybrid search returned {Count} documents.",
            documents.Count);

        return documents;
    }
}