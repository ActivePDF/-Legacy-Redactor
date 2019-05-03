
using System;

namespace Redactor_Examples
{
    class RedactImages
    {
        /*
        * Redacts all images on pages.
        */
        public static void Example()
        {
            using (APRedactor.Redactor redact = new APRedactor.Redactor(
                filename: @"..\..\..\Input\Redactor.Input.pdf"))
            {
                redact.ImageMode =
                    APRedactor.Redactor.ImageRedactionMode.Unconditional;
                int redactionsPerformed = redact.Redact();
                Console.WriteLine($"{redactionsPerformed} redactions performed.");
                redact.Save(@"..\..\..\Output\RedactImages.pdf");
                Console.WriteLine("Redacted page saved to RedactImages.pdf");
            }
        }
    }
}
