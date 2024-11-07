using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Knit_CSharp
{
    public class Class2
    {
        public void Run()
        {
            // Строка
            string text = GenerateRandomString(100_000);

            string[] patterns = new string[3];
            for (int i = 0; i < patterns.Length; i++)
            {
                patterns[i] = GenerateRandomString(100); // Подстроки
            }

            // Построение массивов степеней и префиксных хешей для текста
            const long P = 37; // Простое число для хеширования
            long[] pwp = CalculatePowers(text.Length, P); // Массив степеней P
            long[] h = CalculatePrefixHashes(text, pwp); // Хэши префиксов текста

            // Замер времени выполнения поиска всех подстрок
            Stopwatch stopwatch = new Stopwatch();

            // Прямой поиск для всех подстрок
            stopwatch.Start();
            foreach (var pattern in patterns)
            {
                int result = NaiveSearch(text, pattern);
                Console.WriteLine($"Наивный поиск: результат = {result}");
            }
            stopwatch.Stop();
            Console.WriteLine($"Наивный поиск: время = {stopwatch.Elapsed.TotalMilliseconds} мс");

            // Алгоритм Карпа-Рабина для всех подстрок
            stopwatch.Restart();
            foreach (var pattern in patterns)
            {
                int result = RabinKarpSearch(text, pattern, h, pwp);
                Console.WriteLine($"Алгоритм Карпа-Рабина:  результат = {result}");
            }
            stopwatch.Stop();
            Console.WriteLine($"Алгоритм Карпа-Рабина: время = {stopwatch.Elapsed.TotalMilliseconds} мс");
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

        // Алгоритм Карпа-Рабина для поиска подстроки
        static int RabinKarpSearch(string text, string pattern, long[] h, long[] pwp)
        {
            int n = text.Length;
            int m = pattern.Length;
            long h_s = CalculateHash(pattern, pwp); // Хэш для подстроки

            for (int i = 0; i + m - 1 < n; i++)
            {
                // Находим хэш для текущего окна текста
                long cur_h = h[i + m - 1];
                if (i > 0)
                {
                    cur_h -= h[i - 1]; // Корректируем хэш для текущего окна
                }

                // Сравниваем хэши
                if (cur_h == h_s * pwp[i])
                {
                    int j;
                    // Если хэши совпадают, проверяем символы
                    for (j = 0; j < m; j++)
                    {
                        if (text[i + j] != pattern[j])
                            break;
                    }
                    if (j == m)
                        return i;
                }
            }

            return -1; // Подстрока не найдена
        }

        // Вычисление массива степеней P
        static long[] CalculatePowers(int length, long P)
        {
            long[] pwp = new long[length];
            pwp[0] = 1;
            for (int i = 1; i < length; i++)
            {
                pwp[i] = pwp[i - 1] * P;
            }
            return pwp;
        }

        // Вычисление хэш-значений для всех префиксов строки
        static long[] CalculatePrefixHashes(string text, long[] pwp)
        {
            long[] h = new long[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                h[i] = (text[i] - 'а' + 1) * pwp[i]; // Преобразование символа в значение
                if (i > 0)
                    h[i] += h[i - 1]; // Накопление хэшей для префиксов
            }
            return h;
        }

        // Вычисление хэш-значения для подстроки
        static long CalculateHash(string pattern, long[] pwp)
        {
            long h_s = 0;
            for (int i = 0; i < pattern.Length; i++)
            {
                h_s += (pattern[i] - 'а' + 1) * pwp[i];
            }
            return h_s;
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
