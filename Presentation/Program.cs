using Application.Mapping;
using Application.ServiceInterfaces;
using Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddControllers();

var app = builder.Build();
var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);
if(app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
