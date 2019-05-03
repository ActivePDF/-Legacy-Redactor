
using System;

namespace Redactor_Examples
{
    class RedactManyLiteralStrings
    {
        /*
         * Redacts a number of secret terms from the input document, all at
         * once, by using IEnumerable<string>. 
         */
        public static void Example()
        {
            using (APRedactor.Redactor redact = new APRedactor.Redactor(
                filename: @"..\..\..\Input\Redactor.Input.pdf"))
            {
                // In this example, we use string[] for simplicity. However,
                // any IEnumerable<string> is allowed, including but not
                // limited to: List<string>, LinkedList<string>, Stack<string>,
                // Array<string>, HashSet<string>, etc.
                redact.PageLiteralText = new string[] 
                {
                    "redactor", "redact", "Windows", "Microsoft",
                    "social security", "phone", "email", "date"
                };
                redact.TextMode =
                    APRedactor.Redactor.TextRedactionMode.LiteralText;

                // These are not limited to just content on pages. If you want
                // to remove these same terms from bookmarks, metadata, and
                // form fields, you can assign the same array to those
                // properties. You can just as easily redact different literals
                // from those sections of the document as well.
                redact.MetadataLiteralText = new string[]
                {
                    "Active", "PDF", "Redactor"
                };

                int redactionsPerformed = redact.Redact();
                Console.WriteLine($"{redactionsPerformed} performed on document.");
                redact.Save(filename: @"..\..\..\Output\RedactManyLiteralStrings.pdf");
                Console.WriteLine("Redacted page saved to RedactManyLiteralStrings.pdf");
            }
        }
    }
}
