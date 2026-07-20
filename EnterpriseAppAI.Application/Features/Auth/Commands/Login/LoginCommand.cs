using EnterpriseAppAI.Application.Features.Auth.Common;
using MediatR;

namespace EnterpriseAppAI.Application.Features.Auth.Commands.Login;

public record LoginCommand(string UserName, string Password) : IRequest<LoginResponse>;
