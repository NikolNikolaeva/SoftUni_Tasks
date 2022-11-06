using System;
using System.Collections.Generic;
using System.Linq;

namespace tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            truckTour();
        }


        //task 1
        static void basicStackOperations()
        {
            int[] numEll = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int N = numEll[0];
            int S = numEll[1];
            int X = numEll[2];

            Stack<int> stack = new Stack<int>();

            int[] nums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            for (int i = 0; i < N; i++)
            {
                stack.Push(nums[i]);
            }

            for (int i = 0; (i < S && stack.Count > 0); i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("0");
                return;
            }
            if (stack.Contains(X))
                Console.WriteLine("true");
            else
                Console.WriteLine(stack.Min(x => x));
        }

        //task 2

        static void basicQueueOperations()
        {
            int[] numEll = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int N = numEll[0];
            int S = numEll[1];
            int X = numEll[2];

            Queue<int> stack = new Queue<int>();

            int[] nums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            for (int i = 0; i < N; i++)
            {
                stack.Enqueue(nums[i]);
            }

            for (int i = 0; (i < S && stack.Count > 0); i++)
            {
                stack.Dequeue();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("0");
                return;
            }
            if (stack.Contains(X))
                Console.WriteLine("true");
            else
                Console.WriteLine(stack.Min(x => x));
        }

        //task 3

        static void maximumAndMinimumElement()
        {
            int N = int.Parse(Console.ReadLine());

            Stack<int> elements = new Stack<int>();

            for (int i = 0; i < N; i++)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "1")
                {
                    elements.Push(int.Parse(command[1]));
                }
                else if (command[0] == "2")
                {
                    if (elements.Count > 0)
                        elements.Pop();
                }
                else if (command[0] == "3")
                {
                    if (elements.Count > 0)
                        Console.WriteLine(elements.Max());
                }
                else if (command[0] == "4")
                {
                    if (elements.Count > 0)
                        Console.WriteLine(elements.Min());
                }
            }

            Console.WriteLine(string.Join(", ", elements));
        }

        //task 4

        static void fastFood()
        {
            int quantity = int.Parse(Console.ReadLine());

            int[] integers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Queue<int> orders = new Queue<int>(integers);

            int biggestOrder = 0;

            while (true)
            {
                int order = orders.Peek();
                quantity -= order;

                if (order > biggestOrder)
                    biggestOrder = order;

                if (orders.Count == 1 && quantity >= 0)
                {
                    Console.WriteLine(biggestOrder);
                    Console.WriteLine($"Orders complete");
                    return;
                }
                else if (quantity <= 0 && orders.Count > 0)
                {
                    Console.WriteLine(biggestOrder);
                    Console.WriteLine($"Orders left: " + string.Join(" ", orders));
                    return;
                }
                orders.Dequeue();
            }
        }

        //task 5

        static void fashionBoutique()
        {
            int[] integers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int capacity = int.Parse(Console.ReadLine());

            Stack<int> clothes = new Stack<int>(integers);
            int countRacks = 1;
            int currCapacity = capacity;

            if (clothes.Count == 0)
            {
                countRacks = 0;
            }

            while (clothes.Count > 0)
            {
                int cloth = clothes.Pop();
                currCapacity -= cloth;
                if (currCapacity < 0)
                {
                    countRacks++;
                    currCapacity = capacity;
                    currCapacity -= cloth;
                }
                else if (currCapacity == 0)
                {
                    if (clothes.Count > 0)
                        countRacks++;
                    currCapacity = capacity;
                }
            }
            Console.WriteLine(countRacks);
        }

        //task 6

        static void songsQueue()
        {
            string[] input = Console.ReadLine().Split(", ");
            Queue<string> songs = new Queue<string>(input);

            while (songs.Count > 0)
            {
                string command = Console.ReadLine();
                if (command == "Play")
                {
                    songs.Dequeue();
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
                else
                {
                    string song = command.Substring(4);
                    if (songs.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(song);
                    }
                }
            }
            Console.WriteLine("No more songs!");
        }

        //task 7

        static void truckTour()
        {
            int N = int.Parse(Console.ReadLine());
            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < N; i++)
            {
                int[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                queue.Enqueue(arr);
            }

            for (int i = 0; i < N; i++)
            {
                Queue<int[]> curr = new Queue<int[]>(queue);
                bool startTour = true;
                int Petrol = 0;
                for (int p = 0; p < i; p++)
                {
                    int[] st = curr.Dequeue();
                    curr.Enqueue(st);
                }

                for (int j = 0; j < N; j++)
                {
                    int[] station = curr.Dequeue();
                    int amaountPetrol = station[0];
                    int distance = station[1];

                    Petrol += amaountPetrol;
                    Petrol -= distance;

                    curr.Enqueue(station);

                    if (Petrol < 0)
                    {
                        startTour = false;
                        break;
                    }

                }

                if (startTour == true)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
        }

        //task 8

        static void balancedParenthese()
        {
            string parentheses = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            bool balanced = true;

            for (int i = 0; i < parentheses.Length; i++)
            {
                if (parentheses[i] == '(' || parentheses[i] == '{' || parentheses[i] == '[')
                    stack.Push(parentheses[i]);
                else if (stack.Count == 0)
                {
                    balanced = false;
                    break;
                }
                else if (parentheses[i] == ')')
                {
                    if (stack.Pop() != '(')
                    {
                        balanced = false;
                        break;
                    }
                }
                else if (parentheses[i] == '}')
                {
                    if (stack.Pop() != '{')
                    {
                        balanced = false;
                        break;
                    }
                }
                else if (parentheses[i] == ']')
                {
                    if (stack.Pop() != '[')
                    {
                        balanced = false;
                        break;
                    }
                }
            }


            if (balanced)
                Console.WriteLine("YES");
            else Console.WriteLine("NO");
        }

        //task 9

        static void simpleTextEditor()
        {
            int n = int.Parse(Console.ReadLine());
            string str = string.Empty;
            Stack<string> queue = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string command = input[0];

                if (command == "1")
                {
                    string argument = input[1];
                    str += argument;
                    queue.Push(string.Join(" ", input));
                }
                else if (command == "2")
                {
                    int argument = int.Parse(input[1]);
                    queue.Push(string.Join(" ", "2", str.Substring(str.Length - argument)));
                    str = str.Substring(0, (str.Length - argument));
                }
                else if (command == "3")
                {
                    int argument = int.Parse(input[1]);
                    Console.WriteLine(str[argument - 1]);
                }
                else if (command == "4")
                {
                    string[] currUndoes = queue.Pop().Split();
                    if (currUndoes[0] == "1")
                    {
                        string text = currUndoes[1];
                        str = str.Substring(0, str.Length - text.Length);
                    }
                    else if (currUndoes[0] == "2")
                    {
                        str += currUndoes[1];
                    }
                }
            }
        }
    }

}




