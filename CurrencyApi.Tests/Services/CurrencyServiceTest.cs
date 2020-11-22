using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CurrencyApi.Contracts;
using CurrencyApi.Models;
using CurrencyApi.Services;
using CurrencyApi.Services.Calculators;

using Microsoft.Extensions.Logging;

using Moq;

using NUnit.Framework;

namespace CurrencyApi.Tests.Services
{
    /// <summary>
    /// Тесты для сервиса валют
    /// </summary>
    public class CurrencyServiceTest
    {
        /// <summary>
        /// Проверяем ситуацию когда при получении курса валют нам не удалось получить дату для получения курса
        /// </summary>
        [Test]
        public static async Task TestGetRateWhenCurrencyDateCalculationResultNotExists()
        {
            // Arrange
            CurrencyService currencyService = new CurrencyService(GetCurrencyProvider(null, null), GetCurrencyDateCalculator(null), GetLogger());
            CurrencyRequest request = new CurrencyRequest { Code = "AUD", Y = 1, X = 1 };

            // Act
            OperationResult<CurrencyRate> result = await currencyService.GetRate(request);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage) == false);
        }

        /// <summary>
        /// Проверяем ситуацию когда пришли отр
        /// </summary>
        /// <returns></returns>
        [Test]
        public static async Task TestWhenCurrencyDateCalculationResultIsNotSuccess()
        {
            // Arrange
            CurrencyDateCalculationResult currencyDateCalculationResult = new CurrencyDateCalculationResult { Success = false, ErrorMessage = "Fail" };
            CurrencyService currencyService = new CurrencyService(GetCurrencyProvider(null, null), GetCurrencyDateCalculator(currencyDateCalculationResult), GetLogger());
            CurrencyRequest request = new CurrencyRequest { Code = "AUD", Y = 1, X = 1 };

            // Act
            OperationResult<CurrencyRate> result = await currencyService.GetRate(request);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage) == false);
        }


        private static ICurrencyProvider GetCurrencyProvider(CurrencyRate needCurrencyRate, IList<Currency> needCurrencyList)
        {
            Mock<ICurrencyProvider> currencyProvider = new Mock<ICurrencyProvider>();

            currencyProvider.Setup(x => x.GetList())
                .ReturnsAsync(needCurrencyList);

            currencyProvider.Setup(x => x.GetRate(It.IsAny<DateTime>(), It.IsAny<string>()))
                .ReturnsAsync(needCurrencyRate);

            return currencyProvider.Object;
        }

        private static ICurrencyDateCalculator GetCurrencyDateCalculator(CurrencyDateCalculationResult needResult)
        {
            Mock<ICurrencyDateCalculator> currencyDateCalculator = new Mock<ICurrencyDateCalculator>();

            currencyDateCalculator.Setup(x => x.Calculate(It.IsAny<CurrencyRequest>()))
                .Returns(needResult);
            
            return currencyDateCalculator.Object;
        }

        private static ILogger<CurrencyService> GetLogger()
        {
            Mock<ILogger<CurrencyService>> logger = new Mock<ILogger<CurrencyService>>();

            return logger.Object;
        }
    }
}