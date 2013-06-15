using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDFlib_dotnet;


namespace PdfConnector
{
    public class PDI
    {
        public static int Add(PDFlib plib, string pdffile)
        {
            try
            {
                int indoc = plib.open_pdi_document(pdffile, "");
                if (indoc == -1)
                {
                    throw new Exception(string.Format("AddPdi : picture -> {0} not found", pdffile));
                }
                return indoc;
            }catch(Exception ex){
                throw new Exception("PDI::Add: "+ex.Message);
            }
        }
    }
}
