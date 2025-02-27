using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Knit_CSharp
{
    public class Task_15_and_16_1
    {
        public void Run()
        {
            //(Практикум 15-16(Первое))
            // Дана последовательность целых чисел. 
            // 15. Вывести на экран в порядке возрастания все двухзначные числа, увеличив их на 1.
            string inputFilePath = "C:\\Users\\Mostov\\Knit_CSharp\\System_File\\input_for_15_1.txt";
            string outputFilePath_15_1 = "C:\\Users\\Mostov\\Knit_CSharp\\System_File\\output_for_15_1.txt";
            string outputFilePath_16_1 = "C:\\Users\\Mostov\\Knit_CSharp\\System_File\\output_for_16_1.txt";

            // List<int> numbers = File
            //     .ReadAllText(inputFilePath)
            //     .Split(new[] { ";", ",", " ", "\n", "\t" },
            //         StringSplitOptions.RemoveEmptyEntries)
            //     .Where(x => !string.IsNullOrWhiteSpace(x))
            //     .Select(x => int.Parse(x.Trim()))
            //     .ToList();

            string fileContent = File.ReadAllText(inputFilePath);
            List<int> numbers = new List<int>();

            // Разделение содержимого файла на элементы
            string[] parts = fileContent.Split(new[] { ";", ",", " ", "\n", "\t" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string part in parts)
            {
                if (!string.IsNullOrWhiteSpace(part))
                {
                    int number = int.Parse(part.Trim());
                    numbers.Add(number);
                }
            }

            foreach (int a in numbers)
            {
                System.Console.Write(a + " ");
            }

            // 15.1
            List<int> numbers_15_1 =
                (from n in numbers
                 where n >= 10 && n <= 99 || n <= -10 && n >= -99
                 orderby n
                 select (n + 1)).ToList();

            File.WriteAllText(outputFilePath_15_1, string.Join(";", numbers_15_1));

            // 16.1
            List<int> numbers_16_1 = numbers
                                        .Where(num => num >= 10 && num <= 99 || num <= -10 && num >= -99)
                                        .Select(num => num + 1)
                                        .OrderBy(num => num)
                                        .ToList();


            File.WriteAllText(outputFilePath_16_1, string.Join(";", numbers_16_1));


            // List<int> - потому что не известно кол-во чисел во входном файле и доступны linq запросы


        }
    }
}
