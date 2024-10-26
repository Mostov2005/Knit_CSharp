using System;
using System.Diagnostics;
using System.Text;

namespace Knit_CSharp
{
    public class Class2
    {
        public void Run()
        {
            // Генерация случайной строки длиной 100000 символов
            string text = GenerateRandomString(100_000);
            // Генерация случайной подстроки длиной 3 символа
            string pattern = GenerateRandomString(100);
            Console.WriteLine($"Искомая подстрока: {pattern}");

            // Замер времени выполнения Прямого поиска (наивный поиск)
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int naiveResult = NaiveSearch(text, pattern);
            stopwatch.Stop();
            Console.WriteLine($"Наивный поиск: результат = {naiveResult}, время = {stopwatch.Elapsed.TotalMilliseconds} мс");

            // Замер времени выполнения Алгоритма Карпа-Рабина
            stopwatch.Restart();
            int karpRabinResult = RabinKarpSearch(text, pattern);
            stopwatch.Stop();
            Console.WriteLine($"Алгоритм Карпа-Рабина: результат = {karpRabinResult}, время = {stopwatch.Elapsed.TotalMilliseconds} мс");
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
            const long P = 37; // Простое число для хеширования
            long[] pwp = CalculatePowers(n, P); // Массив степеней P
            long[] h = CalculatePrefixHashes(text, pwp); // Хэши префиксов текста
            long h_s = CalculateHash(pattern, pwp); // Хэш для подстроки

            // Поиск подстроки
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
                    if (j == m) // Совпадение найдено
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
