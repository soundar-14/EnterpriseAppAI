namespace EnterpriseAppAI.Application.AI.Models;

/// <summary>
/// Represents a single message in a chat conversation.
/// Can be a user message, assistant response, system prompt, or tool result.
/// </summary>
public class ChatMessage
{
    /// <summary>
    /// The role of who/what sent this message.
    /// </summary>
    public MessageRole Role { get; set; }

    /// <summary>
    /// The content of the message.
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// When this message was created (UTC).
    /// Used for logging, auditing, and chat history ordering.
    /// </summary>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
