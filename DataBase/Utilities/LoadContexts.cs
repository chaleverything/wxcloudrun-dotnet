using Microsoft.Extensions.DependencyInjection;

namespace DataBase
{
    public static class LoadContexts
    {
        public static IServiceCollection RegisterContexts(this IServiceCollection services)
        {
            services.AddDbContext<CounterContext>();
            services.AddDbContext<LogContext>();
            return services;
        }
    }
}
