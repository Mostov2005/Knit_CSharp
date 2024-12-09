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
        }
    }

    public class MyArray
    {
        public int[] IntArray;

        // Конструкторы:
        public MyArray(MyArray array)
        {
            this.IntArray = array.IntArray;
            int n = array.IntArray.Length;

            for (int i = 1; i < n + 1; i++)
            {
                this.IntArray[i - 1] = i;
            }
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

        public override string ToString()
        {
            return string.Join(", ", this.IntArray);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            MyArray other = (MyArray)obj;

            if (IntArray == null || other.IntArray == null)
            {
                return IntArray == other.IntArray; // оба null - равны
            }

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

        public override int GetHashCode()
        {
            int hash = 1;
            int con = 17; // Константа для получения хеш-кода  
            if (IntArray != null)
            {
                foreach (int i in IntArray)
                {
                    hash = hash * con * i;

                }
            }
            return hash;
        }
    }
}