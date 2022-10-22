using System;
using System.Collections.Generic;
using System.Linq;

namespace RallyRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string racingNumber = Console.ReadLine();

            char[,] RaceRoute = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                char[] line = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                for (int j = 0; j < size; j++)
                {
                    RaceRoute[i, j] = line[j];
                }
            }

            int kilometersPassed = 0;
            int currRow = 0;
            int currCol = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    RaceRoute[currRow, currCol] = 'C';
                    Console.WriteLine($"Racing car { racingNumber} DNF.");
                    break;
                }

                if (command == "up")
                {
                    if (currRow > 0)
                        currRow--;
                }
                else if (command == "down")
                {
                    if (currRow < size - 1)
                        currRow++;
                }
                else if (command == "left")
                {
                    if (currCol > 0)
                        currCol--;
                }
                else if (command == "right")
                {
                    if (currCol < size - 1)
                        currCol++;
                }

                if (RaceRoute[currRow, currCol] == '.')
                    kilometersPassed += 10;
                else if (RaceRoute[currRow, currCol] == 'T')
                {
                    kilometersPassed += 30;
                    RaceRoute[currRow, currCol] = '.';
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            if (RaceRoute[i, j] == 'T')
                            {
                                currRow = i;
                                currCol = j;
                                RaceRoute[i, j] = '.';
                                break;
                            }
                        }
                    }
                }
                else if (RaceRoute[currRow, currCol] == 'F')
                {
                    kilometersPassed += 10;
                    RaceRoute[currRow, currCol] = 'C';
                    Console.WriteLine($"Racing car {racingNumber} finished the stage!");
                    break;
                }
            }

            Console.WriteLine($"Distance covered {kilometersPassed} km.");
            PrintMatrix(RaceRoute);
        }

        static void PrintMatrix(char[,] raceRoute)
        {
            for (int i = 0; i < raceRoute.GetLength(0); i++)
            {
                for (int j = 0; j < raceRoute.GetLength(1); j++)
                {
                    Console.Write(raceRoute[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
