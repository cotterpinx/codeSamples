using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Oracle.DataAccess.Types;


namespace Foo.Forms.Model
{
    [DataContract(Namespace = "")]
    public class ITEMS
    {
        public ITEMS() 
        {
            ITEMLIST = new List<ITEMPRINT>();
        }

        [DataMember()]
        public IList<ITEMPRINT> ITEMLIST { get; set; }
    }
}

