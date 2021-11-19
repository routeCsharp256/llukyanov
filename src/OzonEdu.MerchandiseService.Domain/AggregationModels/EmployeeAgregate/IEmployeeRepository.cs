using System.Threading;
using System.Threading.Tasks;
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
        /// <param name="employeeEventTypeId">Идентификатор типа события</param>
        /// <param name="cancellationToken">Токен для отмены операции.<see cref="CancellationToken" /></param>
        /// <returns>Можно ли сотруднику выдавать мерч всвязи с данным событием</returns>
        Task<bool> CheckIsEventMerchReceived(long employeeId, int employeeEventTypeId, 
            CancellationToken cancellationToken = default);

        Task NotifyEmployeeAboutMerch(long employeeId, CancellationToken cancellationToken = default);

        Task UpdateConferencesInfo(CancellationToken cancellationToken = default);
    }
}