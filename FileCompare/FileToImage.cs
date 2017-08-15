using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using XsPDF.Pdf;
using NUnit.Framework;
using ImageMagick;
using Bytescout.PDFRenderer;
using System;
using Ionic.Zip;


namespace FileCompare
{
    class FileToImage
    {
        public string ReadFileName()
        {
            start:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*** To exit, type 'EXIT' and hit Enter key ***\n");
            Console.WriteLine("Enter file name in temp location:");
            string fileName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(fileName) || fileName[0] == ' ' || fileName[0] == '\t')
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nEntered file path was null or just had white spaces, try entering correct file name or type 'EXIT' to exit. You have entered '"+ fileName +"' file name.\n");
                goto start;

            }
            string defaultPath = @"C:\temp\";


            while (fileName != @"EXIT")
            {

                if (File.Exists(defaultPath + fileName))
                {
                    Console.WriteLine("Found entered file " + fileName, "\n");
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("'" + fileName +
                                      "' not found, the following files exists in this dictonary. Select a file to continue\n");
                    string[] filePaths = Directory.GetFiles(@"C:\temp\");
                    //Console.WriteLine(filePaths.Length.ToString());
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(string.Join("\n", filePaths));
                    Console.WriteLine("\n");
                    goto start;

                }

            }

            if (fileName.Equals("EXIT"))
            {
                Environment.Exit(0);

            }
            return fileName;
            
            
           
        }

        /*
         * This will take in a PDF and convert to one image
         */
        public void ConvertAllPdfPageToOneImage()
        {
            Console.WriteLine("\nExecuting 'ConvertAllPdfPageToOneImage'");

            var fileName = ReadFileName();
           
            // Create an instance of Bytescout.PDFRenderer.RasterRenderer object and register it.
            string filePath = @"C:\temp\" + fileName;
            string defaultPath = @"C:\temp\";

            RasterRenderer renderer = new RasterRenderer();
            renderer.RegistrationName = "demo";
            renderer.RegistrationKey = "demo";

            // Load PDF document.
            renderer.LoadDocumentFromFile(filePath);

            // page to start from 
            int StartPageIndex = 0;
            // page to end on
            int EndPageIndex = renderer.GetPageCount() - 1;
            float renReso = 300;
            renderer.SaveMultipageTiff(defaultPath + "LongImage.tiff", StartPageIndex, EndPageIndex, renReso);
        }

        /*
         * Below code will convert a PDF file to images. If a PDF file contained 10 pages, then there should be 10 images
         */
        public void ConvertPdfPageToImages()
        {
            Console.WriteLine("\nExecuting 'ConvertPdfPageToImages'");
            var fileName = ReadFileName();

            // Create an instance of Bytescout.PDFRenderer.RasterRenderer object and register it.
            string filePath = @"C:\temp\" + fileName;
            string defaultPath = @"C:\temp\Actual\";
            Directory.CreateDirectory(defaultPath);
            DirectoryInfo di = new DirectoryInfo(defaultPath);

            //Delete everything in file
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
            RasterRenderer renderer = new RasterRenderer();
            renderer.RegistrationName = "demo";
            renderer.RegistrationKey = "demo";

            // Load PDF document.
            renderer.LoadDocumentFromFile(filePath);

            // Set rendering resolution
            float renReso = 300;

            for (int i = 0; i < renderer.GetPageCount(); i++)
            {
                renderer.Save(defaultPath + "P" + i + ".tiff", RasterImageFormat.TIFF, i, renReso);
            }
        }

        public void PdfToImage()
        {
            Console.WriteLine("\nExecuting 'PdfToImage'");

            var fileName = ReadFileName();

            string filePath = @"C:\temp\" + fileName;
            string defaultPath = @"C:\temp\";

            // Create a PDF converter instance by loading a local file 
            PdfImageConverter pdfConverter = new PdfImageConverter(filePath);

            // Set the dpi, the output image will be rendered in such resolution
            pdfConverter.DPI = 300;


            for (int i = 0; i < pdfConverter.PageCount; i++)
            {
                // Convert each pdf page to jpeg image with original page size
                //Image pageImage = pdfConverter.PageToImage(i);
                // Convert pdf to jpg in customized image size

                Image pageImage = pdfConverter.PageToImage(i, 2000, 3200);

                // Save converted image to jpeg format
                pageImage.Save(defaultPath + "Page" + i + ".jpg", ImageFormat.Jpeg);
            }
        }

        //public void PdfToImageImageMagick()
        //{
        //    Console.WriteLine("Enter file name in temp location:");
        //    string FileName = Console.ReadLine();
        //    string filePath = @"C:\temp\" + FileName;
        //    string defaultPath = @"C:\temp\";
        //    MagickReadSettings settings = new MagickReadSettings();
        //    // Settings the density to 300 dpi will create an image with a better quality
        //    settings.Density = new Density(300, 300);

