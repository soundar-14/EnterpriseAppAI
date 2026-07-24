using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

namespace EnterpriseAppAI.Infrastructure.AI.Plugins;

internal static class PluginRegistrationExtensions
{
    public static Kernel RegisterPlugins(
        this Kernel kernel,
        IServiceProvider serviceProvider)
    {
        kernel.Plugins.AddFromObject(
            serviceProvider.GetRequiredService<EmployeePlugin>());

        return kernel;
    }
}