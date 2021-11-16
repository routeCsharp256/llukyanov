using System;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAgregate;
using OzonEdu.MerchandiseService.Domain.Events;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    public class Employee : Entity
    {
        // TODO: вообще лучше смотреть не по дням, а по месяцам/годам
        private int DaysToVeteran { get; } = 1500;
        
        private int ProbationPeriod { get; } = 90;
            
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


        // только не совсем понял, как эти проверки должны вызываться...
        public void CheckVeteran()
        {
            if (DateTime.Now.Subtract(HiringDate.Value).Days >= DaysToVeteran)
                AddBecameVeteranDomainEvent(Id);
        }
        
        public void CheckProbationPeriod()
        {
            if (DateTime.Now.Subtract(HiringDate.Value).Days >= ProbationPeriod)
                AddProbationPeriodEndedDomainEvent(Id);
        }
        
        public void CheckConferenceAsListener()
        {
            // 1. получаем конференции методом /api/conferences/getall
            // 2. (не нашёл в доках API, как получить конференций и для сотрудника, а также статус - слушатель или говоритель)
            ///// видимо, тогда лезем в БД и достаём это всё
        }
        
        public void CheckConferenceAsSpeaker()
        {
            // 1. получаем конференции методом /api/conferences/getall
            // 2. (не нашёл в доках API, как получить конференций и для сотрудника, а также статус - слушатель или говоритель)
            ///// видимо, тогда лезем в БД и достаём это всё
        }
        
        public void SetHired()
        {
            AddHiredDomainEvent(Id); 
        }

        private void AddAttendedConferenceAsListenerDomainEvent(int employeeId)
        {
            var attendedConferenceAsListenerDomainEvent = new AttendedConferenceAsListenerDomainEvent(employeeId);

            this.AddDomainEvent(attendedConferenceAsListenerDomainEvent);
        }

        private void AddAttendedConferenceAsSpeakerDomainEvent(int employeeId)
        {
            var attendedConferenceAsSpeakerDomainEvent = new AttendedConferenceAsSpeakerDomainEvent(employeeId);

            this.AddDomainEvent(attendedConferenceAsSpeakerDomainEvent);
        }

        private void AddBecameVeteranDomainEvent(int employeeId)
        {
            var becameVeteranDomainEvent = new BecameVeteranDomainEvent(employeeId);

            this.AddDomainEvent(becameVeteranDomainEvent);
        }

        private void AddHiredDomainEvent(int employeeId)
        {
            var hiredDomainEvent = new HiredDomainEvent(employeeId);

            this.AddDomainEvent(hiredDomainEvent);
        }

        private void AddProbationPeriodEndedDomainEvent(int employeeId)
        {
            var probationPeriodEndedDomainEvent = new ProbationPeriodEndedDomainEvent(employeeId);

            this.AddDomainEvent(probationPeriodEndedDomainEvent);
        }
    }
}