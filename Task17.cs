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

                System.Console.WriteLine("\n Начало 6 пунтка \n");


                Console.WriteLine("Первый элемент первого массива: {0}", array[0]);
                array[0] = 100; // Изменяем первый элемент
                Console.WriteLine("После изменения первого элемента: {0}", array);

                System.Console.WriteLine("\n Начало 7 пунтка \n");

                Console.WriteLine("Второй массив: {0}", twoArray);
                Console.WriteLine("Операция префиксного инкремента: ");
                ++twoArray; //1
                Console.WriteLine("Второй массив: {0}", twoArray);
                Console.WriteLine();

                Console.WriteLine("Операция постфиксного инкремента");
                MyArray twoArrayNew = twoArray++; //2

                Console.WriteLine("Второй массив массив: {0}", twoArray);
                Console.WriteLine("Новый второй массив: {0}", twoArrayNew);

                System.Console.WriteLine();

                --twoArray;
                Console.WriteLine("После уменьшения на 1: {0}", twoArray);

                Console.WriteLine("Массив второй не упорядочен?: {0}", !twoArray);

                MyArray multipliedArray = twoArray * 7;
                Console.WriteLine("Массив второй после умножения на 7: {0}", multipliedArray);

                int[] standardArray1 = twoArray; // неявное
                Console.WriteLine("Стандартный массив 1 из моего: {0}", string.Join(", ", standardArray1));

                int[] standardArray2 = (int[])twoArray; // явное
                System.Console.WriteLine("Стандартный массив 2 из моего: {0}", string.Join(", ", standardArray2));

                MyArray array_back = standardArray1; // неявное
                Console.WriteLine("Мой массив 1 из стандартного массива: {0}", array_back);

                MyArray array_back2 = (MyArray)standardArray2; // явное
                Console.WriteLine("Мой массив 2 из стандартного массива: {0}", array_back2);
            }
        }

    }
}
