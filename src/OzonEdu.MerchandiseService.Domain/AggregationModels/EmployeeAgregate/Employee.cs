using System;
using OzonEdu.MerchandiseService.Domain.Events;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using OzonEdu.MerchandiseService.Domain.Models;
using OzonEdu.MerchandiseService.Domain.Tools;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    public class Employee : Entity
    {
        public Employee(
            int id,
            Name firstName,
            Name lastName,
            Name middleName,
            DateTime birthDay,
            DateTime hiringDate,
            Email email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            SetBirthday(birthDay);
            SetHiringDate(hiringDate);
            SetEmail(email);
        }

        public int Id { get; }

        public Name FirstName { get; }

        public Name LastName { get; }
        public Name MiddleName { get; }
        public DateTime BirthDay { get; private set; }
        public DateTime HiringDate { get; private set; }
        public Email Email { get; private set; }

        private void SetBirthday(DateTime birthDay)
        {
            // TODO: добавить проверку на совершеннолетие
            if (birthDay == DateTime.MinValue)
                throw new ArgumentNullException("Birth date is not set");
            if (birthDay >= DateTime.Now)
                throw new ArgumentException(
                    $"Birth date is greater or equal to current date: {birthDay.ToString("yyyy-MM-dd")}");

            BirthDay = birthDay;
        }

        private void SetHiringDate(DateTime hiringDate)
        {
            if (hiringDate == DateTime.MinValue)
                throw new ArgumentNullException("Hiring date is not set");
            if (hiringDate <= BirthDay)
                throw new ArgumentException(
                    $"Hiring date is less or equal to birth date: {hiringDate.ToString("yyyy-MM-dd")}");

            HiringDate = hiringDate;
        }

        private void SetEmail(Email email)
        {
            if (email is null)
                throw new ArgumentNullException("Email is not set");
            if (!Regexes.OzonEmployeeEmailRegex.IsMatch(email.Value))
                throw new RegexException($"Email has wrong format: {email}");

            Email = email;
        }

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