using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Enter file name from Temp file.
             * For this exercise I have added pdf.pdf file under this project Resources\Test File. Place his file under c:\temp.
             */
            //new FileToImage().ConvertAllPdfPageToOneImage();
            new FileToImage().ConvertPdfPageToImages();
            new FileToImage().PdfImageCompare();
        }
    }
}
