using System;
using System.Collections.Generic;
using System.Linq;

namespace tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Wardrobe();
        }

        //task 1

        static void UniqueUsernames()
        {
            int count = int.Parse(Console.ReadLine());

            HashSet<string> usernames = new HashSet<string>();
            for (int i = 0; i < count; i++)
            {
                string name = Console.ReadLine();
                usernames.Add(name);
            }

            Console.WriteLine(string.Join(Environment.NewLine, usernames));
        }

        //task 2

        static void SetsOfElements()
        {
            int[] dimensions = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            HashSet<string> first = new HashSet<string>();
            HashSet<string> second = new HashSet<string>();

            for (int i = 0; i < dimensions[0]; i++)
            {
                string num = Console.ReadLine();
                first.Add(num);
            }
            for (int i = 0; i < dimensions[1]; i++)
            {
                string num = Console.ReadLine();
                second.Add(num);
            }

            Console.WriteLine(string.Join(" ", first.Where(x => second.Contains(x))));
        }

        //task 3

        static void PeriodicTable()
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> chemicalElements = new SortedSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] compounds = Console.ReadLine().Split();

                foreach (var item in compounds)
                {
                    chemicalElements.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ", chemicalElements));
        }

        //task 4

        static void EvenTimes()
        {
            Dictionary<int, int> nums = new Dictionary<int, int>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!nums.ContainsKey(num))
                {
                    nums[num] = 0;
                }
                nums[num]++;
            }

            Console.WriteLine(nums.Where(x => x.Value % 2 == 0).FirstOrDefault().Key);
        }

        //task 5

        static void CountSymbols()
        {
            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

            string text = Console.ReadLine();
            int textLength = text.Length;

            for (int i = 0; i < textLength; i++)
            {
                if (!symbols.ContainsKey(text[i]))
                {
                    symbols[text[i]] = 0;
                }
                symbols[text[i]]++;
            }

            foreach (var item in symbols)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }

        //task 6

        static void Wardrobe()
        {
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");

                if (!wardrobe.ContainsKey(input[0]))
                {
                    wardrobe[input[0]] = new Dictionary<string, int>();
                }

                string[] clothes = input[1].Split(",");

                foreach (var item in clothes)
                {
                    if (!wardrobe[input[0]].ContainsKey(item))
                        wardrobe[input[0]][item] = 0;
                    wardrobe[input[0]][item]++;
                }
            }

            string[] searchCloth = Console.ReadLine().Split();

            foreach (var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var cloth in item.Value)
                {
                    Console.Write($"* {cloth.Key} - {cloth.Value} ");
                    if (item.Key == searchCloth[0] && cloth.Key == searchCloth[1])
                        Console.Write($"(found!)");
                    Console.WriteLine();
                }
            }
        }
    }
}
