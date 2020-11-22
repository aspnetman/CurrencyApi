namespace CurrencyApi.Contracts
{
    /// <summary>
    /// Результат валидации
    /// </summary>
    public class ValidationResult
    {
        /// <summary>
        /// <value>true</value> - успешная валидация, иначе <value>false</value> - результат валидации отрицательный
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}