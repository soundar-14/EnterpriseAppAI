using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAppAI.Infrastructure.AI.Options
{
    public sealed class AzureOpenAIOptions
    {
        public const string SectionName = "AzureOpenAI";

        public required string Endpoint { get; init; }

        public required string ApiKey { get; init; }

        public required string ChatDeploymentName { get; init; }

        public required string EmbeddingDeploymentName { get; init; }
    }
}
