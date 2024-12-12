using System;

namespace Knit_CSharp
{
    public class Task17
    {
        public void Run()
        {
            string filePath = "C:\\Users\\Mostov\\Knit_CSharp\\System_File\\output_for_17.txt";

            // Открываем поток записи в файл
            using (StreamWriter writer = new StreamWriter(filePath))
            {

                Console.SetOut(writer); // перенаправление стандартный вывод из кгнсоли в файл

                MyArray array = new MyArray(5);
                Console.WriteLine("Первый массив: {0}", array);

                MyArray twoArray = new MyArray();
                Console.WriteLine("Второй массив: {0}", twoArray);

                MyArray threeArray = new MyArray(array);
                Console.WriteLine("Третий массив: {0}", threeArray);

                Console.WriteLine("Сумма первого массива: {0}", array.summArray());
                Console.WriteLine("Произведение первого массива: {0}", array.productArray());

                Console.WriteLine("Сумма второго массива: {0}", twoArray.summArray());
                Console.WriteLine("Произведение второго массива: {0}", twoArray.productArray());

                Console.WriteLine(array.Equals(twoArray));
                Console.WriteLine(array.Equals(threeArray)); // True, т.к это копия его

                Console.WriteLine("Хеш-код первого массива: {0}", array.GetHashCode());
                Console.WriteLine("Хеш-код второго массива: {0}", twoArray.GetHashCode());
                Console.WriteLine("Хеш-код третьего массива: {0}", threeArray.GetHashCode());

                Console.WriteLine("Типы массивов равны?: {0}", array.GetType() == twoArray.GetType());

                Console.WriteLine("Длина первого массива: {0}", array.Length);

                array.ScalarMultiplier = 2;
                Console.WriteLine("Первый массив после умножения на 2: {0}", array);

                Console.WriteLine("Первый элемент первого массива: {0}", array[0]);
                array[0] = 100; // Изменяем первый элемент
                Console.WriteLine("После изменения первого элемента: {0}", array);

                MyArray asd = ++twoArray;
                Console.WriteLine("После увеличения на 1: {0}", asd);

                MyArray d = --twoArray;
                Console.WriteLine("После уменьшения на 1: {0}", d);

                Console.WriteLine("Массив второй упорядочен?: {0}", !twoArray);

                MyArray multipliedArray = twoArray * 2;
                Console.WriteLine("Массив второй после умножения на 2: {0}", multipliedArray);

                int[] standardArray = array;
                Console.WriteLine("Стандартный массив: {0}", string.Join(", ", standardArray));

                int[] standardArray2 = { 10, 20, 30 };
                MyArray array_back = standardArray2;
                Console.WriteLine("Массив из стандартного массива: {0}", array_back);
            }
        }

    }
}
