using CurrencyApi.Contracts;
using CurrencyApi.Models;

namespace CurrencyApi.Services.Calculators
{
    /// <summary>
    /// Калькулятор даты курса валюты
    /// </summary>
    public interface ICurrencyDateCalculator
    {
        /// <summary>
        /// На основании данных <see cref="CurrencyRequest"/> вычисляет дату курса валюты
        /// </summary>
        /// <param name="request">запрос <see cref="CurrencyRequest"/> для вычисления даты курса валюты</param>
        /// <returns>результат вычисления <see cref="CurrencyDateCalculationResult"/></returns>
        CurrencyDateCalculationResult Calculate(CurrencyRequest request);
    }
}