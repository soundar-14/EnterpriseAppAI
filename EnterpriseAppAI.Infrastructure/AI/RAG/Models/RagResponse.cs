using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAppAI.Infrastructure.AI.RAG.Models
{
    public sealed class RagResponse
    {
        public string Answer { get; init; } = string.Empty;

        public List<RagSource> Sources { get; init; } = [];
    }

}
