using ModelContextProtocol.Server;

namespace EnterpriseAppAI.McpServer.Prompts;

[McpServerPromptType]
public sealed class HRAssistantPrompt
{
    [McpServerPrompt(
        Name = "hr_assistant")]
    public string GetPrompt()
    {
        return """
               You are an intelligent HR assistant.

               Answer the user's question using only approved HR information.

               Do not invent or assume HR policies.

               If the required information is not available,
               clearly say that the information could not be found.

               Be concise, professional, and helpful.
               """;
    }
}