using Microsoft.Extensions.DependencyInjection;

namespace Metron.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMetronScoped<TModel, TRepository>(this IServiceCollection services)
            where TModel : Model
            where TRepository : IModelRepository<TModel>
        {
            services.AddScoped<Metron<TModel>>();
            services.AddScoped(typeof(IModelRepository<TModel>), typeof(TRepository));

            return services;
        }
    }
}