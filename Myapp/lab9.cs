using System;
using System.IO;

namespace Lab10
{
    class Program
    {
        static void Main()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            var m1 = new Matrix();
            m1.Generate(5, 4);
            m1.Save("matrix1.txt");

            var m2 = new Matrix();
            m2.Generate(6, 3);
            m2.Save("matrix2.txt");

            var a = new Matrix();
            var b = new Matrix();

            if (!a.Load("matrix1.txt") || !b.Load("matrix2.txt"))
            {
                Console.WriteLine("Ошибка загрузки файлов");
                return;
            }

            Print("Matrix 1", a);
            Print("Matrix 2", b);

            float globalMin = Math.Min(a.Min(), b.Min());
            float globalMax = Math.Max(a.Max(), b.Max());

            Console.WriteLine($"\nGlobal Min: {globalMin:E}");
            Console.WriteLine($"Global Max: {globalMax:E}");

            Console.ReadKey();
        }

        static void Print(string title, Matrix m)
        {
            Console.WriteLine($"\n=== {title} ===");
            m.Print();
            Console.WriteLine($"Min: {m.Min():E}, Max: {m.Max():E}");
        }
    }

    class Matrix
    {
        float[,] data;

        public void Generate(int r, int c)
        {
            data = new float[r, c];
            var rand = new Random();

            for (int i = 0; i < r; i++)
                for (int j = 0; j < c; j++)
                    data[i, j] = (float)(rand.NextDouble() * 100 - 50);
        }

        public void Save(string file)
        {
            using var sw = new StreamWriter(file);

            sw.WriteLine($"{data.GetLength(0)} {data.GetLength(1)}");

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                    sw.Write(data[i, j] + " ");
                sw.WriteLine();
            }
        }

        public bool Load(string file)
        {
            if (!File.Exists(file)) return false;

            try
            {
                var lines = File.ReadAllLines(file);

                var size = lines[0].Split();
                int r = int.Parse(size[0]);
                int c = int.Parse(size[1]);

                data = new float[r, c];

                for (int i = 0; i < r; i++)
                {
                    var row = lines[i + 1].Split();
                    for (int j = 0; j < c; j++)
                        data[i, j] = float.Parse(row[j]);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Print()
        {
            if (data == null) return;

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                    Console.Write($"{data[i, j],8:F2}");
                Console.WriteLine();
            }
        }

        public float Min()
        {
            float min = data[0, 0];

            foreach (var v in data)
                if (v < min) min = v;

            return min;
        }

        public float Max()
        {
            float max = data[0, 0];

            foreach (var v in data)
                if (v > max) max = v;

            return max;
        }
    }
}