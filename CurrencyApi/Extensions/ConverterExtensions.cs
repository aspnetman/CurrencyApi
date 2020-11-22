using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

using CentralBankApi;

using CurrencyApi.Contracts.Xml;
using CurrencyApi.Models;

namespace CurrencyApi.Extensions
{
    /// <summary>
    /// Содержит различные методы десериализации <see cref="ArrayOfXElement"/>
    /// </summary>
    public static class ConverterExtensions
    {
        /// <summary>
        /// Конвертация в список валют
        /// </summary>
        /// <param name="arrayOfXElement"><see cref="ArrayOfXElement"/></param>
        /// <returns>список валют</returns>
        public static IList<Currency> EnumValutesToCurrencies(this ArrayOfXElement arrayOfXElement)
        {
            List<Currency> result = new List<Currency>();

            foreach (XElement listNode in arrayOfXElement.Nodes)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(CurrencyListRoot));

                if (serializer.CanDeserialize(listNode.CreateReader()) == false)
                {
                    continue;
                }

                CurrencyListRoot root = (CurrencyListRoot)serializer.Deserialize(listNode.CreateReader());

                if (root.ValuteData == null || root.ValuteData.Length <= 0)
                {
                    continue;
                }

                result.AddRange(root.ValuteData.Select(valutes => new Currency { Name = valutes.Vname, Code = valutes.VcharCode }));
            }

            return result;
        }

        /// <summary>
        /// Конвертация в список курсов валют
        /// </summary>
        /// <param name="arrayOfXElement"><see cref="ArrayOfXElement"/></param>
        /// <returns>список курсов валют</returns>
        public static IList<CurrencyRate> EnumValutesToCurrencyRates(this ArrayOfXElement arrayOfXElement)
        {
            List<CurrencyRate> result = new List<CurrencyRate>();

            foreach (XElement listNode in arrayOfXElement.Nodes)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(CurrencyRateRoot));

                if (serializer.CanDeserialize(listNode.CreateReader()) == false)
                {
                    continue;
                }

                CurrencyRateRoot root = (CurrencyRateRoot)serializer.Deserialize(listNode.CreateReader());

                if (root.ValuteData == null || root.ValuteData.Length <= 0)
                {
                    continue;
                }

                result.AddRange(
                    from cursOnDate in root.ValuteData
                    let currency = new Currency { Name = cursOnDate.Vname, Code = cursOnDate.VchCode }
                    select new CurrencyRate(currency) { Nom = cursOnDate.Vnom, Rate = cursOnDate.Vcurs });
            }

            return result;

        }
    }
}
