using System;

using CurrencyApi.Contracts;

namespace CurrencyApi.Services.Validators
{
    /// <summary>
    /// Проверяет, что курс не на завтра(нет смысла обращаться к сервису, если заведомо известно, что он ничего не вернёт)
    /// </summary>
    public class NotTomorrowCurrencyRequestDateValidator : ICurrencyRequestDateValidator
    {
        /// <inheritdoc />
        public ValidationResult Validate(DateTime date)
        {
            if (date == DateTime.Today.AddDays(1))
            {
                return new ValidationResult
                           {
                               ErrorMessage = "Нельзя запросить курс валют на завтра",
                               Success = false
                           };
            }

            return new ValidationResult
                       {
                           Success = true
                       };
        }
    }
}