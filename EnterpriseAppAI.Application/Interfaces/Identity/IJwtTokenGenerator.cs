namespace EnterpriseAppAI.Application.Interfaces.Identity;

/// <summary>
/// Generates signed JWT access tokens for authenticated users. Implemented in Infrastructure
/// since token generation is an infrastructure concern (relies on the JWT signing key/config).
/// </summary>
public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userId, string userName, string role);
}
