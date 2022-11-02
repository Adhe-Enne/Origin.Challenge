using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Origin.DatabaseContext;

namespace Origin.DatabaseContext.IoC 
{ 
    public static class Startup
    {
            public static void AddDatabaseContext(this IServiceCollection services, string connectionString)
            {
                services.AddDbContext<OriginDbContext>(c => c.UseSqlServer(connectionString));
            }
    }
}