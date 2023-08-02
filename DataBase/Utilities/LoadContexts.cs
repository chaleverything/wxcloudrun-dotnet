using DataBase.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace DataBase
{
    public static class LoadContexts
    {
        public static IServiceCollection RegisterContexts(this IServiceCollection services)
        {
            services.AddDbContext<CounterContext>();
            services.AddDbContext<CategorysContext>();
            services.AddDbContext<CommentsContext>();
            services.AddDbContext<GoodsContext>();
            services.AddDbContext<LogContext>();
            services.AddDbContext<MediasContext>();
            services.AddDbContext<SkusContext>();
            services.AddDbContext<SpecsContext>();
            services.AddDbContext<SpecValsContext>();
            services.AddDbContext<StoresContext>();
            services.AddDbContext<TabsContext>();
            return services;
        }
    }
}
