using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Aspose.Pdf;
using log4net;
using Foo.Forms.Model;

namespace Foo.Forms.DataServices
{
    public class BaseFormDataService: IFormDataService
    {
        #region Properties & Members
        private const string connStr = "connection info";
        //Note that this code was used for a proof-of-concept/demo. The production version
        // would *NOT* have a connection string in cleartext here!!

        public BaseForm baseForm { get; set; }

        public ITEMS itemForm { get; set; }

        protected string formTemplate { get; set; }

        protected string functionName { get; set; }

        public XmlDocument xmlInput { get; set; }

        protected static readonly ILog log = LogManager.GetLogger(typeof(BaseFormDataService));

        #endregion


        public BaseFormDataService GetSpecificDataService(int dockey, int verkey)
        {
            log.Debug( "ConnStr is " + connStr);
            using (OracleConnection conn = new OracleConnection(connStr))
            { 
                baseForm = new BaseForm();
                baseForm.DOCKEY = dockey;
                baseForm.VERKEY = verkey;
                conn.Open();

                using (OracleCommand formKeyCmd = conn.CreateCommand())
                {
                    formKeyCmd.CommandText = "SELECT DOCTYPE, FORMKEY FROM HEADER WHERE DOCKEY = :dockey AND VERKEY = :verkey";
                    formKeyCmd.CommandType = CommandType.Text;
                    formKeyCmd.Parameters.Add("dockey", dockey);
                    formKeyCmd.Parameters.Add("verkey", verkey);

                    OracleDataReader dr = formKeyCmd.ExecuteReader();

                    while (dr.Read())
                    {
                        baseForm.DOCTYPE = dr.GetInt32(0);
                        baseForm.formkey = dr.GetInt32(1);
                    }
                }
            }

            switch (baseForm.formkey)
            {
                case 0987: //FormA
                    return new FormADataService(baseForm, connStr);
                case 12345: //FormB
                    return new FormBDataService(baseForm, connStr);
                default:
                    //Didn't find a form match. Cannot continue.
                    throw new Exception("Form type not found for formkey = " + baseForm.formkey + ". Cannot continue. ");
            }
        }

        public virtual void GetFormData() { }

        public virtual void PopulateFormModel() { }

        protected void PopulateItemModel(string formNum, int dockey, string userSession, int verkey)
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();

                //Fill the model with the values from the temp table
                using (OracleCommand itemCmd = conn.CreateCommand())
                {
                    itemCmd.CommandText = "SELECT * FROM ITEMPRINT WHERE FORMNUM = :formnum AND HDRDOCKEY = :hdrdockey AND USERSESSION = :usersession AND HDRVERKEY = :hdrverkey";
                    itemCmd.CommandType = CommandType.Text;
                    itemCmd.Parameters.Add("formnum", formNum);
                    itemCmd.Parameters.Add("hdrdockey", dockey);
                    itemCmd.Parameters.Add("usersession", userSession);
                    itemCmd.Parameters.Add("hdrverkey", verkey);

                    using (OracleDataReader ItemReader = itemCmd.ExecuteReader())
                    {
                        ITEMPRINTRowMapper rowMapper = new ITEMPRINTRowMapper();
                        rowMapper.MapRow(ItemReader, itemForm);
                    }
                }

                //Delete the row(s) from the temp table for this document
                using (OracleCommand deleteCmd = conn.CreateCommand())
                {
                    deleteCmd.CommandType = CommandType.Text;
                    deleteCmd.CommandText = "DELETE FROM ITEMPRINT WHERE FORMNUM = :formnum AND HDRDOCKEY = :hdrdockey AND USERSESSION = :usersession AND HDRVERKEY = :hdrverkey";
                    deleteCmd.Parameters.Add("formnum", formNum);
                    deleteCmd.Parameters.Add("hdrdockey", dockey);
                    deleteCmd.Parameters.Add("usersession", userSession);
                    deleteCmd.Parameters.Add("hdrverkey", verkey);
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
        }

        public virtual void GetXml() { }

