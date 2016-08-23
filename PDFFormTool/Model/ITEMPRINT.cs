using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Oracle.DataAccess.Types;


namespace Foo.Forms.Model
{
    [DataContract(Namespace = "")]
    public class ITEMPRINT
    {
        public ITEMPRINT() { }

        [DataMember()]
        public String FORMNUM { get; set; }

        [DataMember()]
        public Int32 HDRDOCKEY { get; set; }

        [DataMember()]
        public String USERSESSION { get; set; }

        [DataMember()]
        public Int32 HDRVERKEY { get; set; }

        [DataMember()]
        public Int32 LINENO { get; set; }

        [DataMember()]
        public String ITEMTEXT { get; set; }

        [DataMember()]
        public Int32 PAGES { get; set; }

        [DataMember()]
        public String COUNTPAGETEXT { get; set; }

        [DataMember()]
        public Int32 PAGE { get; set; }

        [DataMember()]
        public Int32 PAGEOFFSET { get; set; }

        [DataMember()]
        public Decimal PAGETOTAL { get; set; }

        [DataMember()]
        public String PAGETOTAL_STRING { get; set; }        
    }
}

