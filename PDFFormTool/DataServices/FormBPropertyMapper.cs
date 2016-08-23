using Oracle.DataAccess.Client;
using Foo.Forms.Model;

namespace Foo.Forms.DataServices
{
    public static class FormBPropertyMapper
    {
        public static void MapProperties(OracleCommand command, FormB FormBApi)
        {   
            command.Parameters.Add("dockey", FormBApi.DOCKEY);
            command.Parameters.Add("verkey", FormBApi.VERKEY);
            command.Parameters.Add("usersession", FormBApi.USERSESSION);
            command.Parameters.Add("pages", FormBApi.PAGES);
            command.Parameters.Add("forinfoname", FormBApi.FORINFONAME);
            command.Parameters.Add("forinfophone", FormBApi.FORINFOPHONE);
            command.Parameters.Add("icode", FormBApi.ICODE);
            command.Parameters.Add("iaddress1", FormBApi.IADDRESS1);
            command.Parameters.Add("iaddress2", FormBApi.IADDRESS2);
            command.Parameters.Add("iaddress3", FormBApi.IADDRESS3);
            command.Parameters.Add("iaddress4", FormBApi.IADDRESS4);
            command.Parameters.Add("scode", FormBApi.SCODE);
            command.Parameters.Add("saddress1", FormBApi.SADDRESS1);
            command.Parameters.Add("saddress2", FormBApi.SADDRESS2);
            command.Parameters.Add("saddress3", FormBApi.SADDRESS3);
            command.Parameters.Add("saddress4", FormBApi.SADDRESS4);
            command.Parameters.Add("vcode", FormBApi.VCODE);
            command.Parameters.Add("vaddress1", FormBApi.VADDRESS1);
            command.Parameters.Add("vaddress2", FormBApi.VADDRESS2);
            command.Parameters.Add("vaddress3", FormBApi.VADDRESS3);
            command.Parameters.Add("vaddress4", FormBApi.VADDRESS4);
            command.Parameters.Add("vphone", FormBApi.VPHONE);
            command.Parameters.Add("acode", FormBApi.ACODE);
            command.Parameters.Add("aaddress1", FormBApi.AADDRESS1);
            command.Parameters.Add("aaddress2", FormBApi.AADDRESS2);
            command.Parameters.Add("aaddress3", FormBApi.AADDRESS3);
            command.Parameters.Add("aaddress4", FormBApi.AADDRESS4);
            command.Parameters.Add("pcode", FormBApi.PCODE);
            command.Parameters.Add("paddress1", FormBApi.PADDRESS1);
            command.Parameters.Add("paddress2", FormBApi.PADDRESS2);
            command.Parameters.Add("paddress3", FormBApi.PADDRESS3);
            command.Parameters.Add("paddress4", FormBApi.PADDRESS4);
            command.Parameters.Add("unrestricted", FormBApi.UNRESTRICTED);
            command.Parameters.Add("required", FormBApi.REQUIRED);
            command.Parameters.Add("copies", FormBApi.COPIES);
            command.Parameters.Add("aaddress5", FormBApi.AADDRESS5);
            command.Parameters.Add("aaddress6", FormBApi.AADDRESS6);
            command.Parameters.Add("iaddress5", FormBApi.IADDRESS5);
            command.Parameters.Add("iaddress6", FormBApi.IADDRESS6);
            command.Parameters.Add("paddress5", FormBApi.PADDRESS5);
            command.Parameters.Add("paddress6", FormBApi.PADDRESS6);
            command.Parameters.Add("saddress5", FormBApi.SADDRESS5);
            command.Parameters.Add("saddress6", FormBApi.SADDRESS6);
            command.Parameters.Add("vaddress5", FormBApi.VADDRESS5);
            command.Parameters.Add("vaddress6", FormBApi.VADDRESS6);
            command.Parameters.Add("vaddress7", FormBApi.VADDRESS7);
            command.Parameters.Add("returndate", FormBApi.RETURNDATE);
        }
    }
}
