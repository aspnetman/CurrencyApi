using System.Linq;

using Microsoft.Extensions.Configuration;

namespace CurrencyApi.Services
{
    /// <summary>
    /// Содержит расширения и вспомогательные методы для работы с конфигурацией
    /// </summary>
    public static class ConfigHelper
    {
        /// <summary>
        /// По указанному ключу возвращает его значение <see cref="int"/>, в случае его отсутствия значение по умолчанию
        /// </summary>
        /// <param name="configuration">текущая конфигурация</param>
        /// <param name="key">название ключа</param>
        /// <param name="defaultValue">значение по умолчанию</param>
        /// <returns>значение ключа или в случае его отсутствия значение по умолчанию</returns>
        public static int GetIntOrDefault(this IConfiguration configuration, string key, int defaultValue)
        {
            return SectionExists(configuration, key) ? int.Parse(configuration[key]) : defaultValue;
        }

        /// <summary>
        /// Проверяет наличие ключа в конфигурации
        /// </summary>
        /// <param name="configuration">текущая конфигурация</param>
        /// <param name="key">название ключа</param>
        /// <returns>результат проверки</returns>
        public static bool SectionExists(IConfiguration configuration, string key)
        {
            return configuration.GetChildren().Any(item => item.Key == key);
        }
    }
}