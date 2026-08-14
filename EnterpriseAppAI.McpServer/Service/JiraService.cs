using System.Net.Http.Headers;
using EnterpriseAppAI.McpServer.Configuration;
using Microsoft.Extensions.Options;

namespace EnterpriseAppAI.McpServer.Services;

public sealed class JiraService
{
    private readonly HttpClient _httpClient;
    private readonly JiraOptions _options;

    public JiraService(
        HttpClient httpClient,
        IOptions<JiraOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                "Bearer",
                _options.ApiToken);

        _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue(
                "application/json"));
    }

    public async Task<string> GetIssueAsync(
        string issueKey,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(issueKey))
        {
            throw new ArgumentException(
                "Jira issue key is required.",
                nameof(issueKey));
        }

        var url =
            $"{_options.BaseUrl.TrimEnd('/')}/rest/api/2/issue/{issueKey}";

        using var response = await _httpClient.GetAsync(
            url,
            cancellationToken);

        var content =
            await response.Content.ReadAsStringAsync(
                cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(
                $"Jira API request failed. " +
                $"Status: {(int)response.StatusCode} " +
                $"{response.ReasonPhrase}. " +
                $"Response: {content}");
        }

        return content;
    }
}