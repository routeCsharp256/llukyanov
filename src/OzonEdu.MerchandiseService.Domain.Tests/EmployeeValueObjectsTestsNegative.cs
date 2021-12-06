using System;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAgregate;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests
{
    public class EmployeeValueObjectsTestsNegative
    {
        [Fact]
        public void SetEmailIncorrect_WrongCountryDomain()
        {
            Assert.Throws<RegexNotMatchException>(() => new Email("test@ozon.unk"));
        }

        [Fact]
        public void SetEmailIncorrect_WrongCompanyDomain()
        {
            Assert.Throws<RegexNotMatchException>(() => new Email("test@wildberries.ru"));
        }

        [Fact]
        public void SetEmailIncorrect_BadCharsInName()
        {
            Assert.Throws<RegexNotMatchException>(() => new Email("te$t@ozon.ru"));
        }

        [Fact]
        public void SetEmailIncorrect_ExtraSymbols()
        {
            Assert.Throws<RegexNotMatchException>(() => new Email("hello! test@ozon.ru sincerely yours"));
        }

        [Fact]
        public void SetEmailIncorrect_CyrillicSymbols()
        {
            Assert.Throws<RegexNotMatchException>(() => new Email("тест@ozon.ru"));
        }

        [Fact]
        public void SetEmailIncorrect_Empty()
        {
            Assert.Throws<ArgumentNullException>(() => new Email(""));
        }

        [Fact]
        public void SetEmailIncorrect_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new Email(null));
        }

        [Fact]
        public void SetDateDefault()
        {
            Assert.Throws<ArgumentNullException>(() => new Date(default));
        }
    }
}