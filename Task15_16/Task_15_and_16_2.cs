using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            string outputFilePath_16_2 = "C:\\Users\\Mostov\\Knit_CSharp\\System_File\\output_file_for_16_2.txt";

            List<Depositor> depositors = new List<Depositor>();
            string[] lines = File.ReadAllLines(inputFilePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');

                if (parts.Length == 4)
                {
                    string name = parts[0].Trim();
                    string accountNumber = parts[1].Trim();
                    decimal depositAmount = decimal.Parse(parts[2].Trim());
                    int yearOpened = int.Parse(parts[3].Trim());

                    Depositor depositor = new Depositor(name, accountNumber, depositAmount, yearOpened);
                    depositors.Add(depositor);
                }
            }

            int currentYear = DateTime.Now.Year;
            System.Console.WriteLine(currentYear);

            // 16.2 
            var groupedDepositors = depositors
                .Where(d => d.YearOpened < currentYear)
                .GroupBy(d => d.YearOpened);

            // Запись результатов в выходной файл
            using (StreamWriter writer = new StreamWriter(outputFilePath_16_2))
            {
                foreach (var group in groupedDepositors)
                {
                    writer.WriteLine($"Год открытия: {group.Key}");
                    foreach (var depositor in group)
                    {
                        writer.WriteLine($"{depositor.FullName}, {depositor.AccountNumber}, {depositor.Amount}");
                    }
                    writer.WriteLine(); 
                }
            }
        }
    }
}
