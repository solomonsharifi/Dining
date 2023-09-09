using Dining.Api.Common.Errors;
using Dining.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Dining.Api;

public static class DependencyInjectionRegister
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, DiningProblemDetailsFactory>();
        services.AddMappings();
        return services;
    }
}