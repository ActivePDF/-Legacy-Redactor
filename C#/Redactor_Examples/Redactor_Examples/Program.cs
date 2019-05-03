
using System;

namespace Redactor_Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (!System.IO.Directory.Exists(@"..\..\..\Output"))
                {
                    System.IO.Directory.CreateDirectory(@"..\..\..\Output");
                }

                Console.WriteLine("Redacting text by regular expression ...");
                RedactByRegex.Example();
                Console.WriteLine();

                Console.WriteLine("Redacting text and images by region ...");
                RedactByRegion.Example();
                Console.WriteLine();

                Console.WriteLine("Redacting all text from the document ...");
                RedactEntirePage.Example();
                Console.WriteLine();

                Console.WriteLine("Redacting all images from the document ...");
                RedactImages.Example();
                Console.WriteLine();

                Console.WriteLine("Redacting bookmarks ...");
                RedactBookmarks.Example();
                Console.WriteLine();

                Console.WriteLine("Redacting text from form fields ...");
                RedactFormFields.Example();
                Console.WriteLine();

                Console.WriteLine("Redacting from images by subregion ...");
                RedactIndividualPixels.Example();
                Console.WriteLine();

                Console.WriteLine("Redacting multiple string literals ...");
                RedactManyLiteralStrings.Example();
                Console.WriteLine();

                Console.WriteLine("Redacting document metadata ...");
                RedactMetadata.Example();
                Console.WriteLine();

                Console.WriteLine("Redacting regular expression presets ...");
                RedactPreset.Example();
                Console.WriteLine();

                Console.WriteLine("Redacting by range of pages ...");
                RedactRangeOfPages.Example();
                Console.WriteLine();

                Console.WriteLine("Redacting all text and images ...");
                RedactTextAndImages.Example();
                Console.WriteLine();

                Console.WriteLine("Exluding string literal from redaction ...");
                RegexExclusion.Example();
                Console.WriteLine();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