        public MemoryStream FillForm()
        {
            //Get path to form template
            string path = ConfigurationManager.AppSettings["FormsRootLocation"].ToString();
            string formsPath = Path.Combine(path, formTemplate);

             //TODO check xmlInput, formTemplate for null before using
            XmlNode inputData = xmlInput.DocumentElement;

            //Get reference to empty xfa document template (no data)
            Document xfaDoc;
            try
            {                
                using (FileStream fs = File.Open(formsPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    xfaDoc = new Document(fs);
                }

                if (xfaDoc != null)
                {
                    //get dataset portion of XFA form
                    XmlNode formDatasets = xfaDoc.Form.XFA.Datasets;

                    //get all nodes that are named "xfa:data". (There's really only one.)
                    IEnumerable<XmlNode> nodeList = from XmlNode node in formDatasets.ChildNodes
                                                    where node.Name.Equals("xfa:data", StringComparison.CurrentCultureIgnoreCase)
                                                    select node;

                    MemoryStream ms = new MemoryStream();

                    //Verify that you got exactly 1 match
                    if ((nodeList != null) && (nodeList.Count() == 1))
                    {
                        //get the single XmlNode instance from the nodeList.
                        XmlNode formDataNode = nodeList.FirstOrDefault();

                        //write the contents of the input xml file as child elements of the xfa:data node.
                        formDataNode.AppendChild(formDataNode.OwnerDocument.ImportNode(inputData, true));

                        //save the filled XFA file as a PDF
                        xfaDoc.Save(ms);

                    } //TODO handle case where you get 0 or >1 matches?

                    return ms;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                //TODO -- handle possible file open/read exceptions

                //if you can't read the form, can't get a filled version.
                return null;
            }            
        }

        #region Helper Methods       
        //these should probably just be properties in the specific data services
        protected static string GetFunctionName(string type)
        {
            switch (type)
            {
                case "FormC":
                    return "FORM_FormC";
                case "FormX":
                    return "FORM_FormX";
                case "FormD":
                    return "FORM_FormD";
                case "FormA":
                    return "FORM_FormA";
                default:
                    return "Form Not Found";
            }
        }

        protected void GetSpecificXml(object model)
        {
            //TODO make sure signature BLOB data is getting serialized correctly
            //Should come over as an image. Check schema.
            DataContractSerializer ds = new DataContractSerializer(model.GetType());

            MemoryStream ms = new MemoryStream();
            ds.WriteObject(ms, model);
            ms.Position = 0;

            XmlDocument modelXml = new XmlDocument();
            modelXml.Load(ms);


            //Check to see if we are processing the model for the continuation page --
            //if so, do some specific processing 
            if (model.GetType().Name.Equals("ITEMS")) {
                ContinuationPageProcessing(modelXml);
            }

            //get root node from model, append it to the inputXml document.
            XmlNode modelNode = xmlInput.ImportNode(modelXml.DocumentElement, true);
            xmlInput.DocumentElement.AppendChild(modelNode);
        }


        public virtual void ContinuationPageProcessing(XmlDocument itemsXml)
        {
            //1) Put reference to the CONTPAGEDOCNUM and VADDRESS1 elements at the root
            //of the XML -- makes binding the data for the FormX continuation page
            //work better.
            //
            //2) Remove all trailing blank lines that appear after the last line of item
            // content. They are no longer needed for report spacing.
            //
            //3) Remove all "Continued..." entries. They are no longer needed for report spacing
            // as they can be put in the correct place in the specific data service for the form


            //Check the cover page's XML for VADDRESS1
            //and CONTPAGEDOCNUM -- copy into the top level for data binding 
            //simplicity.
            if (xmlInput.DocumentElement.HasChildNodes)
            {
                XmlNode vAddNode = xmlInput.SelectSingleNode("//VADDRESS1");
                XmlNode cPageNode = xmlInput.SelectSingleNode("//CONTPAGEDOCNUM");

                //If there are no matching elements in the tree, set them as blank entries.
                if (vAddNode == null)
                {
                    vAddNode = xmlInput.CreateNode("element", "VADDRESS1", "");
                }

                if (cPageNode == null)
                {
                    cPageNode = xmlInput.CreateNode("element", "CONTPAGEDOCNUM", "");
                }

                xmlInput.DocumentElement.InsertAfter(vAddNode, null);
                xmlInput.DocumentElement.InsertAfter(cPageNode, null);
            }

            //Need to remove empty lines that appear after the item text. 
            //(After the last actual content) They
            //are no longer needed for spacing in the reports.
            XDocument itemsXdoc;
            using (XmlNodeReader xReader = new XmlNodeReader(itemsXml))
            {
                itemsXdoc = XDocument.Load(xReader);
            }

            //Get the linenos for all items with non-empty ITEMTEXT fields
            var textLineNos =
                    from item in itemsXdoc.Descendants("ITEMPRINT")
                    where !item.Element("ITEMTEXT").IsEmpty
                    select item.Element("LINENO");

            //Get the linenos for all items with "Continued..." in the ITEMTEXT fields
            var continuedLineNos =
                    from item in itemsXdoc.Descendants("ITEMPRINT")
                    where item.Element("ITEMTEXT").Value.Trim().Equals("Continued ...")
                    select item.Element("LINENO");

            //Remove all ITEMPRINT nodes with LINENO values higher than the last one with content;
            //they are padding and can be omitted.
            itemsXdoc.Descendants("ITEMPRINT").Where(itemprint => (int)itemprint.Element("LINENO") > (int)textLineNos.Last()).Remove();

            //Remove all ITEMPRINT nodes with the specified LINENO values (lines w/"Continued...")
            itemsXdoc.Descendants("ITEMPRINT").Where(itemprint => continuedLineNos.Contains(itemprint.Element("LINENO"))).Remove(); 

            //update the original XmlDocument
            using (XmlReader xReader = itemsXdoc.CreateReader())
            {
                itemsXml.Load(xReader);
            }
        }

        #endregion
    }
}
