using EnterpriseAppAI.McpServer.Services;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace EnterpriseAppAI.McpServer.Tools;

[McpServerToolType]
public sealed class GitHubMcpTools
{
    private readonly GitHubService _githubService;

    public GitHubMcpTools(
        GitHubService githubService)
    {
        _githubService = githubService;
    }

    [McpServerTool]
    [Description(
        "Gets information about a GitHub repository. " +
        "Use this to retrieve repository details.")]
    public async Task<string> GetGitHubRepositoryAsync(
        [Description(
            "The GitHub repository owner, for example soundar-14.")]
        string owner,

        [Description(
            "The GitHub repository name, for example FeatureGate.App.")]
        string repository,

        CancellationToken cancellationToken = default)
    {
        return await _githubService.GetRepositoryAsync(
            owner,
            repository,
            cancellationToken);
    }

    [McpServerTool]
    [Description(
        "Gets a file from a GitHub repository. " +
        "Use this to retrieve source code or file contents.")]
    public async Task<string> GetGitHubFileAsync(
        [Description(
            "The GitHub repository owner, for example soundar-14.")]
        string owner,

        [Description(
            "The GitHub repository name, for example FeatureGate.App.")]
        string repository,

        [Description(
            "The path of the file inside the repository, " +
            "for example README.md.")]
        string path,

        CancellationToken cancellationToken = default)
    {
        return await _githubService.GetFileAsync(
            owner,
            repository,
            path,
            cancellationToken);
    }
}