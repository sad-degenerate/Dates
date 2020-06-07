using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            // MM-DD-YYYY - America.
            // DD-MM-YYYY - Europe.

            // Путь к файлу с текстом и датами.
            var path = "text.txt";

            var date = "";

            using (var sr = new StreamReader(path))
                date = sr.ReadToEnd();

            var result = Convert(date);

            Console.WriteLine("Converted:\n{0}\nto:\n{1}", date, result);
        }

        static string Convert(string date)
        {
            try
            {
                return Regex.Replace(date, @"\b(?<month>\d{1,2})-(?<day>\d{1,2})-(?<year>\d{2,4})\b",
                                        "${day}-${month}-${year}", RegexOptions.None,
                                         TimeSpan.FromMilliseconds(150));
            }
            catch (RegexMatchTimeoutException)
            {
                return date;
            }
        }
    }
}