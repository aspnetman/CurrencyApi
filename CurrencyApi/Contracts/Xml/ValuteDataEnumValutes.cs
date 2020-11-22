namespace CurrencyApi.Contracts.Xml
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.Serializable]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public class ValuteDataEnumValutes
    {

        private string vcodeField;

        private string vnameField;

        private string vEngnameField;

        private uint vnomField;

        private string vcommonCodeField;

        private ushort vnumCodeField;

        private bool vnumCodeFieldSpecified;

        private string vcharCodeField;

        private string idField;

        private byte rowOrderField;

        /// <remarks/>
        public string Vcode
        {
            get => this.vcodeField;
            set => this.vcodeField = value;
        }

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
        public string VEngname
        {
            get
            {
                return this.vEngnameField;
            }
            set
            {
                this.vEngnameField = value;
            }
        }

        /// <remarks/>
        public uint Vnom
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
        public string VcommonCode
        {
            get
            {
                return this.vcommonCodeField;
            }
            set
            {
                this.vcommonCodeField = value;
            }
        }

        /// <remarks/>
        public ushort VnumCode
        {
            get
            {
                return this.vnumCodeField;
            }
            set
            {
                this.vnumCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool VnumCodeSpecified
        {
            get
            {
                return this.vnumCodeFieldSpecified;
            }
            set
            {
                this.vnumCodeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string VcharCode
        {
            get
            {
                return this.vcharCodeField;
            }
            set
            {
                this.vcharCodeField = value;
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
