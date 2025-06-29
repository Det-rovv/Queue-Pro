using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Queue_Pro.Domain.Abstractions;
using Queue_Pro.Infrastructure.Repositories;

namespace Queue_Pro.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddDbContext<AppDbContext>(options => 
        {
            options.UseNpgsql(configuration.GetConnectionString(nameof(AppDbContext)));
        }).AddScoped<IUsersRepository, UsersRepository>();
    }
}