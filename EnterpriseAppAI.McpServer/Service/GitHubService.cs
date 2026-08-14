using System.Net.Http.Headers;
using EnterpriseAppAI.McpServer.Configuration;
using Microsoft.Extensions.Options;

namespace EnterpriseAppAI.McpServer.Services;

public sealed class GitHubService
{
    private readonly HttpClient _httpClient;
    private readonly GitHubOptions _options;

    public GitHubService(
        HttpClient httpClient,
        IOptions<GitHubOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                "Bearer",
                _options.Token);

        _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue(
                "application/vnd.github+json"));

        _httpClient.DefaultRequestHeaders.UserAgent.Add(
            new ProductInfoHeaderValue(
                "EnterpriseAppAI",
                "1.0"));
    }

    public async Task<string> GetRepositoryAsync(
        string owner,
        string repository,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(owner))
        {
            throw new ArgumentException(
                "GitHub owner is required.",
                nameof(owner));
        }

        if (string.IsNullOrWhiteSpace(repository))
        {
            throw new ArgumentException(
                "GitHub repository is required.",
                nameof(repository));
        }

        var url =
            $"{_options.ApiUrl.TrimEnd('/')}" +
            $"/repos/{owner}/{repository}";

        using var response = await _httpClient.GetAsync(
            url,
            cancellationToken);

        var content =
            await response.Content.ReadAsStringAsync(
                cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(
                $"GitHub API request failed. " +
                $"Status: {(int)response.StatusCode} " +
                $"{response.ReasonPhrase}. " +
                $"Response: {content}");
        }

        return content;
    }

    public async Task<string> GetFileAsync(
        string owner,
        string repository,
        string path,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentException(
                "GitHub file path is required.",
                nameof(path));
        }

        var url =
            $"{_options.ApiUrl.TrimEnd('/')}" +
            $"/repos/{owner}/{repository}/contents/{path}";

        using var response = await _httpClient.GetAsync(
            url,
            cancellationToken);

        var content =
            await response.Content.ReadAsStringAsync(
                cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(
                $"GitHub API request failed. " +
                $"Status: {(int)response.StatusCode} " +
                $"{response.ReasonPhrase}. " +
                $"Response: {content}");
        }

        return content;
    }
}