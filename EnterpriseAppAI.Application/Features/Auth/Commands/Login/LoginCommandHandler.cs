using EnterpriseAppAI.Application.Common.Exceptions;
using EnterpriseAppAI.Application.Features.Auth.Common;
using EnterpriseAppAI.Application.Interfaces.Identity;
using MediatR;

namespace EnterpriseAppAI.Application.Features.Auth.Commands.Login;

/// <summary>
/// Validates credentials against a hardcoded demo user list and issues a JWT on success.
/// PLACEHOLDER: there is no Users table/Identity store yet - this will be replaced once a
/// real User entity and password hashing are introduced in a future milestone.
/// </summary>
public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private static readonly IReadOnlyDictionary<string, (string Password, Guid UserId, string Role)> DemoUsers =
        new Dictionary<string, (string, Guid, string)>(StringComparer.OrdinalIgnoreCase)
        {
            ["admin"] = ("Admin@123", Guid.Parse("11111111-1111-1111-1111-111111111111"), "Admin"),
            ["employee"] = ("Employee@123", Guid.Parse("22222222-2222-2222-2222-222222222222"), "Employee")
        };

    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginCommandHandler(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        if (!DemoUsers.TryGetValue(request.UserName, out var user) || user.Password != request.Password)
        {
            throw new UnauthorizedException("Invalid username or password.");
        }

        var token = _jwtTokenGenerator.GenerateToken(user.UserId, request.UserName, user.Role);

        var response = new LoginResponse(token, DateTime.UtcNow.AddMinutes(60), request.UserName, user.Role);

        return Task.FromResult(response);
    }
}
