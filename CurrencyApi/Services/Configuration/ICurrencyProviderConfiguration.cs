namespace CurrencyApi.Services.Configuration
{
    /// <summary>
    /// Предоставляет доступ к настройкам <see cref="ICurrencyProvider"/>
    /// </summary>
    public interface ICurrencyProviderConfiguration
    {
        /// <summary>
        /// Возвращает адрес сервиса вычисления курса валют
        /// </summary>
        /// <returns></returns>
        string GetCurrencyServiceRemoteAddress();
    }
}