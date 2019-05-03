
using System;

namespace Redactor_Examples
{
    class RedactByRegion
    {
        /*
        * Redacts both text and images that are contained the middle third of
        * each page. Because each page of a document can be a different size,
        * it is necessary to fetch the size of a page, and perform the
        * redaction operation, one page at a time.
        */
        public static void Example()
        {
            using (APRedactor.Redactor redact = new APRedactor.Redactor(
                filename: @"..\..\..\Input\Redactor.Input.pdf"))
            {
                redact.TextMode = APRedactor.Redactor.TextRedactionMode.Region;
                redact.ImageMode =
                    APRedactor.Redactor.ImageRedactionMode.Region;
                for(int pageNumber = 1;
                    pageNumber <= redact.PageTotal;
                    pageNumber++)
                {
                    redact.FirstPage = redact.LastPage = pageNumber;
                    float pageWidth, pageHeight;
                    redact.GetPageSize(
                        pageNumber: pageNumber,
                        width: out pageWidth,
                        height: out pageHeight);
                    APRedactor.RedactRegion[] regions =
                        new APRedactor.RedactRegion[] 
                    {
                        new APRedactor.RedactRegion(pageNumber: pageNumber, 
                            region: new APRedactor.Rectangle(
                                x: pageWidth / 3,
                                y: pageHeight / 3,
                                w: pageWidth / 3,
                                h: pageHeight / 3))
                    };
                    redact.TextRegions = regions;
                    redact.ImageRegions = regions;
                    int redactionsPerformed = redact.Redact();
                    Console.WriteLine($"{redactionsPerformed} on Page {pageNumber}");
                }
                redact.Save(@"..\..\..\Output\RedactByRegion.pdf");
                Console.WriteLine("Redacted page saved to RedactByRegion.pdf");
            }
        }
    }
}
