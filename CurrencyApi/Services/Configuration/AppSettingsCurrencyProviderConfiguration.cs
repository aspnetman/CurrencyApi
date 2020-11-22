using Microsoft.Extensions.Configuration;

namespace CurrencyApi.Services.Configuration
{
    /// <summary>
    /// Предоставляет доступ к настройкам на основанни конфигурации <see cref="IConfiguration"/>
    /// </summary>
    public class AppSettingsCurrencyProviderConfiguration : ICurrencyProviderConfiguration
    {
        private readonly IConfiguration configuration;

        public AppSettingsCurrencyProviderConfiguration(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <inheritdoc />
        public string GetCurrencyServiceRemoteAddress()
        {
            return this.configuration["DailyInfoRemoteAddress"];
        }
    }
}