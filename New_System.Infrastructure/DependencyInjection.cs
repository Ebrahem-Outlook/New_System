

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using New_System.Application.Core.Data;
using New_System.Domain.Products;
using New_System.Domain.Users;
using New_System.Infrastructure.Caching;
using New_System.Infrastructure.Database;
using New_System.Infrastructure.Emails.Settings;
using New_System.Infrastructure.Repositories;

namespace New_System.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        // Add EFCore with Database Provider..
        services.AddDbContext<AppDbContext>(options =>
        {
            string? connection = configuration.GetConnectionString("Local-SqlServer");

            options.UseSqlServer(connection);
        });

        services.AddScoped<IDbContext>(serviceProvider => serviceProvider.GetRequiredService<AppDbContext>());

        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<AppDbContext>());


        // Add Caching.
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("Redis");
        });


        // Add User Repository.
        services.AddScoped<UserRepository>();

        // Cached User Repository.
        services.AddScoped<IUserRepository>(serviceProvider =>
        {
            var cache = serviceProvider.GetRequiredService<IDistributedCache>();

            var decorated = serviceProvider.GetRequiredService<UserRepository>();

            return new CachedUserRepository(cache, decorated);
        });


        // Add Product Repository.
        services.AddScoped<ProductRepository>();

        // Cached Product Repository.
        services.AddScoped<IProductRepository>(serviceProvider =>
        {
            var cache = serviceProvider.GetRequiredService<IDistributedCache>();

            var decorated = serviceProvider.GetRequiredService<ProductRepository>();

            return new CachedProductRepository(cache, decorated);
        });


        services.Configure<EmailSettings>(configuration.GetSection("df"));

        
        return services;
    }
}
