using Dining.Domain.Users;

namespace Dining.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);