        //    using (MagickImageCollection images = new MagickImageCollection())
        //    {
        //        // Add all the pages of the pdf file to the collection
        //        images.Read(filePath, settings);

        //        int page = 1;
        //        foreach (MagickImage image in images)
        //        {
        //            // Write page to file that contains the page number
        //            image.Write(defaultPath + "Page" + page + ".jpg");
        //            // Writing to a specific format works the same as for a single image
        //            //image.Format = MagickFormat.Ptif;
        //            //image.Write("Snakeware.Page" + page + ".tif");
        //            page++;
        //        }
        //    }
        //}



        public void PdfImageCompare()
        {
            Console.WriteLine("\nExecuting 'PdfImageCompare'");

            var diffImagePath = @"C:\temp\Diff\";
            Directory.CreateDirectory(diffImagePath);

            DirectoryInfo di = new DirectoryInfo(diffImagePath);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }

            // Get the current directory.
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            var expected = basePath + @"Resources\BaseNotices\";
            var actual = @"C:\temp\Actual\";

            DirectoryInfo expecteddir = new DirectoryInfo(expected);
            DirectoryInfo actualdir = new DirectoryInfo(actual);

            var expectedCount = expecteddir.GetFiles().Length;
            var actualCount = actualdir.GetFiles().Length;

            //Assert.AreEqual(expectedCount.ToString(), actualCount.ToString());
            if (expectedCount == actualCount)
            {

             }
            else
            {
                Assert.Fail("Count of file did not match");
            }
            for (int i = 0; i < expectedCount; i++)
            {
                using (MagickImage baseImage = new MagickImage(expected + "p" + i + ".tiff"))
                using (MagickImage actualImage = new MagickImage(actual + "p" + i + ".tiff"))
                using (MagickImage diffImage = new MagickImage())
                {
                    baseImage.ColorFuzz = new Percentage(5);

                    //The difference will be shown in Red, where Red is the difference from the actualImage
                    baseImage.Compare(actualImage, ErrorMetric.Fuzz, diffImage);

                    diffImage.Write(diffImagePath + "D" + i + ".tiff");
                }
            }

            // Compress the dif folder to ZIP file

            var pathToSaveZip = diffImagePath.TrimEnd('\\') + ".zip";
            try
            {
                File.Delete(pathToSaveZip);
            }
            catch (Exception)
            {
                Console.WriteLine("Could not delete ZIP file {0}", pathToSaveZip);
            }

            using (ZipFile zip = new ZipFile())
            {
                zip.AddDirectory(diffImagePath);
                zip.Save(pathToSaveZip);
            }
        }

        public void S2PdfImageCheck1()
        {
            var diffImagePath = @"C:\temp\Diff\";
            DirectoryInfo di = new DirectoryInfo(diffImagePath);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }


            //var defaultImage = @"C:\Users\svasanth\Source\Repos\GVD\Hs2NpsBdd\UnitTestProject1\utils\BasePDFImges\GVX\GVD.tiff";
            //var defaultImage = @"C:\temp\Page 1.jpg";
            //var imageToCompare = @"C:\temp\GVDA.tiff";

            //var actual = @"C:\temp\Actual\";
            var actual = @"C:\temp\ActualS2\";

            //var expected = @"C:\temp\Expected\";


            // Get the current directory.
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            var expected = basePath + @"\resources\BaseNotices\S2BaseNotice\";


            DirectoryInfo actualdir = new DirectoryInfo(actual);
            DirectoryInfo expecteddir = new DirectoryInfo(expected);

            int actualCount = actualdir.GetFiles().Length;
            int expectedCount = expecteddir.GetFiles().Length;


            //var diffImagePath1 = @"C:\temp\imageDiff1.jpg";

            if (actualCount.Equals(expectedCount))
            {
                for (int i = 0; i < expectedCount; i++)
                {
                    using (MagickImage image1 = new MagickImage(actual + "p" + i + ".tiff"))
                    using (MagickImage image2 = new MagickImage(expected + "p" + i + ".tiff"))
                    using (MagickImage diffImage = new MagickImage())
                    {
                        //MagickImage diffImage1 = new MagickImage();


                        image1.ColorFuzz = new Percentage(2);

                        //image2.Grayscale(PixelIntensityMethod.Rec601Luma);

                        image1.Compare(image2, ErrorMetric.Fuzz, diffImage);

                        diffImage.Write(diffImagePath + "D" + i + ".tiff");
                    }
                }
            }
            else
            {
                Assert.Fail("File count equal for {0} & {1}", actualdir, expectedCount);
            }
        }

        public enum AquTypes
        {
            S2,
            S16,
            GPN,
            GVDSTD,
            GVDBlight,
            GVDPreS16,
            GVDNttNoite,
            CosNov,
            SOS
        }
    }
}
