using System;
using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.OrderAggregate
{
    public class NullableDate : ValueObject
    {
        public NullableDate(DateTime date)
        {
            if (date == default)
                Value = null;

            Value = date.Date;
        }

        public DateTime? Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}