using System;
using System.Collections.Generic;
using System.Linq;

namespace TilesMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> tableCount = new Dictionary<string, int>();
            tableCount["Floor"] = 0;
            tableCount["Countertop"] = 0;
            tableCount["Oven"] = 0;
            tableCount["Sink"] = 0;
            tableCount["Wall"] = 0;

            List<int> whiteAreas = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            List<int> greyAreas = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            Stack<int> white = new Stack<int>(whiteAreas);
            Queue<int> grey = new Queue<int>(greyAreas);

            while ((white.Count() != 0) && (grey.Count() != 0))
            {
                int whiteArea = white.Pop();
                int greyArea = grey.Dequeue();

                if (whiteArea == greyArea)
                {
                    int tile = whiteArea + greyArea;
                    if (tile == 40) tableCount["Sink"]++;
                    else if (tile == 50) tableCount["Oven"]++;
                    else if (tile == 60) tableCount["Countertop"]++;
                    else if (tile == 70) tableCount["Wall"]++;
                    else tableCount["Floor"]++;
                }
                else
                {
                    whiteArea /= 2;
                    white.Push(whiteArea);
                    grey.Enqueue(greyArea);
                }
            }

            if (white.Count() != 0)
            {
                Console.Write("White tiles left: ");
                Console.WriteLine(string.Join(", ", white));
            }
            else
            {
                Console.WriteLine("White tiles left: none");
            }
            if (grey.Count() != 0)
            {
                Console.Write("Grey tiles left: ");
                Console.WriteLine(string.Join(", ", grey));
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }

            tableCount = tableCount.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in tableCount)
            {
                if (item.Value != 0) Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
