namespace CurrencyApi.Contracts.Xml
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class ValuteDataValuteCursOnDate
    {

        private string vnameField;

        private ushort vnomField;

        private decimal vcursField;

        private ushort vcodeField;

        private string vchCodeField;

        private string idField;

        private byte rowOrderField;

        /// <remarks/>
        public string Vname
        {
            get
            {
                return this.vnameField;
            }
            set
            {
                this.vnameField = value;
            }
        }

        /// <remarks/>
        public ushort Vnom
        {
            get
            {
                return this.vnomField;
            }
            set
            {
                this.vnomField = value;
            }
        }

        /// <remarks/>
        public decimal Vcurs
        {
            get
            {
                return this.vcursField;
            }
            set
            {
                this.vcursField = value;
            }
        }

        /// <remarks/>
        public ushort Vcode
        {
            get
            {
                return this.vcodeField;
            }
            set
            {
                this.vcodeField = value;
            }
        }

        /// <remarks/>
        public string VchCode
        {
            get
            {
                return this.vchCodeField;
            }
            set
            {
                this.vchCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1")]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "urn:schemas-microsoft-com:xml-msdata")]
        public byte rowOrder
        {
            get
            {
                return this.rowOrderField;
            }
            set
            {
                this.rowOrderField = value;
            }
        }
    }
}