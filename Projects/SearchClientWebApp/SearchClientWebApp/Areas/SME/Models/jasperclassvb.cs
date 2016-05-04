using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchClientWebApp.Areas.SME.Models
{
    public class jasperclassvb
    {

        ///<remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true), Serializable(), System.Xml.Serialization.XmlRootAttribute(Namespace = "http://atradius.com/connect/_2007_08/", IsNullable = false)]
        public partial class reportitem
        {


            private string uuidField;

            private string originalUriField;

            private ushort totalPagesField;

            private byte startPageField;

            private ushort endPageField;

            private reportFile fileField;
            ///<remarks/>
            public string uuid
            {
                get { return this.uuidField; }
                set { this.uuidField = value; }
            }

            ///<remarks/>
            public string originalUri
            {
                get { return this.originalUriField; }
                set { this.originalUriField = value; }
            }

            ///<remarks/>
            public ushort totalPages
            {
                get { return this.totalPagesField; }
                set { this.totalPagesField = value; }
            }

            ///<remarks/>
            public byte startPage
            {
                get { return this.startPageField; }
                set { this.startPageField = value; }
            }

            ///<remarks/>
            public ushort endPage
            {
                get { return this.endPageField; }
                set { this.endPageField = value; }
            }

            ///<remarks/>
            public reportFile file
            {
                get { return this.fileField; }
                set { this.fileField = value; }
            }
        }

        ///<remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportFile
        {


            private string typeField;

            private string valueField;
            ///<remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string type
            {
                get { return this.typeField; }
                set { this.typeField = value; }
            }

            ///<remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public string Value
            {
                get { return this.valueField; }
                set { this.valueField = value; }
            }
        }


    }

}