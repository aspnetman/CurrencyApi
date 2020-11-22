namespace CurrencyApi.Models
{
    /// <summary>
    /// Содержит данные о валюте
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// Название валюты
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ISO Символьный код валюты
        /// </summary>
        public string Code { get; set; }
    }
}