using System;
using System.Collections.Generic;
using System.IO;

namespace Knit_CSharp
{
    struct SPoint
    {
        public int x, y;

        public SPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Show()
        {
            Console.WriteLine("({0}, {1})", x, y);
        }

        public double DistanceTo(SPoint other)
        {
            int dx = x - other.x;
            int dy = y - other.y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }

    class Task_14_1
    {
        public void Run()
        {
            SPoint[] array = Input();
            // Находим точки с минимальной суммой расстояний до остальных
            List<SPoint> optimalPoints = FindOptimalPoints(array);

            Console.WriteLine("Точки с минимальной суммой расстояний до остальных:");
            foreach (SPoint point in optimalPoints)
            {
                point.Show();
            }
        }

        static public SPoint[] Input() // Читаем данные из файла
        {
            using (StreamReader fileIn = new StreamReader("C:\\Users\\Mostov\\Knit_CSharp\\System_File\\input3.txt"))
            {
                int n = int.Parse(fileIn.ReadLine());
                SPoint[] ar = new SPoint[n];
                for (int i = 0; i < n; i++)
                {
                    string[] text = fileIn.ReadLine().Split(' ');
                    ar[i] = new SPoint(int.Parse(text[0]), int.Parse(text[1]));
                }
                return ar;
            }
        }

        static void Print(SPoint[] array) 
        {
            foreach (SPoint item in array)
            {
                item.Show();
            }
        }

        // Метод для нахождения всех точек с минимальной суммой расстояний до остальных точек
        static List<SPoint> FindOptimalPoints(SPoint[] array)
        {
            double minTotalDistance = double.MaxValue;
            List<SPoint> optimalPoints = new List<SPoint>();

            foreach (SPoint point in array)
            {
                double totalDistance = 0;

                foreach (SPoint otherPoint in array)
                {
                    if (!point.Equals(otherPoint)) // Не учитываем расстояние до самой себя
                    {
                        totalDistance += point.DistanceTo(otherPoint);
                    }
                }

                if (totalDistance < minTotalDistance)
                {
                    minTotalDistance = totalDistance;
                    optimalPoints.Clear();
                    optimalPoints.Add(point);
                }
                else if (totalDistance == minTotalDistance)
                {
                    optimalPoints.Add(point);
                }
            }

            return optimalPoints;
        }
    }
}
