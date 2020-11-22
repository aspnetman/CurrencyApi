namespace CurrencyApi.Models
{
    /// <summary>
    /// Информация об ошибке
    /// </summary>
    public class ErrorInformation
    {
        public ErrorInformation(string message)
        {
            this.Message = message;
        }

        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        public string Message { get; }
    }
}