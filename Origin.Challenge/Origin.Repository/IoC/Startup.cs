using Origin.Model;
using Microsoft.Extensions.DependencyInjection;
using Core.Abstractions;
using Origin.Repository.Interfaces;

namespace Origin.Repository.IoC
{
    public static class Startup
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<Account>), typeof(Repository<Account>));
            services.AddScoped(typeof(IRepository<Card>), typeof(Repository<Card>));
            services.AddScoped(typeof(IRepository<Movement>), typeof(Repository<Movement>));

            services.AddScoped(typeof(ICardRepository), typeof(CardRepository));
        }
    }
}
