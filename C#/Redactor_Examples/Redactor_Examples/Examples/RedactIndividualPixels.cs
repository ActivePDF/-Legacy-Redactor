
using System;

namespace Redactor_Examples
{
    class RedactIndividualPixels
    {
        /*
         * Shows an example of redacting individual pixels from an image
         * contained on a page. This is useful for a number of applications,
         * including: removing some copyrighted logo from an image, removing
         * some faces from a photo, removing text stored as an image because
         * the document was scanned, or anything else. The color that the
         * pixels are replaced with is set by the ReplacementColor property.
         */
        public static void Example()
        {
            using (APRedactor.Redactor redact = new APRedactor.Redactor(
                filename: @"..\..\..\Input\Redactor.Input.pdf"))
            {
                // Getting the coordinates for what to redact is left to you,
                // as they vary from document to document. Remember that you
                // can call Redactor.GetPageSize() to get the size of each page
                // as a starting point. You can combine Redactor with tools
                // like ActivePDF Rasterizer to get images to display, allowing
                // the user to draw boxes that you can convert to coordinates.
                // Or you can use ActivePDF Extractor to find the coordinates
                // of specific content. Or, if you are redacting many documents
                // with the same layout, you can figure out the coordinates
                //once and apply them to all inputs.

                // This creates an array of regions that will find two
                // rectangles on page 1, one on page 2, and one on page 3.
                // Since the ImageMode is set to Subregion, it only applies to
                // individual pixels found in those rectangles. You can use the
                // same regions for Text by setting the TextMode to Region and
                // assigning to the TextRegions property, if you desire.
                APRedactor.RedactRegion[] regions = new APRedactor.RedactRegion[]
                {
                    new APRedactor.RedactRegion(
                        pageNumber: 1,
                        region: new APRedactor.Rectangle(x: 284.5125f,
                                                         y: 122.2324f,
                                                         w: 202.5f,
                                                         h: 118.4625f))
                };

                // Don't forget to update the file given to the Constructor and
                // the Save function! Be sure to set the text or image mode or
                // the test will do nothing! These apply only to images stored
                // within the PDF, and will not affect any text or graphics.
                redact.TextMode = APRedactor.Redactor.TextRedactionMode.None;
                redact.ImageMode =
                    APRedactor.Redactor.ImageRedactionMode.Subregion;
                redact.ImageRegions = regions;

                int redactionsPerformed = redact.Redact();
                redact.Save(filename: @"..\..\..\Output\RedactIndividualPixels.pdf");
                Console.WriteLine("Redacted page saved to RedactIndividualPixels.pdf");
            }
        }
    }
}
