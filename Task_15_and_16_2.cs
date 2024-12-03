using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Задание 15-16. На основе данных входного файла составить список вкладчиков банка,
// включив следующие данные: ФИО, № счета, сумма, год открытия счета. Вывести в новый
// файл информацию о тех вкладчиках, которые открыли вклад в текущем году, отсортировав
// их по сумме вклада. 


namespace Knit_CSharp
{
    public struct Depositor
    {
        public string FullName;
        public string AccountNumber; // Id
        public decimal Amount; // Сумма вклада
        public int YearOpened; // Дата вклада

        public Depositor(string fullName, string accountNumber, decimal amount, int yearOpened)
        {
            this.FullName = fullName;
            this.AccountNumber = accountNumber;
            this.Amount = amount;
            this.YearOpened = yearOpened;
        }
    }
    public class Task_15_and_16_2
    {
        public void Run()
        {

            string inputFilePath = "C:\\Users\\Mostov\\Knit_CSharp\\System_File\\input_file_for_15_2.txt";
            string outputFilePath_15_2 = "C:\\Users\\Mostov\\Knit_CSharp\\System_File\\output_file_for_15_2.txt";
            string outputFilePath_16_2 = "C:\\Users\\Mostov\\Knit_CSharp\\System_File\\output_file_for_16_2.txt";

            
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


            // Практикум 15_2
            // Фильтрация и сортировка вкладчиков по текущему году и сумме вклада
            List<Depositor> depositors_15_2 = 
                (from Depositor depositor in depositors
                where depositor.YearOpened == currentYear
                orderby depositor.Amount 
                select depositor).ToList();

            // Запись результатов в выходной файл
            File.WriteAllLines(outputFilePath_15_2, depositors_15_2.Select(d =>
                $"{d.FullName}, {d.AccountNumber}, {d.Amount}, {d.YearOpened}"));

            // 16.2
            List<Depositor> depositors_16_2 = depositors
                .Where (d => d.YearOpened == currentYear)
                .OrderBy(d => d.Amount)
                .ToList();

            // Запись результатов в выходной файл
            File.WriteAllLines(outputFilePath_16_2, depositors_16_2.Select(d =>
                $"{d.FullName}, {d.AccountNumber}, {d.Amount}, {d.YearOpened}"));

        }
    }
}
