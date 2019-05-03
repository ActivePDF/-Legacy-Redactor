
using System;
using System.Text.RegularExpressions;

namespace Redactor_Examples
{
    class RedactBookmarks
    {
        /*
         * Redacts bookmarks in the document, using both search-and-replace
         * literals and match-and-replace regex.
         */
        public static void Example()
        {
            using (APRedactor.Redactor redact = new APRedactor.Redactor(
                filename: @"..\..\..\Input\Redactor.Input.pdf"))
            {
                // You can remove specific bookmarks like this which will
                // redact a bookmark with the title "ActivePDF"
                redact.BookmarkLiteralText = new string[] { "ActivePDF" };

                // You can also remove bookmarks matching a pattern like this.
                // This example will redact all bookmark titles beginning with\
                // 'd' or 'D'
                redact.BookmarkRegex = new Regex(pattern: @"\b[d|D](\S+)\s?");

                int redactionsPerformed = redact.Redact();
                Console.WriteLine($"{redactionsPerformed} redactions performed.");
                redact.Save(filename: @"..\..\..\Output\RedactBookmarks.pdf");
                Console.WriteLine("Redacted page saved to RedactImages.pdf");
            }
        }
    }
}
