namespace exam__linq
{
    public class TextProcessor
    {
        public bool AreAllPositiveNumbers(List<int> numbers)
        {
            return numbers.All(number => number > 0);
        }

        public List<Tuple<string, string>> SplitWordsByLength(string text)
        {
            string[] words = text.Split(new[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            List<Tuple<string, string>> dividedWords = words
                .Select(word => word.Length > 5 ? Tuple.Create("Birinchi", word) : Tuple.Create("Ikkinchi", word))
                .ToList();
            return dividedWords;
        }

        public List<int> CountLetterOInWords(string text)
        {
            string[] words = text.Split(new[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> counts = words.Select(word => word.Count(letter => letter == 'o' || letter == 'O')).OrderBy(count => count).ToList();
            return counts;
        }
    }

    public class LINQ6
    {
        public void LINQ()
        {
            List<int> positiveNumbers = new List<int> { 42, 18, 7, 99, 123 };
            string text = "Bu matnda 42 raqam, 18 raqam va boshqa raqamlar mavjud. Ular orqa daraxtlar orasida orqaga borishganlar. Matnlar orqali alifboga o'rgangiz.";

            TextProcessor textProcessor = new TextProcessor();

            // 6.1
            bool areAllPositive = textProcessor.AreAllPositiveNumbers(positiveNumbers);
            Console.WriteLine("6.1. Barcha sonlar musbatmi? " + areAllPositive);

            // 6.2
            List<Tuple<string, string>> dividedWords = textProcessor.SplitWordsByLength(text);
            Console.WriteLine("6.2. So'zlar bo'limlari:");
            foreach (var wordTuple in dividedWords)
            {
                Console.WriteLine($"{wordTuple.Item1}: {wordTuple.Item2}");
            }

            // 6.3
            List<int> letterOCounts = textProcessor.CountLetterOInWords(text);
            Console.WriteLine("6.3. So'zlardagi o harfi soni: " + string.Join(", ", letterOCounts));
        }
    }

}
