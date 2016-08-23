using Oracle.DataAccess.Client;
using Foo.Forms.Model;
using System;

namespace Foo.Forms.DataServices
{
    public class FormBRowMapper
    {
        public void MapRow(OracleDataReader FormBApiReader, FormB FormBForm, bool isAWD)
        {
            if (FormBApiReader.HasRows)
            {
                while (FormBApiReader.Read())
                {
                    int column = FormBApiReader.GetOrdinal("dockey");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.DOCKEY = FormBApiReader.GetInt32(column);
                    }

                    column = FormBApiReader.GetOrdinal("verkey");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.VERKEY = FormBApiReader.GetInt32(column);
                    }

                    column = FormBApiReader.GetOrdinal("usersession");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.USERSESSION = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("pages");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.PAGES = FormBApiReader.GetInt32(column);
                    }

                    column = FormBApiReader.GetOrdinal("forinfoname");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.FORINFONAME = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("forinfophone");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.FORINFOPHONE = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("icode");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.ICODE = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("iaddress1");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.IADDRESS1 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("iaddress2");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.IADDRESS2 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("iaddress3");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.IADDRESS3 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("iaddress4");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.IADDRESS4 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("scode");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.SCODE = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("saddress1");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.SADDRESS1 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("saddress2");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.SADDRESS2 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("saddress3");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.SADDRESS3 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("saddress4");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.SADDRESS4 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("vcode");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.VCODE = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("vaddress1");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.VADDRESS1 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("vaddress2");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.VADDRESS2 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("vaddress3");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.VADDRESS3 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("vaddress4");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.VADDRESS4 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("vphone");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.VPHONE = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("acode");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.ACODE = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("aaddress1");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.AADDRESS1 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("aaddress2");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.AADDRESS2 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("aaddress3");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.AADDRESS3 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("aaddress4");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.AADDRESS4 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("pcode");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.PCODE = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("paddress1");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.PADDRESS1 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("paddress2");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.PADDRESS2 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("paddress3");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.PADDRESS3 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("paddress4");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.PADDRESS4 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("unrestricted");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.UNRESTRICTED = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("required");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.REQUIRED = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("copies");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.COPIES = FormBApiReader.GetInt32(column);
                    }

                    column = FormBApiReader.GetOrdinal("aaddress5");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.AADDRESS5 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("aaddress6");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.AADDRESS6 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("iaddress5");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.IADDRESS5 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("iaddress6");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.IADDRESS6 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("paddress5");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.PADDRESS5 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("paddress6");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.PADDRESS6 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("saddress5");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.SADDRESS5 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("saddress6");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.SADDRESS6 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("vaddress5");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.VADDRESS5 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("vaddress6");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.VADDRESS6 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("vaddress7");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.VADDRESS7 = FormBApiReader.GetString(column);
                    }

                    column = FormBApiReader.GetOrdinal("returndate");
                    if (!FormBApiReader.IsDBNull(column))
                    {
                        FormBForm.RETURNDATE = FormBApiReader.GetString(column);
                    }

               }
            }
        }
    }
}