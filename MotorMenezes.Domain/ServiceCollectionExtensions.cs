using Microsoft.Extensions.DependencyInjection;
using MotorMenezes.Core.ApplicationContext;
using MotorMenezes.Core.AWS.Interfaces;
using MotorMenezes.Core.AWS.Services;
using MotorMenezes.Core.Helpers;
using MotorMenezes.Core.RabbitMQ;
using MotorMenezes.Domain.Aggregates.CNHTypeAgg.Interfaces;
using MotorMenezes.Domain.Aggregates.CNHTypeAgg.Services;
using MotorMenezes.Domain.Aggregates.MotorcycleAgg.Interfaces;
using MotorMenezes.Domain.Aggregates.MotorcycleAgg.Services;
using MotorMenezes.Domain.Aggregates.PlanAgg.Interfaces;
using MotorMenezes.Domain.Aggregates.PlanAgg.Services;
using MotorMenezes.Domain.Aggregates.RentalAgg.Interfaces;
using MotorMenezes.Domain.Aggregates.RentalAgg.Services;
using MotorMenezes.Domain.Aggregates.UserAgg.Interfaces;
using MotorMenezes.Domain.Aggregates.UserAgg.Services;
using MotorMenezes.Domain.Host;

namespace MotorMenezes.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IRentalServices, RentalServices>();
            services.AddScoped<ICNHTypeServices, CNHTypeServices>();
            services.AddScoped<IPlanServices, PlanServices>();
            services.AddScoped<IMotorcycleServices, MotorcycleServices>();

            services.AddScoped<RabbitMQServices>();

            services.AddScoped<IS3Services, S3Services>();
            services.AddScoped<IMotorMenezesContext, MotorMenezesContext>();
            services.AddScoped<GlobalVariables>();
            services.AddHostedService<QueueConsumer>();

            return services;
        }
    }
}
