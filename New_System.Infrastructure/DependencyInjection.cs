using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using New_System.Application.Core.Data;
using New_System.Domain.Users;
using New_System.Infrastructure.Database;
using New_System.Infrastructure.Repositories;

namespace New_System.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<AppDbContext>(options =>
        {
            string? connection = configuration.GetConnectionString("Local-SqlServer");

            options.UseSqlServer(connection);
        });

        services.AddScoped<IDbContext>(serviceProvider => serviceProvider.GetRequiredService<AppDbContext>());

        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<AppDbContext>());


        services.AddScoped<IUserRepository, UserRepository>();


        return services;
    }
}
