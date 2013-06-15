
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDFlib_dotnet;
using System.IO;



namespace PdfConnector
{
    
    public class MAIN{

        public static List<string> GetPdfs(string dirname) {
            var pdflist = new List<string>();
            foreach (var eachfile in Directory.GetFiles(dirname)) {
                if (eachfile.Contains(".jpeg") || eachfile.Contains(".jpg"))
                {
                    pdflist.Add(eachfile);
                }
            }
            return pdflist;
        }

        public static void main(string resourcePath, AuthInfo auth) {
            PDFlib plib = new PDFlib();
            int image;

            try {
                plib.set_info("Creator", auth.Creator);
                plib.set_info("Title", auth.Title);
                plib.set_option("searchpath={" + resourcePath + "}");
                plib.set_option("errorpolicy=return");

                var outpath = resourcePath.TrimEnd('\\') + @"\Out\";


                if (!Directory.Exists(outpath))
                {
                    Directory.CreateDirectory(outpath);
                }

                plib.begin_document(outpath + "moomi.pdf", "");

                int i = 1;

                foreach (var eachpdf in GetPdfs(resourcePath)) {
                    
                    image = plib.load_image("auto", eachpdf, "");

                    plib.begin_page(700, 1000);

                    int page = i;
                    plib.fit_image(image,0.0,0.0,"");
                    if (page == -1)
                    {
                        throw new Exception("OpenPDI: i: " + i);
                    }

                    plib.end_page();
                    
                    i++;
                }
                
                
                plib.end_document("");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
