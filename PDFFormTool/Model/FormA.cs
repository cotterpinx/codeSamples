using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Oracle.DataAccess.Types;


namespace Foo.Forms.Model
{
    [DataContract(Namespace = "")]
    public class FormA: BaseForm
    {
        public FormA(BaseForm form) : base(form) { }

        //[DataMember()]
        //public Int32 DOCKEY { get; set; }

        //[DataMember()]
        //public Int32 VERKEY { get; set; }

        [DataMember()]
        public String USERSESSION { get; set; }

        [DataMember()]
        public String DOCNUM { get; set; }

        [DataMember()]
        public String VERSIONNUM { get; set; }

        [DataMember()]
        public String EFFECTIVEDATE { get; set; }

        [DataMember()]
        public Int32 PAGES { get; set; }

        [DataMember()]
        public String IADDRESS1 { get; set; }

        [DataMember()]
        public String IADDRESS2 { get; set; }

        [DataMember()]
        public String IADDRESS3 { get; set; }

        [DataMember()]
        public String IADDRESS4 { get; set; }

        [DataMember()]
        public String ICODE { get; set; }

        [DataMember()]
        public String AADDRESS1 { get; set; }

        [DataMember()]
        public String AADDRESS2 { get; set; }

        [DataMember()]
        public String AADDRESS3 { get; set; }

        [DataMember()]
        public String AADDRESS4 { get; set; }

        [DataMember()]
        public String ACODE { get; set; }

        [DataMember()]
        public String VADDRESS1 { get; set; }

        [DataMember()]
        public String VADDRESS2 { get; set; }

        [DataMember()]
        public String VADDRESS3 { get; set; }

        [DataMember()]
        public String VADDRESS4 { get; set; }

        [DataMember()]
        public String VCODE { get; set; }

        [DataMember()]
        public DateTime DATED { get; set; }

        [DataMember()]
        public String EXTENDEDYES { get; set; }

        [DataMember()]
        public String EXTENDEDNO { get; set; }

        [DataMember()]
        public String ADMINCHANGES { get; set; }

        [DataMember()]
        public String SIGNSYES { get; set; }

        [DataMember()]
        public String SIGNSNO { get; set; }

        [DataMember()]
        public Int32 COPIES { get; set; }

        [DataMember()]
        public String CHECK13A { get; set; }

        [DataMember()]
        public String CHECK13B { get; set; }

        [DataMember()]
        public String CHECK13C { get; set; }

        [DataMember()]
        public String CHECK13D { get; set; }

        [DataMember()]
        public String CONTPAGEDOCNUM { get; set; }

        [DataMember()]
        public String IADDRESS5 { get; set; }

        [DataMember()]
        public String IADDRESS6 { get; set; }

        [DataMember()]
        public String AADDRESS5 { get; set; }

        [DataMember()]
        public String AADDRESS6 { get; set; }

        [DataMember()]
        public String VADDRESS5 { get; set; }

        [DataMember()]
        public String VADDRESS6 { get; set; }

        [DataMember()]
        public String VADDRESS7 { get; set; }

        //[DataMember()]
        //public Int32 DOCTYPE { get; set; }


        public FormA()
        {            
        }
    }
}

