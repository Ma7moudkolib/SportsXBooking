using Application.Mapping;
using Application.ServiceInterfaces;
using Domain.Entities;
using Infrastructure.DatabaseContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

// add identity services
builder.Services.AddIdentity<User, IdentityRole<int>>()
  .AddEntityFrameworkStores<RepositoryContext>()
  .AddDefaultTokenProviders();

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddAuthentication();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.AddControllers();

var app = builder.Build();
var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);
if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<RepositoryContext>();

        if (context.Database.GetPendingMigrations().Any())
        {
            await context.Database.MigrateAsync();
        }
    }
    catch (Exception ex)
    {
        logger.LogError($"An error occurred while migrating the database: {ex.Message}");
    }
}
app.Run();
