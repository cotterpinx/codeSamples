using Oracle.DataAccess.Client;
using Foo.Forms.Model;
using System;

namespace Foo.Forms.DataServices
{
    public class FormARowMapper
    {
        public void MapRow(OracleDataReader FormAApiReader, FormA FormAForm)
        {
            if (FormAApiReader.HasRows)
            {
                while (FormAApiReader.Read())
                {
                    int column = FormAApiReader.GetOrdinal("dockey");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.DOCKEY = FormAApiReader.GetInt32(column);
                    }

                    column = FormAApiReader.GetOrdinal("verkey");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.VERKEY = FormAApiReader.GetInt32(column);
                    }

                    column = FormAApiReader.GetOrdinal("usersession");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.USERSESSION = FormAApiReader.GetString(column);
                    }

                    column = FormAApiReader.GetOrdinal("docnum");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.DOCNUM = FormAApiReader.GetString(column);
                    }

                    column = FormAApiReader.GetOrdinal("versionnum");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.VERSIONNUM = FormAApiReader.GetString(column);
                    }
                    
                    column = FormAApiReader.GetOrdinal("effectivedate");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.EFFECTIVEDATE = FormAApiReader.GetString(column);
                    }
                    
                    column = FormAApiReader.GetOrdinal("pages");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.PAGES = FormAApiReader.GetInt32(column);
                    }
                    
                    column = FormAApiReader.GetOrdinal("iaddress1");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.IADDRESS1 = FormAApiReader.GetString(column);
                    }
                    
                    column = FormAApiReader.GetOrdinal("iaddress2");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.IADDRESS2 = FormAApiReader.GetString(column);
                    }
                    
                    column = FormAApiReader.GetOrdinal("iaddress3");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.IADDRESS3 = FormAApiReader.GetString(column);
                    }
                    
                    column = FormAApiReader.GetOrdinal("iaddress4");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.IADDRESS4 = FormAApiReader.GetString(column);
                    }
                    
                    column = FormAApiReader.GetOrdinal("icode");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.ICODE = FormAApiReader.GetString(column);
                    }
                    
                    column = FormAApiReader.GetOrdinal("aaddress1");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.AADDRESS1 = FormAApiReader.GetString(column);
                    }
                    
                    column = FormAApiReader.GetOrdinal("aaddress2");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.AADDRESS2 = FormAApiReader.GetString(column);
                    }
                    
                    column = FormAApiReader.GetOrdinal("aaddress3");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.AADDRESS3 = FormAApiReader.GetString(column);
                    }
                    
                    column = FormAApiReader.GetOrdinal("aaddress4");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.AADDRESS4 = FormAApiReader.GetString(column);
                    }
                    
                    column = FormAApiReader.GetOrdinal("acode");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.ACODE = FormAApiReader.GetString(column);
                    }
                    
                    column = FormAApiReader.GetOrdinal("vaddress1");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.VADDRESS1 = FormAApiReader.GetString(column);
                    }

                    column = FormAApiReader.GetOrdinal("vaddress2");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.VADDRESS2 = FormAApiReader.GetString(column);
                    }
                    
                    column = FormAApiReader.GetOrdinal("vaddress3");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.VADDRESS3 = FormAApiReader.GetString(column);
                    }

                    column = FormAApiReader.GetOrdinal("vaddress4");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.VADDRESS4 = FormAApiReader.GetString(column);
                    }

                    column = FormAApiReader.GetOrdinal("vcode");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.VCODE = FormAApiReader.GetString(column);
                    }

                    column = FormAApiReader.GetOrdinal("dated");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.DATED = FormAApiReader.GetDateTime(column);
                    }

                    column = FormAApiReader.GetOrdinal("extendedyes");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.EXTENDEDYES = FormAApiReader.GetString(column);
                    }

                    column = FormAApiReader.GetOrdinal("extendedno");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.EXTENDEDNO = FormAApiReader.GetString(column);
                    }

                    column = FormAApiReader.GetOrdinal("adminchanges");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.ADMINCHANGES = FormAApiReader.GetString(column);
                    }

                    column = FormAApiReader.GetOrdinal("signsyes");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.SIGNSYES = FormAApiReader.GetString(column);
                    }

                    column = FormAApiReader.GetOrdinal("signsno");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.SIGNSNO = FormAApiReader.GetString(column);
                    }

                    column = FormAApiReader.GetOrdinal("copies");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.COPIES = FormAApiReader.GetInt32(column);
                    }

                    column = FormAApiReader.GetOrdinal("check13a");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.CHECK13A = FormAApiReader.GetString(column);
                    }

                    column = FormAApiReader.GetOrdinal("check13b");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.CHECK13B = FormAApiReader.GetString(column);
                    }

                    column = FormAApiReader.GetOrdinal("check13c");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.CHECK13C = FormAApiReader.GetString(column);
                    }

                    column = FormAApiReader.GetOrdinal("check13d");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.CHECK13D = FormAApiReader.GetString(column);
                    }

                    column = FormAApiReader.GetOrdinal("contpagedocnum");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.CONTPAGEDOCNUM = FormAApiReader.GetString(column);
                    }

                    column = FormAApiReader.GetOrdinal("iaddress5");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.IADDRESS5 = FormAApiReader.GetString(column);
                    }

                    column = FormAApiReader.GetOrdinal("iaddress6");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.IADDRESS6 = FormAApiReader.GetString(column);
                    }

                    column = FormAApiReader.GetOrdinal("aaddress5");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.AADDRESS5 = FormAApiReader.GetString(column);
                    }

                    column = FormAApiReader.GetOrdinal("aaddress6");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.AADDRESS6 = FormAApiReader.GetString(column);
                    }

                    column = FormAApiReader.GetOrdinal("vaddress5");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.VADDRESS5 = FormAApiReader.GetString(column);
                    }

                    column = FormAApiReader.GetOrdinal("vaddress6");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.VADDRESS6 = FormAApiReader.GetString(column);
                    }

                    column = FormAApiReader.GetOrdinal("vaddress7");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.VADDRESS7 = FormAApiReader.GetString(column);
                    }

                    column = FormAApiReader.GetOrdinal("doctype");
                    if (!FormAApiReader.IsDBNull(column))
                    {
                        FormAForm.DOCTYPE = FormAApiReader.GetInt32(column);
                    }

                }
            }
        }
    }
}