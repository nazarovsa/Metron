using Autofac;

namespace Metron.Extensions
{
    public static class AutofacExtensions
    {
        public static ContainerBuilder AddMetronScoped<TModel, TRepository>(this ContainerBuilder builder)
            where TModel : Model
            where TRepository : IModelRepository<TModel>
        {
            builder.RegisterType<Metron<TModel>>()
                .As<Metron<TModel>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TRepository>()
                .As<IModelRepository<TModel>>()
                .InstancePerLifetimeScope();

            return builder;
        }
    }
}