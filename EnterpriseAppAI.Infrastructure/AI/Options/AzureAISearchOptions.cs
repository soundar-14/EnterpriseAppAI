namespace EnterpriseAppAI.Infrastructure.AI.Options;

public sealed class AzureAISearchOptions
{
    public const string SectionName = "AzureAISearch";

    public required string Endpoint { get; init; }

    public required string ApiKey { get; init; }

    public required string IndexName { get; init; }
}