PDFNet SDK is the ultimate PDF toolkit.

With PDFNet components you can build reliable & speedy applications that can view, create, 
print, edit, and annotate PDFs ... across operating systems.

Developers use PDFNet SDK to read, write, and edit PDF documents compatible with all published
versions of PDF specification (including the latest ISO32000). The extensive PDF library API 
supports most common use-case scenarios such as:

*        PDF Viewing & Collaboration
*        PDF Rasterization
*        PDF Printing
*        PDF Form filling and flattening
*        PDF Split & Merge
*        PDF Stamping
*        Dynamic PDF generation (e.g. FlowDocument & Xaml to PDF)
*        PDF Text extraction and indexing
*        PDF Packages
*        PDF Layers (OCGs)
*        PDF Editing
*        PDF Encryption
*        Manipulate PDF bookmarks, links, and annotations.
*        PDF Optimization
*        PDF conversion to XML, HTML, XPS, SVG, TIF, etc.
*        PDF/A Validation and Conversion
*        PDF Redaction
*        PDF Conversion from XPS, MS Office, HTML, XAML, TXT, TIFF etc.
*        HTML to PDF Conversion

***********************************************************************************
*********************************** Quick Start ***********************************
***********************************************************************************
Add the following line of code to your Program.cs, or similar file.

  private static pdftron.PDFNetLoader loader = pdftron.PDFNetLoader.Instance();

This static initialization must occur before any call to PDFNet, so that the correct
PDFNet library (x86 or x64) will be loaded. This is not required if you are targeting
x86 or x64 platforms, but is very helpful if you are targeting AnyCPU platform.

Next, add the following code somewhere that will ensure it will be called before any other
calls to PDFNet.

  pdftron.PDFNet.Initialize();

You are now ready to use PDFNet, see the Getting Started Guides below, or head
straight to the samples page.
http://www.pdftron.com/pdfnet/samplecode.html

***********************************************************************************
************************************ Important ************************************
***********************************************************************************

The PDFNet SDK relies on the Microsoft VC++ Redistributables. These are included
when you install Visual Studio, but may not be present on target machines when
redistributing your application.

Furthermore, the exact redistributable depends on whether you are targeting 
.Net 2.0 - 3.5, or .Net 4+. See the Getting Started Guides below for more 
information on this topic.

**************************
  Getting Started Guides
**************************

.Net 2.0 - 3.5 | https://api.pdftron.com/v2/view/NmY2MTYxNDctNTRlYS00NzFjLWJkNzEtZTI0YjQyNmE1ZmYw
.Net 4.0 +     | https://api.pdftron.com/v2/view/ODdhZjFkYjAtYmQ0Yy00ODg5LWIyYjktZjI0NmI1NGVhYjdh

********************
  Package Contents
********************
build
  net20
    PDFNet           - .Net 2.0 - 3.5 PDFNet CLR libraries
    PDFNet.targets   - MSBuild script to copy PDFNet CLR libraries to binary output folder
  net40
    PDFNet           - .Net 4.0+ PDFNet CLR libraries
    PDFNet.targets   - MSBuild script to copy PDFNet CLR libraries to binary output folder
lib
  net20
    PDFNet.dll       - PDFNet x86 for .Net 2.0-3.5. 'Copy Local: false'
    PDFNetLoader.dll - Loads x86 or x64 PDFNet library at runtime (e.g. side-by-side assembly loading)
  net40
    PDFNet.dll       - PDFNet x86 for .Net 4.0+. 'Copy Local: false'
    PDFNetLoader.dll - Loads x86 or x64 PDFNet library at runtime (e.g. side-by-side assembly loading)
tools
  install.ps1        - Sets lib/net[20|40]/PDFNet.dll to 'Copy Local:false'
PDFNet_License.pdf
readme.txt

*************
  Resources
*************

PDFNet API                  | www.pdftron.com/pdfnet/docs/PDFNet
Sample Code                 | www.pdftron.com/pdfnet/samplecode.html
Stackoverflow               | stackoverflow.com/questions/tagged/pdftron+or+pdfnet
Forum                       | groups.google.com/forum/?fromgroups#!forum/pdfnet-sdk
Blog                        | blog.pdftron.com
PDF and PDFNet Introduction | www.pdftron.com/pdfnet/intro.html
PDFNetLoader Source Code    | github.com/PDFTron/PDFNetLoader

**************************
  Purchasing / Licensing
**************************

http://www.pdftron.com/licensing/index.html

Copyright 2014 PDFTron Systems, Inc, All Rights Reserved