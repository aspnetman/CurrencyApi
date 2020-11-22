using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CurrencyApi.Controllers
{
    /// <summary>
    /// Контроллер домашней страницы
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Отображает домашнюю страницы
        /// </summary>
        /// <returns></returns>
        public ViewResult Index()
        {
            this.logger.LogDebug("Запрос домашней страницы");

            return View();
        }
    }
}
