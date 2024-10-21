using System;
using System.IO;

namespace MyfirstApp
{
    public class Class1
    {

    // 15. Дан файл, компонентами которого являются числа. Число компонент файла делится на два.
    // Создать новый файл, в который будет записываться наименьшее из каждой пары чисел первого файла.
        public void Run()
        {
            string directoryPath = "C:\\Users\\Mostov\\Knit_CSharp\\System_File";
            Directory.CreateDirectory(directoryPath); // Создание папки, если она не существует

            // Путь к файлам
            string filePath1 = Path.Combine(directoryPath, "input.txt");
            string filePath2 = Path.Combine(directoryPath, "output.txt");

            // Чтение чисел из файла
            string[] lines = File.ReadAllLines(filePath1);
            int[] numbers = Array.ConvertAll(lines, int.Parse);

            // Проверка на четность количества чисел(В условии указано, что чётное)
            if (numbers.Length % 2 != 0)
            {
                Console.WriteLine("Количество чисел должно быть четным.");
                return;
            }

            using (StreamWriter writer = new StreamWriter(filePath2))
            {
                for (int i = 0; i < numbers.Length; i += 2)
                {
                    int min = Math.Min(numbers[i], numbers[i + 1]);
                    writer.WriteLine(min);
                }
            }

            Console.WriteLine("Результаты записаны в файл " + filePath2);
        }
    }
}
