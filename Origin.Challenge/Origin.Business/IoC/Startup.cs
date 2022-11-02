using Microsoft.Extensions.DependencyInjection;
using Core.Abstractions;
using Origin.Model;
using Origin.Business.Service;
using Origin.Business.Interfaces;

namespace Origin.Business.IoC
{
    public static class Startup
    {
        /// <summary>
        /// Inyeccion de servicios, cada uno realizado dependiendo la necesidad de su operacion.
        /// Tipo IService son servicios de consumo estandar donde la operacion no exige mas logica que la de un filtro.
        /// Tipo IEntityService (ej ICardService), servicios que consumen mucha logica en su operacion ademas de filtros.
        /// </summary>
        /// <param name="services"></param>
        public static void AddBusiness(this IServiceCollection services)
        {
            //Estandar
            services.AddScoped(typeof(IService<Account>), typeof(Service<Account>));
            services.AddScoped(typeof(IService<Card>), typeof(Service<Card>));
            services.AddScoped(typeof(IService<Movement>), typeof(Service<Movement>));

            services.AddScoped(typeof(ICardService), typeof(CardService));
        }
        
    }
}
