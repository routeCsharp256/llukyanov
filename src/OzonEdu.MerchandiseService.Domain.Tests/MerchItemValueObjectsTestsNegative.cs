using System;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests
{
    public class MerchItemValueObjectsTestsNegative
    {
        [Fact]
        public void SetDescriptionIncorrect_Empty()
        {
            Assert.Throws<ArgumentNullException>(() => new Description(""));
        }

        [Fact]
        public void SetDescriptionIncorrect_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new Description(null));
        }

        [Fact]
        public void SetNameIncorrect_Empty()
        {
            Assert.Throws<ArgumentNullException>(() => new Name(""));
        }

        [Fact]
        public void SetNameIncorrect_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new Name(null));
        }
    }
}