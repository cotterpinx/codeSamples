using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Oracle.DataAccess.Types;


namespace Foo.Forms.Model
{
    [DataContract(Namespace="")]
    public class BaseForm
    {
        public BaseForm(BaseForm copyForm)
        {
            DOCKEY = copyForm.DOCKEY;
            VERKEY = copyForm.VERKEY;
            formkey = copyForm.formkey;
            DOCTYPE = copyForm.DOCTYPE;
        }

        //Not needed for serialization
        public Int32 formkey { get; set; }

        [DataMember()]
        public Int32 DOCKEY { get; set; }

        [DataMember()]
        public Int32 VERKEY { get; set; }

        [DataMember()]
        public Int32 DOCTYPE { get; set; }

        public BaseForm()
        {            
        }
    }
}

