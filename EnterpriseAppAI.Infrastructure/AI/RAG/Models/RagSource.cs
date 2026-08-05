using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAppAI.Infrastructure.AI.RAG.Models
{
    public sealed class RagSource
    {
        public string DocumentName { get; init; } = string.Empty;

        public int ChunkNumber { get; init; }
    }
}
