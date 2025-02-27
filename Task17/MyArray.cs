using System;

namespace Knit_CSharp
{
    public class MyArray
    {
        private int[] IntArray;

        // 2. Конструкторы:

        public MyArray(int[] array)
        {
            IntArray = new MyArray(array.Length); ;
            for (int i = 0; i < array.Length; i++)
            {
                IntArray[i] = array[i];
            }

        }
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
            get
            {
                if (index >= 0 && index < IntArray.Length)
                {
                    return IntArray[index];
                }
                else
                {
                    throw new("Нет элемента с таким индексом");
                }

            }
            set
            {
                if (index >= 0 && index < IntArray.Length)
                {
                    IntArray[index] = value;
                }
                else
                {
                    throw new("Нет элемента с таким индексом");
                }

            }
        }

        // 7. Перегрузка оператора ++
        public static MyArray operator ++(MyArray myArray)
        {
            MyArray temp = new MyArray(myArray);
            for (int i = 0; i < myArray.Length; i++)
            {
                temp.IntArray[i]++;
            }
            return temp;
        }

        // 7. Перегрузка оператора --
        public static MyArray operator --(MyArray myArray)
        {
            MyArray temp = new MyArray(myArray);
            for (int i = 0; i < myArray.Length; i++)
            {
                temp.IntArray[i]--;
            }
            return temp;
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
            MyArray temp = new MyArray(myArray);
            for (int i = 0; i < temp.Length; i++)
            {
                temp.IntArray[i] *= scalar;
            }
            return temp;
        }

        // // 7. Преобразование в одномерный массив
        // public int[] ToArray()
        // {
        //     return (int[])IntArray;
        // }

        // // 7.
        // public static MyArray FromArray(int[] arr)
        // {
        //     MyArray myArray = new MyArray(arr.Length);
        //     Array.Copy(arr, myArray.IntArray, arr.Length);
        //     return myArray;
        // }

        //неявное преобразование типа Myarray в int []
        public static implicit operator int[](MyArray a)
        {
            int[] temp = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                temp[i] = a[i];
            }
            return temp;
        }

        //неявное преобразование типа int [] в Myarray
        public static implicit operator MyArray(int[] a)
        {
            return new MyArray(a);
        }
    }
}

// MyArray myArray = new MyArray(a.Length);
// Array.Copy(a, myArray.IntArray, a.Length);
// return myArray;
//return new MyArray();