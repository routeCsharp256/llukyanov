using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAgregate;
using OzonEdu.MerchandiseService.Domain.Events;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    public class Employee : Entity
    {
        public Employee(
            int id,
            Name firstName,
            Name lastName,
            Name middleName,
            Date birthDate,
            Date hiringDate,
            Email email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            BirthDate = birthDate;
            HiringDate = hiringDate;
            Email = email;
        }

        public int Id { get; }
        public Name FirstName { get; }
        public Name LastName { get; }
        public Name MiddleName { get; }
        public Date BirthDate { get; }
        public Date HiringDate { get; }
        public Email Email { get; }

        private void AddAttendedConferenceAsListenerDomainEvent()
        {
            var attendedConferenceAsListenerDomainEvent = new AttendedConferenceAsListenerDomainEvent();

            AddDomainEvent(attendedConferenceAsListenerDomainEvent);
        }

        private void AddAttendedConferenceAsSpeakerDomainEvent()
        {
            var attendedConferenceAsSpeakerDomainEvent = new AttendedConferenceAsSpeakerDomainEvent();

            AddDomainEvent(attendedConferenceAsSpeakerDomainEvent);
        }

        private void AddBecameVeteranDomainEvent()
        {
            var becameVeteranDomainEvent = new BecameVeteranDomainEvent();

            AddDomainEvent(becameVeteranDomainEvent);
        }

        private void AddHiredDomainEvent()
        {
            var hiredDomainEvent = new HiredDomainEvent();

            AddDomainEvent(hiredDomainEvent);
        }

        private void AddProbationPeriodEndedDomainEvent()
        {
            var probationPeriodEndedDomainEvent = new ProbationPeriodEndedDomainEvent();

            AddDomainEvent(probationPeriodEndedDomainEvent);
        }
    }
}