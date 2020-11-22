using System.Collections.Generic;
using System.Threading.Tasks;

using CurrencyApi.Contracts;
using CurrencyApi.Models;
using CurrencyApi.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CurrencyApi.Controllers
{
    /// <summary>
    /// Контроллер валют
    /// </summary>
    public class CurrencyController : Controller
    {
        private readonly ILogger<CurrencyController> logger;

        private readonly ICurrencyService currencyService;

        public CurrencyController(ICurrencyService currencyService, ILogger<CurrencyController> logger)
        {
            this.currencyService = currencyService;
            this.logger = logger;
        }

        /// <summary>
        /// Возвращает справочник валют
        /// </summary>
        /// <returns><see cref="Task&lt;IActionResult&gt;"/></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            this.logger.LogDebug("Поступил запрос на получение справочника валют");

            OperationResult<IList<Currency>> result = await this.currencyService.GetList();

            return result.Success ? View(result.Result) : this.View("ShowError", new ErrorInformation(result.ErrorMessage));
        }

        /// <summary>
        /// Вычисление курса валюты
        /// </summary>
        /// <param name="request">запрос курса валюты</param>
        /// <returns><see cref="Task&lt;IActionResult&gt;"/></returns>
        [HttpPost]
        public async Task<IActionResult> Get(CurrencyRequest request)
        {
            this.logger.LogDebug($"Поступил запрос на получение курса валюты: { request }");

            OperationResult<CurrencyRate> result = await this.currencyService.GetRate(request);

            return result.Success ? this.View("CurrencyRate", result.Result) : this.View("ShowError", new ErrorInformation(result.ErrorMessage));
        }
    }
}