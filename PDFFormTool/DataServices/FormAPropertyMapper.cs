using Oracle.DataAccess.Client;
using Foo.Forms.Model;

namespace Foo.Forms.DataServices
{
    public static class FormAPropertyMapper
    {
        public static void MapProperties (OracleCommand command, FormA FormAApi) {            
            command.Parameters.Add("dockey", FormAApi.DOCKEY);
            command.Parameters.Add("verkey", FormAApi.VERKEY);
            command.Parameters.Add("usersession", FormAApi.USERSESSION);
            command.Parameters.Add("docnum", FormAApi.DOCNUM);
            command.Parameters.Add("versionnum", FormAApi.VERSIONNUM);
            command.Parameters.Add("effectivedate", FormAApi.EFFECTIVEDATE);
            command.Parameters.Add("pages", FormAApi.PAGES);
            command.Parameters.Add("iaddress1", FormAApi.IADDRESS1);
            command.Parameters.Add("iaddress2", FormAApi.IADDRESS2);
            command.Parameters.Add("iaddress3", FormAApi.IADDRESS3);
            command.Parameters.Add("iaddress4", FormAApi.IADDRESS4);
            command.Parameters.Add("icode", FormAApi.ICODE);
            command.Parameters.Add("aaddress1", FormAApi.AADDRESS1);
            command.Parameters.Add("aaddress2", FormAApi.AADDRESS2);
            command.Parameters.Add("aaddress3", FormAApi.AADDRESS3);
            command.Parameters.Add("aaddress4", FormAApi.AADDRESS4);
            command.Parameters.Add("acode", FormAApi.ACODE);
            command.Parameters.Add("vaddress1", FormAApi.VADDRESS1);
            command.Parameters.Add("vaddress2", FormAApi.VADDRESS2);
            command.Parameters.Add("vaddress3", FormAApi.VADDRESS3);
            command.Parameters.Add("vaddress4", FormAApi.VADDRESS4);
            command.Parameters.Add("vcode", FormAApi.VCODE);
            command.Parameters.Add("dated", FormAApi.DATED);
            command.Parameters.Add("extendedyes", FormAApi.EXTENDEDYES);
            command.Parameters.Add("extendedno", FormAApi.EXTENDEDNO);
            command.Parameters.Add("adminchanges", FormAApi.ADMINCHANGES);
            command.Parameters.Add("signsyes", FormAApi.SIGNSYES);
            command.Parameters.Add("signsno", FormAApi.SIGNSNO);
            command.Parameters.Add("copies", FormAApi.COPIES);
            command.Parameters.Add("check13a", FormAApi.CHECK13A);
            command.Parameters.Add("check13b", FormAApi.CHECK13B);
            command.Parameters.Add("check13c", FormAApi.CHECK13C);
            command.Parameters.Add("check13d", FormAApi.CHECK13D);
            command.Parameters.Add("contpagedocnum", FormAApi.CONTPAGEDOCNUM);
            command.Parameters.Add("iaddress5", FormAApi.IADDRESS5);
            command.Parameters.Add("iaddress6", FormAApi.IADDRESS6);
            command.Parameters.Add("aaddress5", FormAApi.AADDRESS5);
            command.Parameters.Add("aaddress6", FormAApi.AADDRESS6);
            command.Parameters.Add("vaddress5", FormAApi.VADDRESS5);
            command.Parameters.Add("vaddress6", FormAApi.VADDRESS6);
            command.Parameters.Add("vaddress7", FormAApi.VADDRESS7);
            command.Parameters.Add("doctype", FormAApi.DOCTYPE);
        }
    }
}
