using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CentralBankApi;

using CurrencyApi.Extensions;
using CurrencyApi.Models;

namespace CurrencyApi.Services
{
    /// <summary>
    /// Провайдер курсов валют на основании Web сервиса Банка России
    /// </summary>
    public class CentralBankSoapCurrencyProvider : ICurrencyProvider
    {
        private readonly DailyInfoSoapClient dailyInfo;

        public CentralBankSoapCurrencyProvider(string currencyServiceRemoteAddress)
        {
            this.dailyInfo = new DailyInfoSoapClient(DailyInfoSoapClient.EndpointConfiguration.DailyInfoSoap12, currencyServiceRemoteAddress);
        }

        /// <inheritdoc />
        public async Task<IList<Currency>> GetList()
        {
            ArrayOfXElement arrayOfXElement = await this.dailyInfo.EnumValutesAsync(false).ConfigureAwait(false);

            return arrayOfXElement.EnumValutesToCurrencies();
        }

        /// <inheritdoc />
        public async Task<CurrencyRate> GetRate(DateTime date, string code)
        {
            ArrayOfXElement arrayOfXElement = await this.dailyInfo.GetCursOnDateAsync(date);

            IList<CurrencyRate> rates = arrayOfXElement.EnumValutesToCurrencyRates();

            if (rates == null)
            {
                return null;
            }

            CurrencyRate result = rates.FirstOrDefault(currencyRate => currencyRate.Currency.Code == code);

            if (result != null)
            {
                result.Date = date;
            }

            return result;
        }
    }
}