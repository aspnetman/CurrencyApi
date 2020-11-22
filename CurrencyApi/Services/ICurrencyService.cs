using System.Collections.Generic;
using System.Threading.Tasks;

using CurrencyApi.Contracts;
using CurrencyApi.Models;

namespace CurrencyApi.Services
{
    /// <summary>
    /// Интерфейс сервиса валют
    /// </summary>
    public interface ICurrencyService
    {
        /// <summary>
        /// Возвращает список валют
        /// </summary>
        /// <returns>список валют</returns>
        Task<OperationResult<IList<Currency>>> GetList();

        /// <summary>
        /// Возвращает курс валюты по указанному запросу
        /// </summary>
        /// <param name="request">запрос курса валюты</param>
        /// <returns>курс валюты</returns>
        Task<OperationResult<CurrencyRate>> GetRate(CurrencyRequest request);
    }
}