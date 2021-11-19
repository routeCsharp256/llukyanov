using System;
using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchOrderAggregate
{
    /// <summary>
    ///     Тот же VO Date, только nullable 
    /// </summary>
    public class Date : ValueObject
    {
        public Date(DateTime date)
        {
            if (date == default)
                Value = null;

            Value = date;
        }

        public DateTime? Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}