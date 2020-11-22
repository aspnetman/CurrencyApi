using System;

namespace CurrencyApi.Contracts
{
    /// <summary>
    /// Содержить результат расчёта даты валюты
    /// </summary>
    public class CurrencyDateCalculationResult
    {
        /// <summary>
        /// <value>true</value> - успешное вычисление даты валюты, иначе <value>false</value> - дату валюты вычислить не удалось
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Результат расчёта даты валюты
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Сообщение об ошибке в случае неудачной операции расчёта даты валюты
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}