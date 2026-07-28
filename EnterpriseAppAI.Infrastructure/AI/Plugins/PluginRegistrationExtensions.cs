using EnterpriseAppAI.Infrastructure.AI.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

namespace EnterpriseAppAI.Infrastructure.AI.Plugins;

public static class PluginRegistrationExtensions
{
    public static Kernel RegisterPlugins(
        this Kernel kernel,
        IServiceProvider serviceProvider)
    {
        var plugins = serviceProvider.GetServices<IAIPlugin>();

        foreach (var plugin in plugins)
        {
            kernel.Plugins.AddFromObject(plugin);
        }

        return kernel;
    }
}

//internal static class PluginRegistrationExtensions
//{
//    public static Kernel RegisterPlugins(
//        this Kernel kernel,
//        IServiceProvider serviceProvider)
//    {
//        kernel.Plugins.AddFromObject(
//            serviceProvider.GetRequiredService<EmployeePlugin>());

//        return kernel;
//    }
//}