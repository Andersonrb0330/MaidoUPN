using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Persistence.Context
{
    public class MaidoContextDesingTimeDbContextFactory : IDesignTimeDbContextFactory<MaidoContext>
    {
        public MaidoContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WebApi"))
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("appsetting.Development.json", optional: true)
            .Build();

            var optionsBuilder = new DbContextOptionsBuilder<MaidoContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("SqlMaido"));

            return new MaidoContext(optionsBuilder.Options);
        }
    }
}
