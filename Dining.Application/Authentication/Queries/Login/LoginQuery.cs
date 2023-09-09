using Dining.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Dining.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;