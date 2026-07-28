namespace EnterpriseAppAI.Infrastructure.AI.RAG.Interfaces
{
    public interface IPdfReaderService
    {
        Task<string> ReadTextAsync(
            string filePath,
            CancellationToken cancellationToken = default);
    }
}
