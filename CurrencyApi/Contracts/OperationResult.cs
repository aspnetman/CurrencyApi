namespace CurrencyApi.Contracts
{
    /// <summary>
    /// Результат операции
    /// </summary>
    /// <typeparam name="T"><see cref="T"/> тип результата</typeparam>
    public class OperationResult<T>
    {
        public bool Success { get; set; }

        public T Result { get; set; }

        public string ErrorMessage { get; set; }

        public static OperationResult<T> FromSuccess(T result)
        {
            return new OperationResult<T>
                       {
                           Success = true,
                           Result = result
                       };
        }

        public static OperationResult<T> FromFail(string errorMessage)
        {
            return new OperationResult<T>
                       {
                           Success = false,
                           ErrorMessage = errorMessage
                       };
        }
    }
}
