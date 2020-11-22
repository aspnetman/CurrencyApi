using System;
using System.Collections.Generic;

using CurrencyApi.Contracts;
using CurrencyApi.Models;
using CurrencyApi.Services.Validators;

namespace CurrencyApi.Services.Calculators
{
    /// <summary>
    /// Вычисляет дату курса валюты на основании координаты в декартовой системе координат и принадлежности указанной точки окружности
    /// </summary>
    public class CartesianCoordinateSystemCalculator : ICurrencyDateCalculator
    {
        private readonly IEnumerable<ICurrencyRequestValidator> requestValidators;

        private readonly IEnumerable<ICurrencyRequestDateValidator> dateValidators;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CartesianCoordinateSystemCalculator"/>
        /// </summary>
        /// <param name="requestValidators">валидаторы запроса курса</param>
        /// <param name="dateValidators">валидаторы вычисленной даты курса</param>
        public CartesianCoordinateSystemCalculator(IEnumerable<ICurrencyRequestValidator> requestValidators, IEnumerable<ICurrencyRequestDateValidator> dateValidators)
        {
            this.requestValidators = requestValidators;
            this.dateValidators = dateValidators;
        }

        /// <inheritdoc />
        public CurrencyDateCalculationResult Calculate(CurrencyRequest request)
        {
            if (this.requestValidators != null)
            {
                // проверяем запрос
                foreach (ICurrencyRequestValidator requestValidator in this.requestValidators)
                {
                    ValidationResult result = requestValidator.Validate(request);

                    if (result.Success == false)
                    {
                        return GetFailCalculationResult(result);
                    }
                }
            }

            DateTime dateTime = GetDate(request.X, request.Y);

            if (this.dateValidators == null)
            {
                return GetSuccessCalculationResult(dateTime);
            }

            // проверяем дату
            foreach (ICurrencyRequestDateValidator dateValidator in this.dateValidators)
            {
                ValidationResult result = dateValidator.Validate(dateTime);

                if (result.Success == false)
                {
                    return GetFailCalculationResult(result);
                }
            }

            return GetSuccessCalculationResult(dateTime);
        }

        /// <summary>
        /// Вычисляем дату в зависимости от положения точки
        /// </summary>
        /// <param name="x">координата X точки</param>
        /// <param name="y">координата Y точки</param>
        /// <returns>дата в зависимости от положения точки</returns>
        private static DateTime GetDate(int x, int y)
        {
            if (x >= 0 && y >= 0)
            {
                return DateTime.Today;
            }
            
            if (x <= 0 && y >= 0)
            {
                return DateTime.Today.AddDays(-1);
            }

            if (x <= 0 && y <= 0)
            {
                return DateTime.Today.AddDays(-2);
            }

            if (x >= 0 && y <= 0)
            {
                return DateTime.Today.AddDays(1);
            }

            return DateTime.Today;
        }

        /// <summary>
        /// Возвращает успешный результат вычисления
        /// </summary>
        /// <param name="dateTime">вычисленная дата</param>
        /// <returns>успешный результат вычисления</returns>
        private static CurrencyDateCalculationResult GetSuccessCalculationResult(DateTime dateTime)
        {
            return new CurrencyDateCalculationResult
                       {
                           Success = true,
                           Date = dateTime
                       };
        }

        /// <summary>
        /// Возвращает неуспешный результат вычисления
        /// </summary>
        /// <param name="result">результат валидации</param>
        /// <returns>неуспешный результат вычисления</returns>
        private static CurrencyDateCalculationResult GetFailCalculationResult(ValidationResult result)
        {
            return new CurrencyDateCalculationResult
                       {
                           Date = null,
                           ErrorMessage = result.ErrorMessage,
                           Success = false
                       };
        }
    }
}