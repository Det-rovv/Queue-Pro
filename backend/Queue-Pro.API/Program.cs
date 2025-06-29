using Microsoft.EntityFrameworkCore;
using Queue_Pro.Application;
using Queue_Pro.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services
    .AddProblemDetails()
    .AddInfrastructure(configuration)
    .AddApplication()
    .AddControllers();

var app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();

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

app.MapControllers();

app.Run();
