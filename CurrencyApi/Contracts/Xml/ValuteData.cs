namespace CurrencyApi.Contracts.Xml
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.Serializable]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
    public class ValuteData
    {
        private ValuteDataEnumValutes[] enumValutesField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("EnumValutes")]
        public ValuteDataEnumValutes[] EnumValutes
        {
            get => this.enumValutesField;
            set => this.enumValutesField = value;
        }
    }

}
