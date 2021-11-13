using System;
using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Models;
using ServiceStack;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public class Description : ValueObject
    {
        public Description(string description)
        {
            if (description.IsNullOrEmpty())
                throw new ArgumentNullException("Merch item Description is not set");

            Value = description;
        }

        public string Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}