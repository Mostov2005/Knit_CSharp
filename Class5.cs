using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Knit_CSharp
{
    public struct Depositor
    {
        public string FullName;
        public string AccountNumber;
        public decimal Amount;
        public int YearOpened;

        public Depositor(string fullName, string accountNumber, decimal amount, int yearOpened)
        {
            this.FullName = fullName;
            this.AccountNumber = accountNumber;
            this.Amount = amount;
            this.YearOpened = yearOpened;
        }
    }
    public class Class5
    {
        public void Run()
        {
            // Задание 15. На основе данных входного файла составить список вкладчиков банка,
            // включив следующие данные: ФИО, № счета, сумма, год открытия счета. Вывести в новый
            // файл информацию о тех вкладчиках, которые открыли вклад в текущем году, отсортировав
            // их по сумме вклада. 
            string inputFilePath = "C:\\Users\\Mostov\\Knit_CSharp\\System_File\\input_file_for_15_2.txt";
            string outputFilePath = "C:\\Users\\Mostov\\Knit_CSharp\\System_File\\output_file_for_15_2.txt";

            // Чтение данных из файла и создание списка вкладчиков
            List<Depositor> depositors = File.ReadAllLines(inputFilePath)
                                             .Select(line => line.Split(';'))
                                             .Select(parts => new Depositor(
                                                 parts[0].Trim(),
                                                 parts[1].Trim(),
                                                 decimal.Parse(parts[2].Trim()),
                                                 int.Parse(parts[3].Trim())))
                                             .ToList();
                                             
            int currentYear = DateTime.Now.Year;
            System.Console.WriteLine(currentYear);

            // Фильтрация и сортировка вкладчиков по текущему году и сумме вклада
            List<Depositor> currentYearDepositors = depositors
                                                    .Where(d => d.YearOpened == currentYear)
                                                    .OrderByDescending(d => d.Amount)
                                                    .ToList();

            // Запись результатов в выходной файл
            File.WriteAllLines(outputFilePath, currentYearDepositors.Select(d =>
                $"{d.FullName}, {d.AccountNumber}, {d.Amount}, {d.YearOpened}"));
        }
    }
}