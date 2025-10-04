using System;
using System.Numerics;

namespace LabWork
{
    // Даний проект є шаблоном для виконання лабораторних робіт
    // з курсу "Об'єктно-орієнтоване програмування та патерни проектування"
    // Необхідно змінювати і дописувати код лише в цьому проекті
    // Відео-інструкції щодо роботи з github можна переглянути 
    // за посиланням https://www.youtube.com/@ViktorZhukovskyy/videos 

    class Result
    {
        private double x;
        private double y;
        private double z;

        // Конструктор
        public Result(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // Метод для введення координат
        public void InputCoordinates(double vx, double vy, double vz)
        {
            x = vx;
            y = vy;
            z = vz;
        }

        // Обчислення довжини вектора
        public double GetLength()
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
        }

        // Вивід координат
        public void Print()
        {
            Console.WriteLine($"({x}, {y}, {z})");
        }

        // Деструктор
        ~Result()
        {
            Console.WriteLine("Об'єкт Vector знищено (Garbage Collector)");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть кількість векторів: ");
            int count = Convert.ToInt32(Console.ReadLine());

            Result[] vectors = new Result[count];

            // Заповнення масиву
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Вектор {i + 1}:");
                Console.Write("x = ");
                double x = Convert.ToDouble(Console.ReadLine());
                Console.Write("y = ");
                double y = Convert.ToDouble(Console.ReadLine());
                Console.Write("z = ");
                double z = Convert.ToDouble(Console.ReadLine());

                vectors[i] = new Result(x, y, z);
            }

            // Пошук вектора з максимальною довжиною
            double maxLength = vectors[0].GetLength();
            int maxIndex = 0;

            for (int i = 1; i < count; i++)
            {
                if (vectors[i].GetLength() > maxLength)
                {
                    maxLength = vectors[i].GetLength();
                    maxIndex = i;
                }
            }

            Console.WriteLine($"\nВектор №{maxIndex + 1} має найбільшу довжину:");
            vectors[maxIndex].Print();
            Console.WriteLine($"Довжина = {maxLength}");

            // Виклик GC (для демонстрації деструктора)
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
