namespace EnterpriseAppAI.Application.AI.Models;

/// <summary>
/// Defines the role of a message in a conversation.
/// Supports progression from simple chat to advanced AI agents.
/// </summary>
public enum MessageRole
{
    /// <summary>
    /// System prompt or instructions (e.g., "You are an enterprise assistant")
    /// </summary>
    System = 0,

    /// <summary>
    /// Message from the user/human
    /// </summary>
    User = 1,

    /// <summary>
    /// Response from the AI assistant
    /// </summary>
    Assistant = 2,

    /// <summary>
    /// Tool/function execution result (for function calling and agents)
    /// </summary>
    Tool = 3
}
