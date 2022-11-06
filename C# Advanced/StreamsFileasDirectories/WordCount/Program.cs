using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";
            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using (StreamReader reader1 = new StreamReader(wordsFilePath))
            {
                using (StreamReader reader2 = new StreamReader(textFilePath))
                {
                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        Dictionary<string, int> wordscount = new Dictionary<string, int>();
                        List<string> words = reader1.ReadLine().Split(" ").ToList();

                        foreach (var item in words)
                        {
                            wordscount[item] = 0;
                        }

                        foreach (var item in words)
                        {
                            while (!reader2.EndOfStream)
                            {
                                string[] line = reader2.ReadLine().Split(new string[] { " ", ", ", ". ", "! ", "? ", "-" }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (var word in line)
                                {
                                    if (word.ToLower() == item)
                                        wordscount[item]++;
                                }
                            }
                        }

                        foreach (var item in wordscount)
                        {
                            writer.WriteLine($"{item.Key} - {item.Value}");
                        }

                    }
                }
            }
        }
    }
}
