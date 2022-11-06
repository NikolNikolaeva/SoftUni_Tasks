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
            KnightGame();
        }

        //task 1

        static void DiagonalDiference()
        {
            int N = int.Parse(Console.ReadLine());

            int[,] matrix = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                int[] row = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int j = 0; j < N; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            int sum = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i == j)
                        sum += matrix[i, j];
                    if (i + j == N - 1)
                        sum -= matrix[i, j];
                }
            }

            Console.WriteLine(Math.Abs(sum));
        }

        //task 2

        static void squareInMatrix()
        {
            int[] rowsCows = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = rowsCows[0];
            int cows = rowsCows[1];

            int countSquares = 0;
            if (rows < 2 || cows < 2)
                Console.WriteLine(countSquares);

            char[,] matrix = new char[rows, cows];

            for (int i = 0; i < rows; i++)
            {
                char[] row = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < cows; j++)
                {
                    matrix[i, j] = row[j];
                }
            }


            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cows - 1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1] && matrix[i, j] == matrix[i + 1, j] && matrix[i, j] == matrix[i + 1, j + 1])
                        countSquares++;
                }
            }

            Console.WriteLine(countSquares);
        }

        //task 3

        static void MaximalSum()
        {
            int[] rowsCows = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            // int rows = rowsCows[0];
            // int cows = rowsCows[1];

            int[,] matrix = new int[rowsCows[0], rowsCows[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] row = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            int sum = int.MinValue;
            int indexRow = 0;
            int indexCow = 0;
            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    int currSum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] +
                        matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] +
                        matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
                    // int currSum = 0;
                    // for (int p = 0; p < 3; p++)
                    // {
                    //     for (int k = 0; k < 3; k++)
                    //     {
                    //         currSum += matrix[i + p, j + k];
                    //     }
                    // }
                    if (currSum > sum)
                    {
                        sum = currSum;
                        indexRow = i;
                        indexCow = j;
                    }
                }
            }

            Console.WriteLine($"Sum = {sum}");
            for (int i = indexRow; i < indexRow + 3; i++)
            {
                for (int j = indexCow; j < indexCow + 3; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        //task 4

        static void MatrixShiffling()
        {
            int[] dimensions = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cows = dimensions[1];

            string[,] matrix = new string[rows, cows];

            for (int i = 0; i < rows; i++)
            {
                string[] row = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < cows; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split();


                string command = input[0];

                if (command == "END")
                {
                    return;
                }
                else if (command == "swap")
                {
                    if (input.Length != 5)
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }
                    int firstRow = int.Parse(input[1]);
                    int firstCow = int.Parse(input[2]);
                    int secondRow = int.Parse(input[3]);
                    int secondCow = int.Parse(input[4]);

                    if (firstRow < 0 || firstRow >= rows || secondRow < 0 || secondRow >= rows || firstCow < 0 || firstCow >= cows || secondCow < 0 || secondCow >= cows)
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }

                    string temp = matrix[firstRow, firstCow];
                    matrix[firstRow, firstCow] = matrix[secondRow, secondCow];
                    matrix[secondRow, secondCow] = temp;

                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cows; j++)
                        {
                            Console.Write(matrix[i, j] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
            }

        }

        //task 5

        static void snakeMoves()
        {
            int[] dimensions = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cows = dimensions[1];

            string word = Console.ReadLine();

            char[,] matrix = new char[rows, cows];

            int indexWord = 0;
            int countWord = word.Count();
            for (int i = 0; i < rows; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < cows; j++)
                    {
                        matrix[i, j] = word[indexWord];
                        indexWord++;
                        if (indexWord == countWord)
                            indexWord = 0;
                    }
                }
                else
                {
                    for (int j = cows - 1; j >= 0; j--)
                    {
                        matrix[i, j] = word[indexWord];
                        indexWord++;
                        if (indexWord == countWord)
                            indexWord = 0;
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cows; j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }
                Console.WriteLine();
            }
        }

        //task 6

        static void jaggedArrayManipulator()
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                jaggedArray[i] = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            }

            for (int i = 0; i < rows - 1; i++)
            {
                int length = jaggedArray[i].Length;
                int length2 = jaggedArray[i + 1].Length;
                if (length == length2)
                {
                    for (int j = 0; j < length; j++)
                    {
                        jaggedArray[i][j] *= 2;
                        jaggedArray[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < length; j++)
                    {
                        jaggedArray[i][j] /= 2;
                    }
                    for (int j = 0; j < jaggedArray[i + 1].Length; j++)
                    {
                        jaggedArray[i + 1][j] /= 2;
                    }
                }
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "End")
                {
                    foreach (int[] item in jaggedArray)
                    {
                        Console.WriteLine(string.Join(" ", item));
                    }
                    return;
                }
                else if (input[0] == "Add")
                {
                    int row = int.Parse(input[1]);
                    int cow = int.Parse(input[2]);
                    if ((row < 0 || row >= rows || cow < 0 || cow >= jaggedArray[row].Length))
                        continue;

                    jaggedArray[row][cow] += int.Parse(input[3]);
                }
                else if (input[0] == "Subtract")
                {
                    int row = int.Parse(input[1]);
                    int cow = int.Parse(input[2]);
                    if ((row < 0 || row >= rows || cow < 0 || cow >= jaggedArray[row].Length))
                        continue;
                    jaggedArray[row][cow] -= int.Parse(input[3]);

                }
            }


        }

        //task 7

        static void KnightGame()
        {
            int dimension = int.Parse(Console.ReadLine());

            if (dimension < 3)
            {
                Console.WriteLine(0);
                return;
            }

            char[,] board = new char[dimension, dimension];
            for (int i = 0; i < dimension; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < dimension; j++)
                {
                    board[i, j] = row[j];
                }
            }

            //int maxCount = 0;
            //
            //Queue<int[]> knightsIndexes = new Queue<int[]>();

            //for (int i = 0; i < dimension; i++)
            //{
            //    int currCount = 0;
            //    for (int j = 0; j < dimension; j++)
            //    {
            //        if(board[i,j]=='K')
            //        {
            //            if(i)
            //        }
            //    }
            //}

            int knightsRemoved = 0;

            while (true)
            {
                int countMostAttacking = 0;
                int row = 0;
                int col = 0;

                for (int i = 0; i < dimension; i++)
                {
                    for (int j = 0; j < dimension; j++)
                    {
                        if (board[i, j] == 'K')
                        {
                            int attackedKnights = CountAttackedKnights(i, j, dimension, board);
                            if (countMostAttacking < attackedKnights)
                            {
                                countMostAttacking = attackedKnights;
                                row = i;
                                col = j;
                            }
                        }

                    }
                }

                if(countMostAttacking==0)
                {
                    break;
                }
                else
                {
                    board[row, col] = '0';
                    knightsRemoved++;            
                }
            }

            Console.WriteLine(knightsRemoved);
        }

        static int CountAttackedKnights(int i, int j, int dimension, char[,] board)
        {
            int attackedKnights = 0;

            if (isCellValid(i - 1, j - 2, dimension))
            {
                if (board[i - 1, j - 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (isCellValid(i + 1, j - 2, dimension))
            {
                if (board[i + 1, j - 2] == 'K')
                {
                    attackedKnights++;
                }
            }
            if (isCellValid(i - 1, j + 2, dimension))
            {
                if (board[i - 1, j + 2] == 'K')
                {
                    attackedKnights++;
                }
            }
            if (isCellValid(i + 1, j + 2, dimension))
            {
                if (board[i + 1, j + 2] == 'K')
                {
                    attackedKnights++;
                }
            }
            if (isCellValid(i - 2, j - 1, dimension))
            {
                if (board[i - 2, j - 1] == 'K')
                {
                    attackedKnights++;
                }
            }
            if (isCellValid(i - 2, j + 1, dimension))
            {
                if (board[i - 2, j + 1] == 'K')
                {
                    attackedKnights++;
                }
            }
            if (isCellValid(i + 2, j - 1, dimension))
            {
                if (board[i + 2, j - 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (isCellValid(i + 2, j + 1, dimension))
            {
                if (board[i + 2, j + 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            return attackedKnights;
        }

        static bool isCellValid(int row, int col, int size)
        {
            return row >= 0 && row < size && col >= 0 && col < size;
        }
    }
}
