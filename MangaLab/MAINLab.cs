using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
//
namespace MangaLab
{	
    [TestFixture]
    public class MAINLab{
        [Test]
        public void MAINTest() {
            string resourcePath = @"C:\project\Resources";
            var authinfo = new PdfConnector.AuthInfo { Creator = "", Title = "" };
            PdfConnector.MAIN.main(resourcePath, authinfo);
        }
    }
}
