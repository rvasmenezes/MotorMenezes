using Microsoft.Extensions.DependencyInjection;
using MotorMenezes.Domain.Interfaces;
using MotorMenezes.Infra.Data.Repositories.EntityFramework;
using MotorMenezes.Infra.Data.Repositories.UnitOfWork;

namespace MotorMenezes.Infra.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfraDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseEFRepository<>), typeof(BaseEFRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
