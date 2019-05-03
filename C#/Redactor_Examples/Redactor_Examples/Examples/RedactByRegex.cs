
using System;
using System.Text.RegularExpressions;

namespace Redactor_Examples
{
    class RedactByRegex
    {
        /*
        * Use a regular expression to find and redact content on pages,
        * metadata, bookmarks, and form fields.
        */
        public static void Example()
        {
            using (APRedactor.Redactor redact = new APRedactor.Redactor(
                filename: @"..\..\..\Input\Redactor.Input.pdf"))
            {
                // You can also find some common use cases in
                // APRedactor.RegexPresets
                redact.TextMode = APRedactor.Redactor.TextRedactionMode.Regex;

                // Redact the word "Family" from bookmark titles
                redact.BookmarkRegex = new Regex(pattern: @"Family");

                // Redact "field" from the text fields
                redact.FormFieldRegex = new Regex(pattern: @"(?-i)field");
                
                // Redact instances of "PDF" from the metadata
                redact.MetadataRegex = new Regex(pattern: @"(?-i)PDF");

                // Redact all words that begin with 'v' or 'V'
                redact.PageRegex = new Regex(pattern: @"\b[v|V](\S+)\s?");                

                int redactionsPerformed = redact.Redact();
                Console.WriteLine($"{redactionsPerformed} redactions performed.");

                // You can view what literals were found in the document after the
                // redaction is done.
                foreach (Tuple<int, string> match in redact.PageRegexMatches)
                {
                    Console.WriteLine($"Redacted {match.Item2} on page {match.Item1}.");
                }
                foreach (string match in redact.BookmarkRegexMatches)
                {
                    Console.WriteLine($"Redacted {match} from bookmarks.");
                }
                foreach (string match in redact.FormFieldRegexMatches)
                {
                    Console.WriteLine($"Redacted {match} from form fields.");
                }
                foreach (string match in redact.MetadataRegexMatches)
                {
                    Console.WriteLine($"Redacted {match} from metadata.");
                }
                redact.Save(filename: @"..\..\..\Output\RedactByRegex.pdf");
                Console.WriteLine("Redacted page saved to RedactByRegex.pdf");
            }
        }
    }
}
