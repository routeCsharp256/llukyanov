using MediatR;
using OzonEdu.MerchandiseService.Infrastructure.Handlers;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    ///     Класс расширений для типа <see cref="IServiceCollection" /> для регистрации инфраструктурных сервисов
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///     Добавление в DI контейнер инфраструктурных сервисов
        /// </summary>
        /// <param name="services">Объект IServiceCollection</param>
        /// <returns>Объект <see cref="IServiceCollection" /></returns>
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // services.AddMediatR(typeof(AttendedConferenceAsListenerDomainEventHandler));
            // services.AddMediatR(typeof(AttendedConferenceAsSpeakerDomainEventHandler));
            // services.AddMediatR(typeof(BecameVeteranDomainEventHandler));
            // services.AddMediatR(typeof(HiredDomainEventHandler));
            // services.AddMediatR(typeof(ProbationPeriodEndedDomainEventHandler));
            services.AddMediatR(typeof(AskMerchCommandHandler).Assembly);
            // services.AddMediatR(typeof(CheckMerchCommandHandler));
            // services.AddMediatR(typeof(NotifyEmployeeCommandHandler));
            // services.AddMediatR(typeof(ReserveMerchCommandHandler));

            return services;
        }

        /// <summary>
        ///     Добавление в DI контейнер инфраструктурных репозиториев
        /// </summary>
        /// <param name="services">Объект IServiceCollection</param>
        /// <returns>Объект <see cref="IServiceCollection" /></returns>
        public static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services)
        {
            return services;
        }
    }
}