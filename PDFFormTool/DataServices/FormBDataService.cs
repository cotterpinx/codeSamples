using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using Oracle.DataAccess.Client;

using Foo.Forms.Model;

namespace Foo.Forms.DataServices
{
    public class FormBDataService : BaseFormDataService
    {
        public FormB form { get; set; }

        private string connStr { get; set; }

        public const string FormBTemplate = @"FormB\FormB.pdf";



        public FormBDataService(BaseForm baseForm, string connString)
        {
            log.Debug("Starting FormBDataService constructor");

            form = new FormB(baseForm);
            itemForm = new ITEMS();
            this.connStr = connString;
            base.formTemplate = FormBTemplate;
            base.xmlInput = new XmlDocument();
            base.xmlInput.LoadXml("<formData></formData>");
            base.functionName = "FORM_FormB";
        }

        public override void GetFormData()
        {
            log.Debug("In GetFormData for FormB.");

            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();

                //get sessionID 
                using (OracleCommand sessionCmd = conn.CreateCommand())
                {
                    sessionCmd.CommandText = "SELECT 'FORMB'||FORMB_seq.nextval FROM DUAL";
                    sessionCmd.CommandType = CommandType.Text;
                    object sessionResult = sessionCmd.ExecuteScalar();
                    if (sessionResult != null)
                    {
                        form.USERSESSION = sessionResult.ToString();
                    }

                    log.Debug("sessionID: " + form.USERSESSION);
                }

                //call stored function/procedure to write data to temp table
                using (OracleCommand cmd = conn.CreateCommand())
                {
                    string addrtype = "AddrType1";
                    string printnetview = "N";

                    //cmd.CommandText = DBOwner. + procName;
                    cmd.CommandText = "FOO." + functionName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    OracleParameter retVal = new OracleParameter("ReturnValue", OracleDbType.Int32, ParameterDirection.ReturnValue);
                    cmd.Parameters.Add(retVal);
                    cmd.Parameters.Add("LL_DOCKEY", OracleDbType.Int32, ParameterDirection.Input).Value = form.DOCKEY;
                    cmd.Parameters.Add("LL_VERKEY", OracleDbType.Int32, ParameterDirection.Input).Value = form.VERKEY;
                    cmd.Parameters.Add("LI_DOCTYPE", OracleDbType.Int32, ParameterDirection.Input).Value = form.DOCTYPE;
                    cmd.Parameters.Add("LI_FORMKEY", OracleDbType.Int32, ParameterDirection.Input).Value = form.formkey;
                    cmd.Parameters.Add("LS_SESSION", OracleDbType.Varchar2, ParameterDirection.Input).Value = form.USERSESSION;
                    cmd.Parameters.Add("LS_ADDRTYPE", OracleDbType.Varchar2, ParameterDirection.Input).Value = addrtype;
                    cmd.Parameters.Add("AS_PRINTNETVIEW", OracleDbType.Varchar2, ParameterDirection.Input).Value = printnetview;

                    //this is the only non-query, so wrap it in a transaction/commit
                    OracleTransaction trans = conn.BeginTransaction();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        trans.Commit();
                    }
                    catch (InvalidOperationException ioe)
                    {
                        //not able to delete the temp row. Roll back the transaction. 
                        trans.Rollback();
                        //TODO what else should be done here to handle the error? Log it and move on?
                    }     


                    log.Debug(functionName + " function has been executed with return value: " + retVal.Value);
                }
            }
        }

        public override void PopulateFormModel()
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();

                //Fill the model with the values from the temp table
                using (OracleCommand FormBCmd = conn.CreateCommand())
                {
                    FormBCmd.CommandText = "SELECT * FROM FORMB WHERE DOCKEY = :dockey AND VERKEY = :verkey AND USERSESSION = :usersession";
                    FormBCmd.CommandType = CommandType.Text;
                    FormBCmd.Parameters.Add("dockey", form.DOCKEY);
                    FormBCmd.Parameters.Add("verkey", form.VERKEY);
                    FormBCmd.Parameters.Add("usersession", form.USERSESSION);

                    using (OracleDataReader FormBReader = FormBCmd.ExecuteReader())
                    {
                        FormBRowMapper rowMapper = new FormBRowMapper();
                        rowMapper.MapRow(FormBReader, form, true); 
                    }
                }

                //Once the data is in the model, clean up the temp table
                using (OracleCommand deleteCmd = conn.CreateCommand())
                {
                    deleteCmd.CommandType = CommandType.Text;
                    deleteCmd.CommandText = "DELETE FROM FORMB WHERE DOCKEY = :dockey AND VERKEY = :verkey AND USERSESSION = :usersession";
                    deleteCmd.Parameters.Add("dockey", form.DOCKEY);
                    deleteCmd.Parameters.Add("verkey", form.VERKEY);
                    deleteCmd.Parameters.Add("usersession", form.USERSESSION);
                    OracleTransaction trans = conn.BeginTransaction();
                    try
                    {
                        deleteCmd.ExecuteNonQuery();
                        trans.Commit();
                    }
                    catch (InvalidOperationException ioe)
                    {
                        //not able to delete the temp row. Roll back the transaction. 
                        trans.Rollback();
                        //TODO what else should be done here to handle the error? Log it and move on?
                    }
                }
            }

            //Now need to populate the item temptable.
            PopulateItemModel("FORM B", form.DOCKEY, form.USERSESSION, form.VERKEY);
        }

        public override void GetXml()
        {
            GetSpecificXml(form);
            GetSpecificXml(itemForm);
        }

        public override void ContinuationPageProcessing(XmlDocument itemsXml)
        {
            //Call base version to get some initial processing done. 
            base.ContinuationPageProcessing(itemsXml);

            //Now add "Continued..." lines in the correct spot for this form.
            //FormB has 11 rows on the cover page, then 30 rows on the 2nd page
            //and all others on the FormX continuation page.
            //Need 2 "Continued..." rows.
            XDocument itemsXdoc;
            using (XmlNodeReader xReader = new XmlNodeReader(itemsXml))
            {
                itemsXdoc = XDocument.Load(xReader);
            }

            XElement continuedItem11 = new XElement("ITEMPRINT",
                                        new XElement("LINENO", 11),
                                        new XElement("ITEMTEXT", "        Continued ...")
                                        );

            XElement continuedItem30 = new XElement("ITEMPRINT",
                                        new XElement("LINENO", 41),
                                        new XElement("ITEMTEXT", "        Continued ...")
                                        );
            //Add new element as the 11th
            itemsXdoc.Descendants("ITEMPRINT").ElementAt(9).AddAfterSelf(continuedItem11);
            //Add new element as the 30th on page 2 (40th, not counting the new row from item 11)
            itemsXdoc.Descendants("ITEMPRINT").ElementAt(39).AddAfterSelf(continuedItem30);

            //update the original XmlDocument
            using (XmlReader xReader = itemsXdoc.CreateReader())
            {
                itemsXml.Load(xReader);
            }
        }
    }
}
