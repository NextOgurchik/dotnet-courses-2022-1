using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Task3
{
    class Program
    {
        static Dictionary<string, int> CountWords(string text)
        {
            Regex regex = new Regex(@"(.+?)(?:,|\.|;|:|\?|!|-| )");
            MatchCollection matches = regex.Matches(text);
            var dictionary = new Dictionary<string, int>();

            foreach (Match match in matches)
            {
                var item = match.Value[0..^1].ToLower().Replace(" ", "");
                if (!dictionary.ContainsKey(item))
                {
                    dictionary.Add(item, 1);
                }
                else
                {
                    dictionary[item] += 1;
                }
            }

            return dictionary;
        }
        static void Main(string[] args)
        {
            var text = "The feeling of physical discomfort without something physical happening to your body, that is usually caused by: second-hand embarrassment, witnessing physical discomfort happening to someone or something else, opinions and acts that you disagree with on a fundamental level and so on. A socially awkward situation caused by usually the telling of a poor joke, an action people witness (eg crying when drunk), or blurting out a comment that is taboo. A silence follows where the people who witness it feel a deep sense of embaressment for the person but as if they were the ones who had done the embarassing thing.";
            var list = CountWords(text);
            foreach (var word in list)
            {
                Console.WriteLine(word);
            }
            Console.ReadKey();
        }
    }
}
