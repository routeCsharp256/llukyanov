using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    /// <summary>
    ///     Репозиторий для управления <see cref="Employee" />
    /// </summary>
    public interface IEmployeeRepository : IRepository<Employee>
    {
        /// <summary>
        ///     Проверка, получал ли сотрудник мерч в честь какого-то события
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="conferenceId">Идентификатор конференции</param>
        /// <param name="cancellationToken">Токен для отмены операции.<see cref="CancellationToken" /></param>
        /// <returns>Отметка, получал ли сотрудник мерч как слушатель конференции или нет</returns>
        Task<bool> IsEventMerchReceived(long employeeId, int? employeeEventTypeId, Sku sku, Quantity quantity,
            CancellationToken cancellationToken = default);
        
        Task NotifyEmployeeAboutMerch(long employeeId, CancellationToken cancellationToken = default);
    }
}