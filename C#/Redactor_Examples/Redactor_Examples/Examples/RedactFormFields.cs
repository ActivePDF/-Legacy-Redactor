
using System;

namespace Redactor_Examples
{
    class RedactFormFields
    {
        /*
         * Redacts the literal text "test" and "using" from any form
         * fields on pages. It also uses a regular expression to find and
         * remove anything that looks like an amount in US dollars.
         */
        public static void Example()
        {
            using (APRedactor.Redactor redact = new APRedactor.Redactor(@"..\..\..\Input\Redactor.Input.pdf"))
            {
                //You can find specific values to remove like this.
                redact.FormFieldLiteralText = new string[] { "test", "using" };

                //You can also remove content matching a pattern like this.
                //This one will catch both of the literals from the previous line as well.
                redact.FormFieldRegex = APRedactor.RegexPresets.USD;

                int redactionsPerformed = redact.Redact();
                Console.WriteLine($"{redactionsPerformed} redactions performed.");
                redact.Save(@"..\..\..\Output\RedactFormFields.pdf");
                Console.WriteLine("Redacted page saved to RedactFormFields.pdf");
            }
        }
    }
}
