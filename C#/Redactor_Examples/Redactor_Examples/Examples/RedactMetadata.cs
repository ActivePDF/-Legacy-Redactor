
using System;

namespace Redactor_Examples
{
    class RedactMetadata
    {
        public static void Example()
        {
            /*
             * Redacts the values in the document properties, as well as anything 
             * that looks like an email address, from the document's metadata.
             */
            using (APRedactor.Redactor redact = new APRedactor.Redactor(
                filename: @"..\..\..\Input\Redactor.Input.pdf"))
            {
                //You can redact specific values from the metadata like this. 
                redact.MetadataLiteralText = new string[]
                {
                    "Digital", "ActivePDF"
                };

                //You can also redact values matching a pattern like this.
                //You can put any regex you want in place of our presets.
                redact.MetadataRegex = APRedactor.RegexPresets.EmailAddress;

                int redactionsPerformed = redact.Redact();
                Console.WriteLine($"{redactionsPerformed} performed on document.");
                redact.Save(@"..\..\..\Output\RedactMetadata.pdf");
                Console.WriteLine("Redacted page saved to RedactManyLiteralStrings.pdf");
            }
        }
    }
}
