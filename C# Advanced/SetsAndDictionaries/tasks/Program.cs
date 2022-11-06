using System;
using System.Collections.Generic;
using System.Linq;

namespace tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            SoftUniParty();
        }

        //task 1

        static void CountSameValuesInArray()
        {
            Dictionary<double, int> nums = new Dictionary<double, int>();

            double[] array = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();

            int countArray = array.Length;
            for (int i = 0; i < countArray; i++)
            {
                if (!nums.ContainsKey(array[i]))
                {
                    nums[array[i]] = 0;
                }

                nums[array[i]]++;
            }

            foreach (var item in nums)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }

        //task 2

        static void AverageStudentGrades()
        {
            Dictionary<string, List<decimal>> studentsGrades = new Dictionary<string, List<decimal>>();

            int countStudents = int.Parse(Console.ReadLine());

            for (int i = 0; i < countStudents; i++)
            {
                string[] student = Console.ReadLine().Split();
                string name = student[0];
                decimal grade = decimal.Parse(student[1]);

                if (!studentsGrades.ContainsKey(name))
                {
                    studentsGrades[name] = new List<decimal>();
                }

                studentsGrades[name].Add(grade);
            }

            foreach (var item in studentsGrades)
            {
                Console.Write($"{item.Key} -> ");
                foreach (var grade in item.Value)
                {
                    Console.Write($"{grade:F2} ");
                }
                Console.Write($"(avg: {item.Value.Average():F2})");
                Console.WriteLine();
            }
        }

        //task 3

        static void LargestThreeNum()
        {
            int[] sorted = Console.ReadLine().Split(" ").Select(int.Parse).OrderBy(x => x).ToArray();
            int count = 0;
            for (int i = sorted.Length - 1; i >= 0; i--)
            {
                Console.Write(sorted[i] + " ");
                count++;
                if (count == 3)
                    break;
            }
        }

        //task 4

        static void ProductShop()
        {
            var store = new SortedDictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(", ");

                if (input[0] == "Revision")
                {
                    foreach (var item in store)
                    {
                        Console.WriteLine($"{item.Key}->");
                        foreach (var product in item.Value)
                        {
                            Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                        }
                    }
                    break;
                }
                else
                {
                    string shop = input[0];
                    string product = input[1];
                    double price = double.Parse(input[2]);

                    if (!store.ContainsKey(shop))
                    {
                        store[shop] = new Dictionary<string, double>();
                    }

                    store[shop].Add(product, price);
                }
            }
        }

        //task 5

        static void CitiesByCountinentAndCountry()
        {
            int count = int.Parse(Console.ReadLine());

            var store = new Dictionary<string, Dictionary<string, List<string>>>();


            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split();

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!store.ContainsKey(continent))
                {
                    store[continent] = new Dictionary<string, List<string>>();
                }
                if (!store[continent].ContainsKey(country))
                {
                    store[continent][country] = new List<string>();
                }
                store[continent][country].Add(city);
            }

            foreach (var item in store)
            {
                Console.WriteLine($"{item.Key}: ");
                foreach (var product in item.Value)
                {
                    Console.WriteLine($"  {product.Key} -> {string.Join(", ", product.Value)}");
                }
            }
        }

        //task 6

        static void RecordUniqueNames()
        {
            HashSet<string> names = new HashSet<string>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string name = Console.ReadLine();
                names.Add(name);
            }

            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }

        //task 7

        static void ParkingLot()
        {
            HashSet<string> cars = new HashSet<string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                string[] carNums = input.Split(", ");

                if (carNums[0] == "IN")
                {
                    cars.Add(carNums[1]);
                }
                else if (carNums[0] == "OUT")
                {
                    //if (cars.Contains(carNums[1]))
                    cars.Remove(carNums[1]);
                }
            }

            if (cars.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            foreach (var item in cars)
            {
                Console.WriteLine(item);
            }
        }

        //task 8

        static void SoftUniParty()
        {
            HashSet<string> guests = new HashSet<string>();
            HashSet<string> VIPguests = new HashSet<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "PARTY")
                {
                    while (true)
                    {
                        string outGuests = Console.ReadLine();

                        if (outGuests == "END")
                        {

                            Console.WriteLine(VIPguests.Count+ guests.Count);
                            foreach (var item in VIPguests)
                            {
                                Console.WriteLine(item);
                            }
                            foreach (var item in guests)
                            {
                                Console.WriteLine(item);
                            }
                            return;
                        }

                        guests.Remove(outGuests);
                        VIPguests.Remove(outGuests);
                    }
                }
                if (input[0] >= '0' && input[0] <= '9')
                    VIPguests.Add(input);
                else
                    guests.Add(input);
            }
        }
    }
}
