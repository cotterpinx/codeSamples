using Oracle.DataAccess.Client;
using Foo.Forms.Model;

namespace Foo.Forms.DataServices
{
    public static class ITEMPRINTPropertyMapper
    {
        public static void MapProperties (OracleCommand command, ITEMPRINT ITEMPRINTApi) {            
            command.Parameters.Add("formnum", ITEMPRINTApi.FORMNUM);
            command.Parameters.Add("hdrdockey", ITEMPRINTApi.HDRDOCKEY);
            command.Parameters.Add("usersession", ITEMPRINTApi.USERSESSION);
            command.Parameters.Add("hdrverkey", ITEMPRINTApi.HDRVERKEY);
            command.Parameters.Add("lineno", ITEMPRINTApi.LINENO);
            command.Parameters.Add("itemtext", ITEMPRINTApi.ITEMTEXT);
            command.Parameters.Add("pages", ITEMPRINTApi.PAGES);
            command.Parameters.Add("countpagetext", ITEMPRINTApi.COUNTPAGETEXT);
            command.Parameters.Add("page", ITEMPRINTApi.PAGE);
            command.Parameters.Add("pageoffset", ITEMPRINTApi.PAGEOFFSET);
            command.Parameters.Add("pagetotal", ITEMPRINTApi.PAGETOTAL);
            command.Parameters.Add("pagetotal_string", ITEMPRINTApi.PAGETOTAL_STRING);
        }
    }
}
