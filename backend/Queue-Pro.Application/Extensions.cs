using Microsoft.Extensions.DependencyInjection;
using Queue_Pro.Application.Services;
using Queue_Pro.Domain.Abstractions;

namespace Queue_Pro.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services
            .AddScoped<IUsersService, UsersService>();
    }
}