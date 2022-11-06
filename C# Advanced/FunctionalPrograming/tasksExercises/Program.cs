using System;
using System.Collections.Generic;
using System.Linq;

namespace tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            TriFunction();
        }

        //task 1

        static void ActionPoint()
        {
            Action<string[]> print = str =>
              {
                  Console.WriteLine(string.Join(Environment.NewLine, str));
              };

            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            print(names);
        }

        //task 2

        static void KnightsOfHonor()
        {
            Action<string[]> print = str =>
            {
                str = str.Select(x => "Sir " + x).ToArray();
                Console.WriteLine(string.Join(Environment.NewLine, str));
            };

            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            print(names);
        }

        //task 3

        static void customMinFunction()
        {
            Func<int[], int> smallestNumber = collection => collection.Min();

            Console.WriteLine(smallestNumber(Console.ReadLine().Split(" ").Select(int.Parse).ToArray()));
        }

        //task 4

        static void FindEvensOrOdds()
        {
            Predicate<int> isEven = n => n % 2 == 0;

            int[] dimentions = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int[] nums = Enumerable.Range(dimentions[0], dimentions[1] - dimentions[0] + 1).ToArray();
            string pattern = Console.ReadLine();

            Console.WriteLine(string.Join(" ", nums.Where(x => pattern == "even" ? isEven(x) : !isEven(x))));
        }

        //task 5

        static void AppliedArithmetics()
        {
            List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            Func<int, int> add = x => x + 1;
            Func<int, int> multiply = x => x * 2;
            Func<int, int> subtract = x => x - 1;
            Action<List<int>> print = x => Console.WriteLine(string.Join(" ", x));

            while (true)
            {
                string action = Console.ReadLine();

                if (action == "end")
                {
                    break;
                }

                if (action == "print")
                {
                    print(numbers);
                    continue;
                }
                if (action == "add")
                {
                    numbers = Operation(numbers, add);
                }
                if (action == "multiply")
                {
                    numbers = Operation(numbers, multiply);
                }
                if (action == "subtract")
                {
                    numbers = Operation(numbers, subtract);
                }
            }
        }

        static List<int> Operation(List<int> arr, Func<int, int> action)
        {
            return arr.Select(x => action(x)).ToList();
        }


        //task 6

        static void ReverseAndExclude()
        {
            Func<int, int, bool> isDevisible = (x, d) => x % d == 0;

            List<int> nums = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            int devider = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Join(" ", nums.Where(x => !isDevisible(x, devider)).Reverse()));
        }

        //task 7

        static void PredicateforNames()
        {
            int length = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, names.Where(x => x.Length <= length)));
        }

        //task 8

        static void ListOfPredicates()
        {
            int lasNum = int.Parse(Console.ReadLine());
            HashSet<int> dividers = Console.ReadLine().Split(" ").Select(int.Parse).ToHashSet();

            List<int> numbers = Enumerable.Range(1, lasNum).ToList();

            Func<int, HashSet<int>, bool> isdivisibleToAll = (n, d) =>
                {
                    foreach (var item in d)
                    {
                        if (n % item != 0)
                            return false;
                    }
                    return true;
                };

            Console.WriteLine(string.Join(" ", numbers.Where(x => isdivisibleToAll(x, dividers))));
        }

        //task 9

        static void PredicateParty()
        {
            List<string> listGuests = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<List<string>, string, string, List<string>> remove = (w, c, ch) =>
                  {
                      if (c == "StartsWith")
                      {
                          w.RemoveAll(x => x.StartsWith(ch));

                      }
                      else if (c == "EndsWith")
                      {
                          w.RemoveAll(x => x.EndsWith(ch));
                      }
                      else if (c == "Length")
                      {
                          w.RemoveAll(x => x.Length == int.Parse(ch));
                      }
                      return w;
                  };
            Func<List<string>, string, string, List<string>> Double = (w, c, ch) =>
                  {
                      if (c == "StartsWith")
                      {
                          int countList = w.Count;
                          for (int i = 0; i < countList; i++)
                          {
                              if (w[i].StartsWith(ch))
                                  w.Add(w[i]);
                          }

                      }
                      else if (c == "EndsWith")
                      {
                          int countList = w.Count;
                          for (int i = 0; i < countList; i++)
                          {
                              if (w[i].EndsWith(ch))
                                  w.Add(w[i]);
                          }
                      }
                      else if (c == "Length")
                      {
                          int countList = w.Count;
                          for (int i = 0; i < countList; i++)
                          {
                              if (w[i].Length == int.Parse(ch))
                                  w.Add(w[i]);
                          }
                      }
                      return w;
                  };

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "Party!"||listGuests.Count==0)
                {
                    break;
                }

                if (input[0] == "Remove")
                {
                    listGuests = remove(listGuests, input[1], input[2]);
                }
                else if (input[0] == "Double")
                {
                    listGuests = Double(listGuests, input[1], input[2]);
                }

            }
            Console.WriteLine(listGuests.Count == 0 ? "Nobody is going to the party!" : $"{string.Join(", ", listGuests)} are going to the party!");

        }

        //task 10

        static void PartyReservationFilterModule()
        {
            List<string> listGuests = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<List<string>, string, string, List<string>> remove = (w, c, ch) =>
            {
                if (c == "Starts with")
                {
                    w.RemoveAll(x => x.StartsWith(ch));

                }
                else if (c == "Ends with")
                {
                    w.RemoveAll(x => x.EndsWith(ch));
                }
                else if (c == "Length")
                {
                    w.RemoveAll(x => x.Length == int.Parse(ch));
                }
                return w;
            };
            Func<List<string>, string, string, List<string>> Double = (w, c, ch) =>
            {
                if (c == "Starts with")
                {
                    int countList = w.Count;
                    for (int i = 0; i < countList; i++)
                    {
                        if (w[i].StartsWith(ch))
                            w.Add(w[i]);
                    }

                }
                else if (c == "Ends with")
                {
                    int countList = w.Count;
                    for (int i = 0; i < countList; i++)
                    {
                        if (w[i].EndsWith(ch))
                            w.Add(w[i]);
                    }
                }
                else if (c == "Length")
                {
                    int countList = w.Count;
                    for (int i = 0; i < countList; i++)
                    {
                        if (w[i].Length == int.Parse(ch))
                            w.Add(w[i]);
                    }
                }
                return w;
            };

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "Party!" || listGuests.Count == 0)
                {
                    break;
                }

                if (input[0] == "Add filter")
                {
                    listGuests = remove(listGuests, input[1], input[2]);
                }
                else if (input[0] == "Remove fiter")
                {
                    listGuests = Double(listGuests, input[1], input[2]);
                }

            }
            Console.WriteLine(listGuests.Count == 0 ? "Nobody is going to the party!" : $"{string.Join(", ", listGuests)} are going to the party!");

        }

        //task 11

        static void TriFunction()
        {
            int N=int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split(" ").ToList();

            foreach (var item in names)
            {
                int sum = 0;
                foreach (var ch in item)
                {
                    sum += ch;
                }
                if(sum>=N)
                {
                    Console.WriteLine(item);
                    return;
                }    
            }
        }
    }
}
