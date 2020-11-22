using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CurrencyApi.Models;

namespace CurrencyApi.Services
{
    /// <summary>
    /// Провайдер валют
    /// </summary>
    public interface ICurrencyProvider
    {
        /// <summary>
        /// Возвращает список валют
        /// </summary>
        /// <returns>список валют</returns>
        Task<IList<Currency>> GetList();

        /// <summary>
        /// Возвращает курс валюты по указанному запросу
        /// </summary>
        /// <param name="date">дата для запроса курса</param>
        /// <param name="code">требуемая валюта</param>
        /// <returns>курс валюты</returns>
        Task<CurrencyRate> GetRate(DateTime date, string code);
    }
}