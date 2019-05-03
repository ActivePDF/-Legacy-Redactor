
using System;

namespace Redactor_Examples
{
    class RedactPreset
    {
        /*
         * Redacts all phone number instances on pages using a Regular
         * Expression.
         */
        public static void Example()
        {
            using (APRedactor.Redactor redact = new APRedactor.Redactor(
                filename: @"..\..\..\Input\Redactor.Input.pdf"))
            {
                // Redactor supports a wide range of preset regular expressions
                // from phone numbers, dates, email addresses and more.
                redact.PageRegex = APRedactor.RegexPresets.PhoneNumber;
                redact.TextMode = APRedactor.Redactor.TextRedactionMode.Regex;

                redact.FormFieldRegex = APRedactor.RegexPresets.USD;

                int redactionsPerformed = redact.Redact();
                Console.WriteLine($"{redactionsPerformed} redaction performed on document.");
                redact.Save(@"..\..\..\Output\RedactPreset.pdf");
                Console.WriteLine("Redacted page saved to RedactPreset.pdf");
            }
        }
    }
}
