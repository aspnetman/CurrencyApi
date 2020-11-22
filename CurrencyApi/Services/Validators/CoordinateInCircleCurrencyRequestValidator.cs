using System;

using CurrencyApi.Contracts;
using CurrencyApi.Models;

namespace CurrencyApi.Services.Validators
{
    /// <summary>
    /// Проверяет, что координата в декартовой системе координат попадает в круг указанного радиуса
    /// </summary>
    public class CoordinateInCircleCurrencyRequestValidator : ICurrencyRequestValidator
    {
        private readonly int circleRadius;

        private readonly int circleCenterX;

        private readonly int circleCenterY;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CoordinateInCircleCurrencyRequestValidator" />
        /// </summary>
        /// <param name="circleRadius">радиус круга</param>
        /// <param name="circleCenterX">координата X центра круга</param>
        /// <param name="circleCenterY">координата Y центра круга</param>
        public CoordinateInCircleCurrencyRequestValidator(int circleRadius, int circleCenterX, int circleCenterY)
        {
            this.circleRadius = circleRadius;
            this.circleCenterX = circleCenterX;
            this.circleCenterY = circleCenterY;
        }

        /// <inheritdoc />
        public ValidationResult Validate(CurrencyRequest request)
        {
            bool result = Math.Pow(request.X - this.circleCenterX, 2) + Math.Pow(request.Y - this.circleCenterY, 2) <= Math.Pow(this.circleRadius, 2);

            return new ValidationResult
                       {
                           ErrorMessage = result ? string.Empty : $"Координата ({ request.X }, { request.Y }) не входит в окружность с радиусом { this.circleRadius } и центром в ({ this.circleCenterX }, { this.circleCenterY })",
                           Success = result
                       };
        }
    }
}
