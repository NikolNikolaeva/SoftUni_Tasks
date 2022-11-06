using System;
using System.Linq;

namespace tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            symbolInMatrix();
        }

        //task 1
        static void SumMatrixelements()
        {
            int[] rowsCows = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = rowsCows[0];
            int cows = rowsCows[1];

            int[,] matrix = new int[rows, cows];
            for (int i = 0; i < rows; i++)
            {
                int[] row = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int j = 0; j < cows; j++)
                {
                    matrix[i, j] = row[j];
                }
            }
            int sum = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cows; j++)
                {
                    sum += matrix[i, j];
                }
            }

            Console.WriteLine(rows);
            Console.WriteLine(cows);
            Console.WriteLine(sum);
        }

        //task 2

        static void sumMatrixColumns()
        {
            int[] rowsCows = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = rowsCows[0];
            int cows = rowsCows[1];

            int[,] matrix = new int[rows, cows];
            for (int i = 0; i < rows; i++)
            {
                int[] row = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int j = 0; j < cows; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            for (int i = 0; i < rows; i++)
            {
                int sum = 0;
                for (int j = 0; j < cows; j++)
                {
                    sum += matrix[j, i];
                }

                Console.WriteLine(sum);
            }
        }

        //task 3

        static void primaryDiagonal()
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                int[] row = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                        sum += matrix[i, j];
                }

            }
            Console.WriteLine(sum);
        }

        //task 4

        static void symbolInMatrix()
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                string row = Console.ReadLine();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            char symbol = char.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == symbol)
                    {
                        Console.WriteLine($"({i}, {j})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{symbol} does not occur in the matrix");
        }

        //task 5

        static void squareWithMaximumSum()
        {
            int[] rowsCows = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = rowsCows[0];
            int cows = rowsCows[1];

            int[,] matrix = new int[rows, cows];
            for (int i = 0; i < rows; i++)
            {
                int[] row = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int j = 0; j < cows; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            int sum = int.MinValue;
            int indexRow = 0;
            int indexCow = 0;
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cows - 1; j++)
                {
                    int currSum = 0;
                    currSum += matrix[i, j];
                    currSum += matrix[i, j + 1];
                    currSum += matrix[i + 1, j];
                    currSum += matrix[i + 1, j + 1];
                    if (currSum > sum)
                    {
                        sum = currSum;
                        indexRow = i;
                        indexCow = j;
                    }
                }
            }

            for (int i = indexRow; i < indexRow + 2; i++)
            {
                for (int j = indexCow; j < indexCow + 2; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(sum);
        }

        //task 6

        static void printJaggedarray(int[][] jaggedArray, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < jaggedArray[i].GetLength(0); j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void JaggedArrayModification()
        {
            int n = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[n][];
            for (int i = 0; i < n; i++)
            {
                jaggedArray[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                if (command == "END")
                {
                    printJaggedarray(jaggedArray, n);
                    return;
                }
                else
                {
                    int row = int.Parse(input[1]);
                    int cow = int.Parse(input[2]);
                    int value = int.Parse(input[3]);

                    if (row > n || row < 0 || jaggedArray[row].GetLength(0) - 1 < cow || cow < 0)
                    {
                        Console.WriteLine("Invalid coordinates");
                        continue;
                    }

                    if (command == "Add")
                    {
                        jaggedArray[row][cow] += value;
                    }
                    else if (command == "Subtract")
                    {
                        jaggedArray[row][cow] -= value;
                    }
                }
            }
        }

        //task 7

        static void printJaggedarray(long[][] jaggedArray, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < jaggedArray[i].GetLength(0); j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void PascalTriangle()
        {
            int n = int.Parse(Console.ReadLine());

            long[][] triangle = new long[n][];

            for (int i = 0; i < n; i++)
            {
                triangle[i] = new long[i + 1];
                triangle[i][0] = 1;
                triangle[i][i] = 1;
                for (int j = 1; j < i; j++)
                {
                    triangle[i][j] = triangle[i - 1][j-1] + triangle[i - 1][j];
                }
            }

            printJaggedarray(triangle, n);
        }
    }
}
