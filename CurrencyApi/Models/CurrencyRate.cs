using System;

namespace CurrencyApi.Models
{
    /// <summary>
    /// Курс валюты
    /// </summary>
    public class CurrencyRate
    {
        public CurrencyRate(Currency currency)
        {
            this.Currency = currency;
        }

        /// <summary>
        /// Валюта
        /// </summary>
        public Currency Currency { get; }

        /// <summary>
        /// Номинал
        /// </summary>
        public decimal Nom { get; set; }

        /// <summary>
        /// Курс
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// Дата курса
        /// </summary>
        public DateTime Date { get; set; }
    }
}