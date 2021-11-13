using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public class Quantity : ValueObject
    {
        public Quantity(int value = 1)
        {
            if (value < 0)
                throw new NegativeValueException($"Merch item Quantity value is negative: {nameof(value)}");

            Value = value;
        }

        public int Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }

    public class QuantityValue : ValueObject
    {
        public QuantityValue(int? value)
        {
            Value = value;
        }

        public int? Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}