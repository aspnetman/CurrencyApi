using CurrencyApi.Contracts;
using CurrencyApi.Models;

namespace CurrencyApi.Services.Validators
{
    /// <summary>
    /// Представляет интерфейс валидатора запроса курса валют
    /// </summary>
    public interface ICurrencyRequestValidator
    {
        /// <summary>
        /// Валидирует запрос <see cref="CurrencyRequest"/> курса валют
        /// </summary>
        /// <param name="request">запрос курса валют</param>
        /// <returns>результат проверки</returns>
        ValidationResult Validate(CurrencyRequest request);
    }
}