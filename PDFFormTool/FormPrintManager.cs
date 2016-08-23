using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;
using System.IO;
using System.Reflection;
using System.Xml;
using log4net;
using Foo.Forms.DataServices;
using Foo.Forms.Model;


namespace Foo.Forms
{
    public class FormPrintManager
    {
        private const string log4netConfig = "Foo.Forms.log4net.config";

        public FormPrintManager()
        {
            if (!log4net.LogManager.GetRepository().Configured)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                Stream logConfigStream = assembly.GetManifestResourceStream(log4netConfig);

                if (logConfigStream == null)
                {                    
                    throw new FileLoadException(String.Format("The configuration file {0} does not exist", log4netConfig));
                }

                log4net.Config.XmlConfigurator.Configure(logConfigStream);
            }
        }

        public MemoryStream PrintForm(DocumentPK documentPK)
        {
            //Get base dataservice
            BaseFormDataService dataService = new BaseFormDataService();

            //Change reference to specific dataservice for the form type to be printed
            dataService = dataService.GetSpecificDataService(documentPK.DocumentId, documentPK.VersionId);

            //Executes stored procedure/function to fill DB temp tables with data for this award
            dataService.GetFormData();

            //Fills form model object with data from temp table
            dataService.PopulateFormModel();

            //Serializes the form model object to XML
            dataService.GetXml();            

            //Gets form template, uses XML data stream as input, returns filled PDF (as stream).
            return dataService.FillForm();
        }

    }
}
