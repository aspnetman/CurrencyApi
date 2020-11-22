using CurrencyApi.Contracts;
using CurrencyApi.Models;
using CurrencyApi.Services.Validators;

using NUnit.Framework;

namespace CurrencyApi.Tests.Services.Validators
{
    public class CoordinateInCircleCurrencyRequestValidatorTest
    {
        [Test]
        public void TestCoordinateInCircle()
        {
            // Arrange
            CoordinateInCircleCurrencyRequestValidator validator = new CoordinateInCircleCurrencyRequestValidator(8, 0, 0);
            CurrencyRequest request = new CurrencyRequest { Y = 1, X = 1, Code = "AUD" };
            
            // Act
            ValidationResult result = validator.Validate(request);

            // Assert
            Assert.True(result.Success);
        }

        [Test]
        public void TestCoordinateNotInCircle()
        {
            // Arrange
            CoordinateInCircleCurrencyRequestValidator validator = new CoordinateInCircleCurrencyRequestValidator(8, 0, 0);
            CurrencyRequest request = new CurrencyRequest { Y = 7, X = 8, Code = "AUD" };

            // Act
            ValidationResult result = validator.Validate(request);

            // Assert
            Assert.False(result.Success);
        }
    }
}