using Microsoft.SemanticKernel;

namespace EnterpriseAppAI.Infrastructure.AI.RAG.Services;

public sealed class HRAssistantPromptService
{
    private readonly Kernel _kernel;
    private readonly KernelFunction _promptFunction;

    public HRAssistantPromptService(Kernel kernel)
    {
        _kernel = kernel;

        var promptPath = Path.Combine(
            AppContext.BaseDirectory,
            "AI",
            "RAG",
            "Prompts",
            "HRAssistantPrompt.txt");

        if (!File.Exists(promptPath))
        {
            throw new FileNotFoundException(
                "HR Assistant prompt template was not found.",
                promptPath);
        }

        var promptTemplate = File.ReadAllText(promptPath);

        _promptFunction = _kernel.CreateFunctionFromPrompt(
            promptTemplate);
    }

    public async Task<FunctionResult> InvokeAsync(
        string context,
        string question,
        CancellationToken cancellationToken = default)
    {
        var arguments = new KernelArguments
        {
            ["context"] = context,
            ["question"] = question
        };

        return await _kernel.InvokeAsync(
            _promptFunction,
            arguments,
            cancellationToken);
    }
}