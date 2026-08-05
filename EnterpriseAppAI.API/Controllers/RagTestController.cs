using EnterpriseAppAI.Infrastructure.AI.RAG.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseAppAI.API.Controllers;

[ApiController]
[Route("api/rag-test")]
public class RagTestController : ControllerBase
{
    private readonly IPdfReaderService _pdfReaderService;
    private readonly IWebHostEnvironment _environment;
    private readonly ILogger<RagTestController> _logger;
    private readonly ITextChunkingService _chunkingService;
    private readonly IEmbeddingService _embeddingService;
    private readonly IAzureAISearchService _searchService;
    private readonly IRagService _ragService;

    public RagTestController(
        IPdfReaderService pdfReaderService,
        IWebHostEnvironment environment,
        ITextChunkingService chunkingService,
        ILogger<RagTestController> logger,
        IEmbeddingService embeddingService,
        IAzureAISearchService searchService,
        IRagService ragService
        )
    {
        _pdfReaderService = pdfReaderService;
        _chunkingService = chunkingService;
        _embeddingService = embeddingService;
        _searchService = searchService;
        _ragService = ragService;
        _environment = environment;
        _logger = logger;
    }

    [HttpGet("read-pdf")]
    public async Task<IActionResult> ReadPdf()
    {
        var filePath = Path.Combine(
            _environment.ContentRootPath,
            "Documents",
            "HRPolicy.pdf");

        var text = await _pdfReaderService.ReadTextAsync(filePath);

        var chunks = _chunkingService.ChunkDocument(
            "HRPolicy.pdf",
            text);

        await _embeddingService.GenerateEmbeddingsAsync(chunks);

        _logger.LogInformation(
            "Total Chunks Created: {Count}",
            chunks.Count);

        return Ok(new
        {
            Chunks = chunks.Count,
            VectorLength = chunks.First().Embedding.Length,
            FirstFiveValues = chunks.First().Embedding.Take(5)
        });
    }

    [HttpPost("create-index")]
    public async Task<IActionResult> CreateIndex()
    {
        await _searchService.CreateIndexIfNotExistsAsync();

        return Ok("Index created successfully.");
    }


    [HttpPost("upload")]
    public async Task<IActionResult> Upload()
    {
        var filePath = Path.Combine(
            _environment.ContentRootPath,
            "Documents",
            "HRPolicy.pdf");

        // Read PDF
        var text = await _pdfReaderService.ReadTextAsync(filePath);

        // Split into chunks
        var chunks = _chunkingService.ChunkDocument(
            "HRPolicy.pdf",
            text);

        // Generate embeddings
        await _embeddingService.GenerateEmbeddingsAsync(chunks);

        // Upload to Azure AI Search
        await _searchService.UploadDocumentsAsync(chunks);

        return Ok(new
        {
            Uploaded = chunks.Count
        });
    }

    //keyword search
    [HttpGet("search")]
    public async Task<IActionResult> Search(
    [FromQuery] string query)
    {
        var documents = await _searchService.SearchAsync(query);

        return Ok(documents);
    }

    //vector search endpoint for semantic search
    [HttpGet("vector-search")]
    public async Task<IActionResult> VectorSearch(
    [FromQuery] string query,
    [FromQuery] int top = 5)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return BadRequest("Query is required.");
        }

        var results = await _searchService.SearchByVectorAsync(query, top);

        return Ok(results.Select(x => new
        {
            x.Id,
            x.DocumentName,
            x.ChunkNumber,
            x.Content
        }));
    }

    // Hybrid search endpoint combining keyword and vector search

    [HttpGet("hybrid-search")]
    public async Task<IActionResult> HybridSearch(
    [FromQuery] string query,
    [FromQuery] int top = 5)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return BadRequest("Query is required.");
        }

        var results = await _searchService.HybridSearchAsync(query, top);

        return Ok(results.Select(x => new
        {
            x.Id,
            x.DocumentName,
            x.ChunkNumber,
            x.Content
        }));
    }

    // RAG Ask endpoint with semantic search and LLM response
    [HttpGet("ask")]
    public async Task<IActionResult> Ask(
    [FromQuery] string question,
    CancellationToken cancellationToken)
    {
        var answer = await _ragService.AskAsync(
            question,
            cancellationToken);

        return Ok(answer);
    }
}