namespace CurrencyApi.Contracts.Xml
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1", IsNullable = false, ElementName = "diffgram")]
    public class CurrencyRateRoot
    {

        private ValuteDataValuteCursOnDate[] valuteDataField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Namespace = "")]
        [System.Xml.Serialization.XmlArrayItemAttribute("ValuteCursOnDate", IsNullable = false)]
        public ValuteDataValuteCursOnDate[] ValuteData
        {
            get
            {
                return this.valuteDataField;
            }
            set
            {
                this.valuteDataField = value;
            }
        }
    }
}