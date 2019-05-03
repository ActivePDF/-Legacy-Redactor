
using System;

namespace Redactor_Examples
{
    class RedactTextAndImages
    {
        /*
         * Removes all text and images from pages.
         */
        public static void Example()
        {
            using (APRedactor.Redactor redact = new APRedactor.Redactor(
                filename: @"..\..\..\Input\Redactor.Input.pdf"))
            {
                redact.TextMode = APRedactor.Redactor.TextRedactionMode.Unconditional;
                redact.ImageMode = APRedactor.Redactor.ImageRedactionMode.Unconditional;
                int redactionsPerformed = redact.Redact();                
                Console.WriteLine($"{redactionsPerformed} text and image redactions performed on document.");
                redact.Save(filename: @"..\..\..\Output\RedactTextAndImages.pdf");
                Console.WriteLine("Redacted page saved to RedactTextAndImages.pdf");
            }
        }
    }
}
