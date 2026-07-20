namespace EnterpriseAppAI.Application.Features.Auth.Common;

/// <summary>
/// Response returned after a successful login.
/// </summary>
public record LoginResponse(string Token, DateTime ExpiresAtUtc, string UserName, string Role);
