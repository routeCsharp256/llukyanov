using System;
using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Models;
using ServiceStack;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public class Name : ValueObject
    {
        public Name(string name)
        {
            if (name.IsNullOrEmpty())
                throw new ArgumentNullException("Merch item Name is not set");

            Value = name;
        }

        public string Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}