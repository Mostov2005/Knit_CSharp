using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Knit_CSharp
{
    public class Class4
    {
        public void Run()
        {
            // Дана последовательность целых чисел.
            // 15. Вывести на экран в порядке возрастания все двухзначные числа, увеличив их на 1.
            string inputFilePath = "C:\\Users\\Mostov\\Knit_CSharp\\System_File\\input_for_15.txt";
            string outputFilePath = "C:\\Users\\Mostov\\Knit_CSharp\\System_File\\output_for_15.txt";

            // Чтение и преобразование строки в массив целых чисел
            List<int> numbers = File.ReadAllText(inputFilePath)
                                    .Split(";")
                                    .Select(num => int.Parse(num))
                                    .ToList();

            // Фильтрация двухзначных чисел и их сортировка
            List<int> twoDigitNumbers = numbers
                                        .Where(num => num >= 10 && num <= 99 || num <= -10 && num >= -99)
                                        .Select(num => num + 1)
                                        .OrderBy(num => num)
                                        .ToList();


            File.WriteAllText(outputFilePath, string.Join(";", twoDigitNumbers));

            // File.WriteAllText(outputFilePath, string.Join(";", numbers
            //                             .Where(num => num >= 10 && num <= 99 || num <= -10 && num >= -99)
            //                             .Select(num => num + 1)
            //                             .OrderBy(num => num)
            //                             .ToList()));



            // foreach (int number in twoDigitNumbers)
            // {
            //     Console.WriteLine(number);
            // }

            //List<int> - потому что не известно кол-во чисел во входном файле и доступны linq запросы


        }
    }
}
