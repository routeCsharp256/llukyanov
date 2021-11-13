using System;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public IUnitOfWork UnitOfWork { get; }

        public Task<Employee> CreateAsync(Employee itemToCreate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateAsync(Employee itemToUpdate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsEventMerchReceived(long employeeId, int? employeeEventTypeId, Sku sku, Quantity quantity,
            CancellationToken cancellationToken = default)
        {
            // В зависимости от типа события выполнить соответствующий метод проверки выдачи полного комплекта мерча по данному событию
            throw new NotImplementedException();
        }

        public Task NotifyEmployeeAboutMerch(long employeeId, CancellationToken cancellationToken = default)
        {
            // Дёрнуть emailing-service, чтобы он отправил данному сотруднику сообщение, что мерч полностью готов к выдаче
            throw new NotImplementedException();
        }

        public Task<bool> IsAttendedConferenceAsListenerMerch(long employeeId, long conferenceId,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsAttendedConferenceAsSpeakerMerch(long employeeId, long conferenceId,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsEarnedVeteranStatusMerch(long employeeId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsHiredMerch(long employeeId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsProbationPeriodEndedMerch(long employeeId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}