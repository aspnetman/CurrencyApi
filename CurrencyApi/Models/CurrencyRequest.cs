namespace CurrencyApi.Models
{
    /// <summary>
    /// Запрос курса валюты
    /// </summary>
    public class CurrencyRequest
    {
        /// <summary>
        /// Координата X
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Координата Y
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// ISO Символьный код валюты
        /// </summary>
        public string Code { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"X: { this.X }, Y: { this.Y }, Code: { this.Code }";
        }
    }
}