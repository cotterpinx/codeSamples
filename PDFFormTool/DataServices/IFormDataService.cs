using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Xml;
using log4net;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Foo.Forms.Model;

namespace Foo.Forms.DataServices
{
    public interface IFormDataService
    {

        void GetFormData();

        void PopulateFormModel();

        void GetXml();

        void ContinuationPageProcessing(XmlDocument xmlDoc);

        MemoryStream FillForm();
    }
}
