using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace exam__linq
{
    public class LINQ5
    {
        public  void LINQ()
        {
            List<object> items = new List<object> { 42, "Matn 1", 18, "Matn 2", 7, "Matn 3" };
            string text = "Bu matnda 42 raqam, 18 raqam va boshqa raqamlar mavjud. Ular orqa daraxtlar orasida orqaga borishganlar. Matnlar orqali alifboga o'rgangiz.";

            TextProcessor textProcessor = new TextProcessor();

            // 5.1
            List<int> numbers = textProcessor.ExtractNumbersAndStrings(items);
            Console.WriteLine("5.1. Sonlar: " + string.Join(", ", numbers));

            // 5.2
            List<int> digitsInText = textProcessor.FindAllDigitsInText(text);
            Console.WriteLine("5.2. Topilgan raqamlar: " + string.Join(", ", digitsInText));

            // 5.3
            List<string> orWords = textProcessor.FindWordsStartingWithOr(text);
            Console.WriteLine("5.3. Or so'zi bilan boshlangan so'zlar: " + string.Join(", ", orWords));

            // 5.4
            List<string> aWords = textProcessor.FindWordsWithLetterA(text);
            Console.WriteLine("5.4. a harfi qatnashgan so'zlar: " + string.Join(", ", aWords));
            }
        public class TextProcessor
        {
            public List<int> ExtractNumbersAndStrings(List<object> items)
            {
                List<int> numbers = items.OfType<int>().ToList();
                List<string> strings = items.OfType<string>().ToList();
                return numbers;
            }

            public List<int> FindAllDigitsInText(string text)
            {
                List<int> digits = text.Where(char.IsDigit).Select(c => int.Parse(c.ToString())).ToList();
                return digits;
            }

            public List<string> FindWordsStartingWithOr(string text)
            {
                string[] words = text.Split(new[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                List<string> orWords = words.Where(word => word.StartsWith("or", StringComparison.OrdinalIgnoreCase)).ToList();
                return orWords;
            }

            public List<string> FindWordsWithLetterA(string text)
            {
                string[] words = text.Split(new[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                List<string> aWords = words.Where(word => word.Contains("a", StringComparison.OrdinalIgnoreCase)).ToList();
                return aWords;
            }
        }

    }
}
