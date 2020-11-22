using System;

using CurrencyApi.Contracts;

namespace CurrencyApi.Services.Validators
{
    /// <summary>
    /// Представляет интерфейс валидатора вычисленной даты курса
    /// </summary>
    public interface ICurrencyRequestDateValidator
    {
        /// <summary>
        /// Проверяет дату курса
        /// </summary>
        /// <param name="date">дата курса</param>
        /// <returns>результат проверки</returns>
        ValidationResult Validate(DateTime date);
    }
}