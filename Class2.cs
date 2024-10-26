// File1.cs
using System;
using System.Diagnostics;
using System.Text;
namespace MyfirstApp
{
    public class Class2

    {
        static void Run(string[] args)
        {
            // Генерация случайной строки длиной 100000 символов
            string text = GenerateRandomString(100000);
            // Генерация случайной подстроки длиной 100 символов
            string pattern = GenerateRandomString(100);

            // Замер времени выполнения Прямого поиска (наивный поиск)
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            int naiveResult = NaiveSearch(text, pattern);
            stopwatch.Stop();
            Console.WriteLine($"Наивный поиск: результат = {naiveResult}, время = {stopwatch.ElapsedMilliseconds} мс");

            // Замер времени выполнения Алгоритма Карпа-Рабина
            stopwatch.Restart();
            int karpRabinResult = RabinKarpSearch(text, pattern);
            stopwatch.Stop();
            Console.WriteLine($"Алгоритм Карпа-Рабина: результат = {karpRabinResult}, время = {stopwatch.ElapsedMilliseconds} мс");
        }

        // Прямой поиск подстроки
        static int NaiveSearch(string text, string pattern)
        {
            int n = text.Length;
            int m = pattern.Length;

            for (int i = 0; i <= n - m; i++)
            {
                int j;
                for (j = 0; j < m; j++)
                {
                    if (text[i + j] != pattern[j])
                        break;
                }
                if (j == m) // Совпадение найдено
                    return i;
            }
            return -1; // Подстрока не найдена
        }

        // Алгоритм Карпа-Рабина
        static int RabinKarpSearch(string text, string pattern)
        {
            int n = text.Length;
            int m = pattern.Length;
            int q = 101; // Простое число
            int d = 256; // Размер алфавита
            int h = 1;
            int p = 0; // Хэш паттерна
            int t = 0; // Хэш текста
            int i, j;

            // Вычисляем h = pow(d, m-1) % q
            for (i = 0; i < m - 1; i++)
                h = (h * d) % q;

            // Вычисляем начальные хэши паттерна и первого окна текста
            for (i = 0; i < m; i++)
            {
                p = (d * p + pattern[i]) % q;
                t = (d * t + text[i]) % q;
            }

            // Пробегаем по тексту
            for (i = 0; i <= n - m; i++)
            {
                // Проверяем хэши
                if (p == t)
                {
                    // Если хэши совпадают, проверяем символы
                    for (j = 0; j < m; j++)
                    {
                        if (text[i + j] != pattern[j])
                            break;
                    }

                    if (j == m) // Совпадение найдено
                        return i;
                }

                // Вычисляем хэш следующего окна текста
                if (i < n - m)
                {
                    t = (d * (t - text[i] * h) + text[i + m]) % q;

                    // Если t оказалось отрицательным, добавляем q
                    if (t < 0)
                        t = (t + q);
                }
            }

            return -1; // Подстрока не найдена
        }

        // Генерация случайной строки из букв русского алфавита
        static string GenerateRandomString(int length)
        {
            Random random = new Random();
            StringBuilder result = new StringBuilder(length);
            string russianAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

            for (int i = 0; i < length; i++)
            {
                result.Append(russianAlphabet[random.Next(russianAlphabet.Length)]);
            }

            return result.ToString();
        }
    }
}

