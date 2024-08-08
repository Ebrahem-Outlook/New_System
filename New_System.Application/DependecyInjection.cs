using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using New_System.Application.Core.Behaviors;
using System.Reflection;

namespace New_System.Application;

public static class DependecyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());

            config.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
