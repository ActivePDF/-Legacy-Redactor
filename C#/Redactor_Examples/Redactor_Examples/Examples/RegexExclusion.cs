
using System;

namespace Redactor_Examples
{
    class RegexExclusion
    {
        /*
         * Uses a regular expression to find and redact phone numbers on pages, 
         * but excludes the number "(555) 555-5555" whenever it is found,
         * leaving it unredacted.
         */
        public static void Example()
        {
            using (APRedactor.Redactor redact = new APRedactor.Redactor(
                filename: @"..\..\..\Input\Redactor.Input.pdf"))
            {
                redact.TextMode = APRedactor.Redactor.TextRedactionMode.Regex;
                redact.PageRegex = APRedactor.RegexPresets.PhoneNumber;

                // It is not used in this example, but the RegexExclusionList
                // also applies to the MetadataRegex, BookmarkRegex, and
                // FormFieldRegex properties in addition to the PageRegex
                // property.
                // Comment out the next line and the phone number at the bottom
                // of page two will be redacted.
                redact.RegexExclusionList = new string[] { "866-468-6733" };

                int redactionsPerformed = redact.Redact();
                redact.Save(@"..\..\..\Output\RegexExclusion.pdf");
                Console.WriteLine($"{redactionsPerformed} text and image redactions performed on document.");
                redact.Save(filename: @"..\..\..\Output\RegexExclusion.pdf");
                Console.WriteLine("Redacted page saved to RegexExclusion.pdf");
            }
        }
    }
}
