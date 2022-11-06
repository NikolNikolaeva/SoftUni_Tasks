using System;
using System.Collections.Generic;
using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";
            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (StreamReader reader1 = new StreamReader(firstInputFilePath))
            {
                using (StreamReader reader2 = new StreamReader(secondInputFilePath))
                {
                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {

                        string[] linesText1 = reader1.ReadLine().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
                        string[] linesText2 = reader2.ReadLine().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

                        int counterText1 = 0;
                        int counterText2 = 0;
                        for (int i = 0; i < linesText1.Length + linesText2.Length; i++)
                        {
                            if (i % 2 == 0)
                            {
                                if (counterText1 == linesText1.Length)
                                    writer.WriteLine(linesText2[counterText2++]);

                                writer.WriteLine(linesText1[counterText1++]);
                            }
                            else
                            {
                                if (counterText2 == linesText2.Length)
                                    writer.WriteLine(linesText1[counterText1++]);

                                writer.WriteLine(linesText2[counterText2++]);
                            }
                        }
                    }
                }
            }
        }
    }
}
