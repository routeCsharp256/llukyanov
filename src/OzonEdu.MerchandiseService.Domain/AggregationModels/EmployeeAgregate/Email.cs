using System;
using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using OzonEdu.MerchandiseService.Domain.Models;
using OzonEdu.MerchandiseService.Domain.Tools;
using ServiceStack;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    public class Email : ValueObject
    {
        public Email(string email)
        {
            if (email.IsNullOrEmpty())
                throw new ArgumentNullException("Email is not set");
            if (!Regexes.OzonEmployeeEmailRegex.IsMatch(email))
                throw new RegexException($"Email has wrong format: {email}");

            Value = email.ToLower();
        }

        public string Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}