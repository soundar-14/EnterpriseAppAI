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

    public RagTestController(
        IPdfReaderService pdfReaderService,
        IWebHostEnvironment environment,
        ITextChunkingService chunkingService,
        ILogger<RagTestController> logger,
        IEmbeddingService embeddingService)
    {
        _pdfReaderService = pdfReaderService;
        _chunkingService = chunkingService;
        _embeddingService = embeddingService;
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
}