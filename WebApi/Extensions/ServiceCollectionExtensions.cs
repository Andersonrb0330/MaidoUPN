namespace WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddWebApiProject(this IServiceCollection services, IConfiguration configuration)
        {

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
    }
}
