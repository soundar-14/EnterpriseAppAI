using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace EnterpriseAppAI.Infrastructure.AI.Services;

internal static class ChatExecutionSettingsFactory
{
    public static OpenAIPromptExecutionSettings Create()
    {
        return new OpenAIPromptExecutionSettings
        {
            FunctionChoiceBehavior = FunctionChoiceBehavior.Auto(),

            Temperature = 0.2
        };
    }
}