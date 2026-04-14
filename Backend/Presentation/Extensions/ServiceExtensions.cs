using Application.LoggerService;
using Application.ServiceInterfaces;
using Application.Services;
using Infrastructure.DatabaseContext;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Presentation.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) => services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options => { });

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
           services.AddScoped<IRepositoryManager, RepositoryManager>();
        public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
           services.AddDbContext<RepositoryContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = configuration.GetSection("secretKey").Value;

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidAudience = jwtSettings["validAudience"],
                    ValidIssuer = jwtSettings["validIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!))
                };
            });
        } 
    }
}
