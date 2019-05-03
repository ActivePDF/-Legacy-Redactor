
using System;

namespace Redactor_Examples
{
    class RedactRangeOfPages
    {
        /*
         * Redacts the text "Hello, world!" (not case sensitive) from pages 5-10 only.
         */
        public static void Example()
        {
            using (APRedactor.Redactor redact = new APRedactor.Redactor(
                filename: @"..\..\..\Input\Redactor.Input.pdf"))
            {
                redact.PageLiteralText = new string[] { "the" };
                redact.TextMode = APRedactor.Redactor.TextRedactionMode.LiteralText;
                redact.FirstPage = 1;
                redact.LastPage = 2;
                int redactionsPerformed = redact.Redact();
                redact.Save(@"..\..\..\Output\RedactRangeOfPages.pdf");
                Console.WriteLine($"{redactionsPerformed} redactions performed.");
                redact.Save(@"..\..\..\Output\RedactRangeOfPages.pdf");
                Console.WriteLine("Redacted page saved to RedactRangeOfPages.pdf");
            }
        }
    }
}
