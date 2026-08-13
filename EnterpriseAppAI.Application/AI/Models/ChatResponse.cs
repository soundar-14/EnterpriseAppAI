namespace EnterpriseAppAI.Application.AI.Models;

public class ChatResponse
{
    public string Answer { get; set; } = string.Empty;
    public List<ChatMessage> ConversationHistory { get; set; } = [];
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string? Model { get; set; }
    public int? TokensUsed { get; set; }

    public string? Source { get; set; }

    public string? SourceName { get; set; }
}
