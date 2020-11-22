namespace CurrencyApi.Contracts.Xml
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.Serializable]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1")]
    [System.Xml.Serialization.XmlRoot(Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1", IsNullable = false, ElementName = "diffgram")]
    public class CurrencyListRoot
    {
        private ValuteDataEnumValutes[] valuteDataField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Namespace = "")]
        [System.Xml.Serialization.XmlArrayItemAttribute("EnumValutes", IsNullable = false)]
        public ValuteDataEnumValutes[] ValuteData
        {
            get => this.valuteDataField;
            set => this.valuteDataField = value;
        }
    }
}