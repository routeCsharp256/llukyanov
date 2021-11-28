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
        /// <param name="employeeEmail">Email сотрудника</param>
        /// <param name="employeeEventId">ID события, связанного с сотрудником</param>
        /// <param name="merchPackId">ID мерч-пака</param>
        /// <param name="cancellationToken">Токен для отмены операции<see cref="CancellationToken" /></param>
        /// <returns></returns>
        Task<bool> CheckIsMerchPackReceivedAsync(string employeeEmail, int employeeEventId, int merchPackId,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Отправка сообщения сотруднику о подготовленном заказе мерча
        /// </summary>
        /// <param name="employeeEmail">Email сотрудника</param>
        /// <param name="cancellationToken">Токен для отмены операции<see cref="CancellationToken" /></param>
        /// <returns></returns>
        Task NotifyEmployeeAboutMerchAsync(string employeeEmail, CancellationToken cancellationToken = default);
    }
}