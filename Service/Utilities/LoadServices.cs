using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Service
{
    public static class LoadServices
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(RegisterMappers));

#pragma warning disable CS8602 // 解引用可能出现空引用。
            services.Scan(scan => scan
                .FromAssembliesOf(typeof(LoadServices))
                    .AddClasses(classes => classes.InNamespaces("Service.Instance"))
                        .UsingRegistrationStrategy(RegistrationStrategy.Replace(ReplacementBehavior.ServiceType))
                        .AsMatchingInterface()
                        .WithScopedLifetime()

                    .AddClasses(classes => classes.Where(type => type.Namespace.Equals("Service.Instance") &&
                                                                type.Name.EndsWith("LoadServices")))
                        .UsingRegistrationStrategy(RegistrationStrategy.Replace(ReplacementBehavior.ServiceType))
                        .AsImplementedInterfaces()
                        .WithScopedLifetime());
#pragma warning restore CS8602 // 解引用可能出现空引用。
            return services;
        }
    }
}
