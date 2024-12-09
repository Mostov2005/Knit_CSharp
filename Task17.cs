using System;

namespace Knit_CSharp
{
    public class Task17
    {
        public void Run()
        {
            MyArray array = new MyArray(5);
            System.Console.WriteLine("Первый массив: {0}", array);

            MyArray twoArray = new MyArray();
            System.Console.WriteLine("Второй массив: {0}", twoArray);

            MyArray threeArray = new MyArray(array);
            System.Console.WriteLine("Третий массив: {0}", threeArray);

            System.Console.WriteLine("Сумма первого массива: {0}", array.summArray());
            System.Console.WriteLine("Произведение первого массива: {0}", array.productArray());

            System.Console.WriteLine("Сумма второго массива: {0}", twoArray.summArray());
            System.Console.WriteLine("Произведение второго массива: {0}", twoArray.productArray());

            System.Console.WriteLine(array.Equals(twoArray));
            System.Console.WriteLine(array.Equals(threeArray)); //True, т.к это копия его

            System.Console.WriteLine("Хеш-код первого массива: {0}", array.GetHashCode());
            System.Console.WriteLine("Хеш-код второго массива: {0}", twoArray.GetHashCode());
            System.Console.WriteLine("Хеш-код третьего массива: {0}", threeArray.GetHashCode());

            Console.WriteLine("Типы массивов равны?: {0}", array.GetType() == twoArray.GetType());

            // 5. 
            Console.WriteLine("Длина первого массива: {0}", array.Length);

            // 5. 
            array.ScalarMultiplier = 2;
            Console.WriteLine("Первый массив после умножения на 2: {0}", array);

            // 6. Использование индексатора
            Console.WriteLine("Первый элемент первого массива: {0}", array[0]);
            array[0] = 100; // Изменяем первый элемент
            Console.WriteLine("После изменения первого элемента: {0}", array);


            // 8. 
            ++twoArray;
            Console.WriteLine("После увеличения на 1: {0}", twoArray);

            // Уменьшение всех элементов на 1
            --twoArray;
            Console.WriteLine("После уменьшения на 1: {0}", twoArray);

            // Проверка упорядоченности массива
            Console.WriteLine("Массив второй упорядочен?: {0}", !twoArray);

            // Умножение всех элементов на 2
            MyArray multipliedArray = twoArray * 2;
            Console.WriteLine("Массив второй после умножения на 2: {0}", multipliedArray);

            // операции преобразования класса массив в одномерный массив (и наоборот).
            int[] standardArray = array.ToArray(); // Преобразование в int[]
            System.Console.WriteLine(standardArray);

            int[] standardArray2 = { 10, 20, 30 };
            MyArray array_back = MyArray.FromArray(standardArray2);
            System.Console.WriteLine(array_back);

        }
    }

    public class MyArray
    {
        private int[] IntArray;

        // 2. Конструкторы:
        public MyArray(MyArray array)
        {
            this.IntArray = new int[array.Length];
            Array.Copy(array.IntArray, this.IntArray, array.Length);
        }

        public MyArray()
        {
            this.IntArray = new int[10];
            for (int i = 1; i < 11; i++)
            {
                this.IntArray[i - 1] = i;
            }
        }
        public MyArray(int n)
        {
            this.IntArray = new int[n];
            for (int i = 1; i < n + 1; i++)
            {
                this.IntArray[i - 1] = i;
            }
        }

        // 3.
        public int summArray()
        {
            int summ = 0;
            foreach (int number in IntArray)
            {
                summ += number;
            }
            return summ;
        }
        public int productArray()
        {
            if (IntArray.Length == 0)
            {
                return 0;
            }
            int product = 1;
            foreach (int number in IntArray)
            {
                product *= number;
            }
            return product;
        }

        // 4. 
        public override string ToString()
        {
            return string.Join(", ", this.IntArray);
        }

        // 4. 
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            MyArray other = (MyArray)obj;

            if (IntArray == null && other.IntArray == null) return true;
            if (IntArray == null || other.IntArray == null) return false;

            if (IntArray.Length != other.IntArray.Length)
            {
                return false;
            }

            for (int i = 0; i < IntArray.Length; i++)
            {
                if (IntArray[i] != other.IntArray[i])
                {
                    return false;
                }
            }

            return true;
        }

        // 4. 
        public override int GetHashCode()
        {
            int hash = 1;
            int con = 17; // Константа для получения хеш-кода  
            if (IntArray != null)
            {

                // return IntArray.GetHashCode();
                foreach (int i in IntArray)
                {
                    hash = hash * con * i;

                }
            }
            return hash;
        }

        // 5. Свойство для получения размерности массива
        public int Length
        {
            get { return IntArray.Length; }
        }

        // 5. Свойство для умножения всех элементов массива на скаляр
        public int ScalarMultiplier
        {
            set
            {
                for (int i = 0; i < IntArray.Length; i++)
                {
                    this.IntArray[i] *= value;
                }
            }
        }

        // 6. Индексатор для доступа к элементам массива
        public int this[int index]
        {
            get { return IntArray[index]; }
            set { IntArray[index] = value; }
        }

        // 7. Перегрузка оператора ++
        public static MyArray operator ++(MyArray myArray)
        {
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray.IntArray[i]++;
            }
            return myArray;
        }

        // 7. Перегрузка оператора --
        public static MyArray operator --(MyArray myArray)
        {
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray.IntArray[i]--;
            }
            return myArray;
        }

        // 7. Перегрузка оператора !
        public static bool operator !(MyArray myArray)
        {
            for (int i = 1; i < myArray.Length; i++)
            {
                if (myArray.IntArray[i] < myArray.IntArray[i - 1])
                    return true;
            }
            return false;
        }

        // 7. Перегрузка бинарного оператора *
        public static MyArray operator *(MyArray myArray, int scalar)
        {
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray.IntArray[i] *= scalar;
            }
            return myArray;
        }

        // 7. Преобразование в одномерный массив
        public int[] ToArray()
        {
            return (int[])IntArray.Clone();
        }

        // 7.
        public static MyArray FromArray(int[] arr)
        {
            MyArray myArray = new MyArray(arr.Length);
            Array.Copy(arr, myArray.IntArray, arr.Length);
            return myArray;
        }

    }
}