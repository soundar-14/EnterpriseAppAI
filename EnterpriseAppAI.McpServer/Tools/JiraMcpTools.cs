using EnterpriseAppAI.McpServer.Services;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace EnterpriseAppAI.McpServer.Tools;

[McpServerToolType]
public sealed class JiraMcpTools
{
    private readonly JiraService _jiraService;

    public JiraMcpTools(
        JiraService jiraService)
    {
        _jiraService = jiraService;
    }

    [McpServerTool]
    [Description(
        "Gets a Jira issue by its issue key. " +
        "Use this to retrieve Jira issue details.")]
    public async Task<string> GetJiraIssueAsync(
        [Description(
            "The Jira issue key, for example EPMCDMETST-42534.")]
        string issueKey,
        CancellationToken cancellationToken = default)
    {
        return await _jiraService.GetIssueAsync(
            issueKey,
            cancellationToken);
    }
}