using Microsoft.EntityFrameworkCore;
using Queue_Pro.Application;
using Queue_Pro.Application.Services;
using Queue_Pro.Application.Settings;
using Queue_Pro.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

    
builder.Services
    .AddScoped<JwtService>()
    .AddOpenApi()
    .AddProblemDetails()
    .AddAuth(configuration)
    .AddInfrastructure(configuration)
    .AddApplication()
    .AddControllers();

builder.Services
    .Configure<AuthSettings>(configuration.GetSection("AuthSettings"));

var app = builder.Build();

app.UseExceptionHandler()
    .UseStatusCodePages()
    .UseAuthentication()
    .UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    
    try
    {
        // Применяем все pending миграции
        await dbContext.Database.MigrateAsync();
        Console.WriteLine("Миграции успешно применены");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка при применении миграций: {ex.Message}");
        throw;
    }
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1");
    });
}

app.MapControllers();

app.Run();
