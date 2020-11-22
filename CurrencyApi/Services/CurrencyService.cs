using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CurrencyApi.Contracts;
using CurrencyApi.Models;
using CurrencyApi.Services.Calculators;

using Microsoft.Extensions.Logging;

namespace CurrencyApi.Services
{
    /// <summary>
    /// Сервис валют
    /// </summary>
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyProvider currencyProvider;

        private readonly ICurrencyDateCalculator currencyDateCalculator;

        private readonly ILogger<CurrencyService> logger;

        public CurrencyService(ICurrencyProvider currencyProvider, ICurrencyDateCalculator currencyDateCalculator, ILogger<CurrencyService> logger)
        {
            this.currencyProvider = currencyProvider;
            this.currencyDateCalculator = currencyDateCalculator;
            this.logger = logger;
        }

        /// <inheritdoc />
        public async Task<OperationResult<IList<Currency>>> GetList()
        {
            try
            {
                IList<Currency> result = await this.currencyProvider.GetList();

                return new OperationResult<IList<Currency>>
                           {
                               Result = result,
                               Success = true
                           };
            }
            catch (Exception e)
            {
                this.logger.LogError(e, "Произошла ошибка при получении списка валют");

                return new OperationResult<IList<Currency>>
                           {
                               Success = false,
                               ErrorMessage = "Произошла ошибка при получении списка валют"
                           };
            }
        }

        /// <inheritdoc />
        public async Task<OperationResult<CurrencyRate>> GetRate(CurrencyRequest request)
        {
            try
            {
                CurrencyDateCalculationResult currencyDateCalculationResult = this.currencyDateCalculator.Calculate(request);

                if (currencyDateCalculationResult == null)
                {
                    return OperationResult<CurrencyRate>.FromFail("Не удалось получить результат проверки запроса курса валюты");
                }

                if (currencyDateCalculationResult.Success == false || currencyDateCalculationResult.Date.HasValue == false)
                {
                    return OperationResult<CurrencyRate>.FromFail(currencyDateCalculationResult.ErrorMessage);
                }

                CurrencyRate currencyRate = await this.currencyProvider.GetRate(currencyDateCalculationResult.Date.Value, request.Code);

                return currencyRate != null ? OperationResult<CurrencyRate>.FromSuccess(currencyRate) : OperationResult<CurrencyRate>.FromFail("Не удалось получить курс валюты");
            }
            catch (Exception e)
            {
                this.logger.LogError(e, "Произошла ошибка при получении курса валюты");

                return OperationResult<CurrencyRate>.FromFail("Произошла ошибка при получении курса валюты");
            }
        }
    }
}