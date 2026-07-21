namespace EnterpriseAppAI.Application.AI.Models;

public class ChatRequest
{
    public string UserMessage { get; set; } = string.Empty;
    public List<ChatMessage> ConversationHistory { get; set; } = [];
    
    // Future extensibility (commented out for now, but shows where we'll add features)
    // public List<ChatAttachment> Attachments { get; set; } = [];
    // public string? SessionId { get; set; }
    // public Dictionary<string, string> ModelOptions { get; set; } = [];
}
