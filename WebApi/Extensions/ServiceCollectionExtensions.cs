using Application.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddWebApiProject(this IServiceCollection services, IConfiguration configuration)
        {
            //services.SetJwtConfig(configuration);
            SetCors(services);
        }

        public static void SetCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });
        }

        //private static IServiceCollection SetJwtConfig(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.Configure<JwtConfig>(configuration.GetSection("Security:JwtConfig"));

        //    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //        .AddJwtBearer(options =>
        //        {
        //            var jwtConfig = configuration.GetSection("Security:JwtConfig").Get<JwtConfig>()!;
        //            options.TokenValidationParameters = new TokenValidationParameters
        //            {
        //                ValidateIssuer = true,
        //                ValidateAudience = true,
        //                ValidateLifetime = true,
        //                ValidateIssuerSigningKey = true,
        //                ValidIssuer = jwtConfig.Issuer,
        //                ValidAudience = jwtConfig.Audience,
        //                IssuerSigningKey = new SymmetricSecurityKey(
        //                    Encoding.UTF8.GetBytes(jwtConfig.Key)),
        //                ClockSkew = TimeSpan.Zero
        //            };
        //            options.Events = new JwtBearerEvents
        //            {
        //                OnAuthenticationFailed = context =>
        //                {
        //                    Console.WriteLine($"Error de autenticación JWT: {context.Exception.Message}");
        //                    return Task.CompletedTask;
        //                }
        //            };
        //        });
        //    return services;
        //}
    }
}
