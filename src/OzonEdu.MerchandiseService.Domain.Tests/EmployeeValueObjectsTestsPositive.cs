using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests
{
    public class EmployeeValueObjectsTestsPositive
    {
        [Fact]
        public void SetEmail()
        {
            //Arrange
            var expectedEmail = "test@ozon.ru";

            var actualEmail = new Email("test@ozon.ru");

            //Assert
            Assert.Equal(expectedEmail, actualEmail.Value);
        }

        [Fact]
        public void SetEmailToLowerCase()
        {
            var expectedEmail = "test@ozon.ru";

            var actualEmail = new Email("TEsT@OzoN.rU");

            Assert.Equal(expectedEmail, actualEmail.Value);
        }
    }
}