using System;
using System.Collections.Generic;
using System.Linq;

namespace EnergyDrink
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> milligrams = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            List<int> energyDrinks = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();


            Stack<int> stackMilligrams = new Stack<int>(milligrams);
            Queue<int> queueEnergyDrink = new Queue<int>(energyDrinks);

            int sumCaffeine = 0;

            while (stackMilligrams.Any() && queueEnergyDrink.Any())
            {
                int ml = stackMilligrams.Pop();
                int drink = queueEnergyDrink.Dequeue();

                int coffeinInDrink = ml * drink;

                if (sumCaffeine + coffeinInDrink <= 300)
                {
                    sumCaffeine += coffeinInDrink;
                }
                else
                {
                    queueEnergyDrink.Enqueue(drink);
                    if (sumCaffeine - 30 >= 0)
                        sumCaffeine -= 30;

                }
            }

            if (queueEnergyDrink.Any())
            {
                Console.WriteLine("Drinks left: " + string.Join(", ", queueEnergyDrink));
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with { sumCaffeine } mg caffeine.");
        }
    }
}
