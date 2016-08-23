# README #

This project contains pieces of previous work that has been genericized to remove client-specific content.

Lisa McCray
lisa dot d dot mccray at gmail dot com

################
PDFFormTool
################
This folder represents most of a project created as a proof of concept/functional demo. The customer had
an existing web application that collected data from the user and wrote it into an Oracle DB. 
The customer had built PDF forms using an older version of Crystal Reports. 
When requested by the user, the existing application could bring up 
a PDF form, fill it with the appropriate data from the Oracle DB, and present it to the user who could then print
or save it. Each interactive form 
contained a different set of fields and content. The values of the fields were retrieved by calling
a specific Oracle stored procedure which filled a temp table with the needed values, which were then 
bound into the Crystal Reports form.

The customer wished to move away from using CrystalReports and switch to a different solution that would
generate 508-compliant filled PDF forms. The customer already had licenses to use Aspose .NET APIs for 
working with PDFs, but needed a way to build the new (508-compliant) forms and fill them with the 
appropriate data with a minimum of change to the existing application. 

I researched and designed a solution involving the use of Adobe LiveCycle Designer to 
build XFA-based (XML Forms Architecture) interactive forms. I then built a form processing solution
which could be called from the existing application (a one-line change to call the new process
instead of the old one). The new solution was able to continue to call the stored procedures to fill a temp
table of values for a specific form type. The values in the temp table were then serialized into 
an XML model. This XML content was then merged with the underlying XML structure of the PDF file 
as generated in LiveCycle Designer. 

The process was initiated by calling PrintFormManager.PrintForm for a specific document. Most of the
structure of the project is included in these folders. Specific PDF forms have been omitted, fields have
been removed from the models, and items have been renamed to genericize it. Note that as this was intended as
a first draft/working prototype, there were some approaches taken that would NOT be used in the final
production code version. (for example, setting up the connection to the Oracle DB.)





