using Microsoft.EntityFrameworkCore;
using Queue_Pro.Application;
using Queue_Pro.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services
    .AddOpenApi()
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
