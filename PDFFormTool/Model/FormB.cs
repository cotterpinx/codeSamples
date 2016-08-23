using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Oracle.DataAccess.Types;


namespace Foo.Forms.Model
{
    [DataContract(Namespace = "")]
    public class FormB: BaseForm
    {
        public FormB(BaseForm form) : base(form) { }

        //[DataMember()]
        //public Int32 DOCKEY { get; set; }

        //[DataMember()]
        //public Int32 VERKEY { get; set; }

        [DataMember()]
        public String USERSESSION { get; set; }

        [DataMember()]
        public Int32 PAGES { get; set; }

        [DataMember()]
        public String FORINFONAME { get; set; }

        [DataMember()]
        public String FORINFOPHONE { get; set; }

        [DataMember()]
        public String ICODE { get; set; }
        
        [DataMember()]
        public String IADDRESS1 { get; set; }

        [DataMember()]
        public String IADDRESS2 { get; set; }

        [DataMember()]
        public String IADDRESS3 { get; set; }

        [DataMember()]
        public String IADDRESS4 { get; set; }

        [DataMember()]
        public String SCODE { get; set; }

        [DataMember()]
        public String SADDRESS1 { get; set; }

        [DataMember()]
        public String SADDRESS2 { get; set; }

        [DataMember()]
        public String SADDRESS3 { get; set; }

        [DataMember()]
        public String SADDRESS4 { get; set; }

        [DataMember()]
        public String VCODE { get; set; }

        [DataMember()]
        public String VADDRESS1 { get; set; }

        [DataMember()]
        public String VADDRESS2 { get; set; }

        [DataMember()]
        public String VADDRESS3 { get; set; }

        [DataMember()]
        public String VADDRESS4 { get; set; }

        [DataMember()]
        public String VPHONE { get; set; }

        [DataMember()]
        public String ACODE { get; set; }
        
        [DataMember()]
        public String AADDRESS1 { get; set; }

        [DataMember()]
        public String AADDRESS2 { get; set; }

        [DataMember()]
        public String AADDRESS3 { get; set; }

        [DataMember()]
        public String AADDRESS4 { get; set; }

        [DataMember()]
        public String PCODE { get; set; }

        [DataMember()]
        public String PADDRESS1 { get; set; }

        [DataMember()]
        public String PADDRESS2 { get; set; }

        [DataMember()]
        public String PADDRESS3 { get; set; }

        [DataMember()]
        public String PADDRESS4 { get; set; }

        [DataMember()]
        public String UNRESTRICTED { get; set; }

        [DataMember()]
        public String REQUIRED { get; set; }

        [DataMember()]
        public Int32 COPIES { get; set; }

        [DataMember()]
        public String AADDRESS5 { get; set; }

        [DataMember()]
        public String AADDRESS6 { get; set; }
        
        [DataMember()]
        public String IADDRESS5 { get; set; }

        [DataMember()]
        public String IADDRESS6 { get; set; }

        [DataMember()]
        public String PADDRESS5 { get; set; }

        [DataMember()]
        public String PADDRESS6 { get; set; }

        [DataMember()]
        public String SADDRESS5 { get; set; }

        [DataMember()]
        public String SADDRESS6 { get; set; }

        [DataMember()]
        public String VADDRESS5 { get; set; }

        [DataMember()]
        public String VADDRESS6 { get; set; }

        [DataMember()]
        public String VADDRESS7 { get; set; }

        [DataMember()]
        public String RETURNDATE { get; set; }

        public FormB()
        {            
        }
    }
}

