using EnterpriseAppAI.Infrastructure.AI.RAG.Interfaces;
using System.Text;
using UglyToad.PdfPig;

namespace EnterpriseAppAI.Infrastructure.AI.RAG.Services;

/// <summary>
/// Reads text from a PDF document.
/// This service is responsible only for extracting text.
/// </summary>
public sealed class PdfReaderService : IPdfReaderService
{
    public Task<string> ReadTextAsync(
        string filePath,
        CancellationToken cancellationToken = default)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException(
                $"PDF file not found: {filePath}");
        }

        var builder = new StringBuilder();

        using var document = PdfDocument.Open(filePath);

        foreach (var page in document.GetPages())
        {
            cancellationToken.ThrowIfCancellationRequested();

            builder.AppendLine(page.Text);
            builder.AppendLine();
        }

        return Task.FromResult(builder.ToString());
    }
}