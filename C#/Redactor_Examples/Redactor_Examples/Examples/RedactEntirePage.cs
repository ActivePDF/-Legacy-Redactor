
using System;

namespace Redactor_Examples
{
    class RedactEntirePage
    {
        /*
        * Removes all text from all pages, and draws a black box on each page.
        */
        public static void Example()
        {
            using (APRedactor.Redactor redact = new APRedactor.Redactor(
                filename: @"..\..\..\Input\Redactor.Input.pdf"))
            {
                redact.TextMode =
                    APRedactor.Redactor.TextRedactionMode.Unconditional;
                int redactionsPerformed = redact.Redact();
                redact.Save(@"..\..\..\Output\RedactEntirePage.pdf");
                Console.WriteLine("Redacted page saved to RedactEntirePage.pdf");
            }
        }
    }
}
