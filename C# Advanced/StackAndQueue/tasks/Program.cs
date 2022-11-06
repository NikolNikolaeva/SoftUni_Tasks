using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            matchingBrackets();
        }

        //task 1

        static void reverseString(string input)
        {
            Stack<char> result = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                result.Push(input[i]);
            }
            while (result.Count > 0)
            {
                char element = result.Peek();
                Console.Write(element);
                result.Pop();
            }
        }

        //task 2

        static void stackSum()
        {
            int[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> integers = new Stack<int>();

            foreach (var num in arr)
            {
                integers.Push(num);
            }


            while (true)
            {
                string[] command = Console.ReadLine().Split();

                string action = command[0].ToLower();

                if (action == "end")
                {
                    Console.WriteLine("Sum: " + integers.Sum());
                    break;
                }
                else if (action == "add")
                {
                    int firstNum = int.Parse(command[1]);
                    int secondNum = int.Parse(command[2]);

                    integers.Push(firstNum);
                    integers.Push(secondNum);
                }
                else if (action == "remove")
                {
                    int count = int.Parse(command[1]);
                    if (integers.Count >= count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            integers.Pop();
                        }
                    }
                }
            }
        }

        //task 3

        static void simplecalculator()
        {
            Stack<int> nums = new Stack<int>();

            string[] input = Console.ReadLine().Split();

            nums.Push(int.Parse(input[0]));
            for (int i = 1; i < input.Length; i += 2)
            {
                if (input[i] == "+")
                {
                    nums.Push(int.Parse(input[i + 1]));
                }
                else
                {
                    nums.Push(-(int.Parse(input[i + 1])));
                }
            }

            Console.WriteLine(nums.Sum());
        }


        //task 4

        static void matchingBrackets()
        {
            string arithmExpression = Console.ReadLine();

            Stack<int> indexes = new Stack<int>();

            for (int i = 0; i < arithmExpression.Length; i++)
            {
                if (arithmExpression[i] == '(')
                    indexes.Push(i);
                if(arithmExpression[i]==')')
                {
                    int start = indexes.Pop();
                    Console.WriteLine(arithmExpression.Substring(start, i - start + 1));
                }
            }
        }

        //task 5

        static void printEvenNum()
        {
            int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();
            foreach (var item in arr)
            {
                queue.Enqueue(item);
            }

            int countEven = queue.Where(x => x % 2 == 0).Count();

            while (queue.Count > 0)
            {
                int num = queue.Peek();
                if (num % 2 == 0)
                {
                    Console.Write(num);
                    countEven--;
                    if (countEven > 0)
                        Console.Write(", ");
                }
                queue.Dequeue();
            }
        }

        //task 6

        static void Supermarket()
        {
            Queue<string> customers = new Queue<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Paid")
                {
                    while (customers.Count > 0)
                    {
                        Console.WriteLine(customers.Dequeue());
                    }
                }
                else if (input == "End")
                {
                    Console.WriteLine($"{customers.Count} people remaining.");
                    break;
                }
                else
                {
                    customers.Enqueue(input);
                }
            }
        }

        //task 7

        static void hotPotato()
        {
            string[] names = Console.ReadLine().Split();

            Queue<string> kids = new Queue<string>();

            foreach (var name in names)
            {
                kids.Enqueue(name);
            }

            int count = int.Parse(Console.ReadLine());
            if (kids.Count == 1)
            {
                Console.WriteLine($"Last is {kids.Dequeue()}");
                return;
            }

            int i = 0;
            while (true)
            {
                string kid = kids.Dequeue();
                if ((i + 1) % count == 0)
                {
                    Console.WriteLine($"Removed {kid}");
                }
                else
                {
                    kids.Enqueue(kid);
                }

                if (kids.Count == 1)
                {
                    Console.WriteLine($"Last is {kids.Dequeue()}");
                    break;
                }
                i++;
            }

        }

        //task 8

        static void trafficJam()
        {
            int count = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();

            int countPassed = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    Console.WriteLine($"{countPassed} cars passed the crossroads.");
                    return;
                }
                else if (input == "green")
                {

                    for (int i = 0; i < count; i++)
                    {
                        if (cars.Count == 0)
                            break;
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        countPassed++;
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

            }
        }
    }
}
