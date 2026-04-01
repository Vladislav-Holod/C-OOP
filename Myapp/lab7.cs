using System;

namespace Lab7 
{

    class Triangle
    {
        private double a, b;
        public Triangle()
        {
            a = 0;
            b = 0;
        }

        public Triangle(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public Triangle(double a)
        {
            this.a = a;
            this.b = a;
        }

        public void Input()
        {
            Console.Write("Введите катет a: ");
            a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите катет b: ");
            b = Convert.ToDouble(Console.ReadLine());
        }

        public void Input(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
        public double GetHypotenuse()
        {
            return Math.Sqrt(a * a + b * b);
        }

        public double GetArea()
        {
            return 0.5 * a * b;
        }

        public double GetPerimeter()
        {
            return a + b + GetHypotenuse();
        }


        public void Info()
        {
            Console.WriteLine("=== Прямоугольный треугольник ===");
            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}");
            Console.WriteLine($"c = {GetHypotenuse():F2}");
            Console.WriteLine($"S = {GetArea():F2}");
            Console.WriteLine($"P = {GetPerimeter():F2}");
        }

        public void Info(ConsoleColor fg, ConsoleColor bg)
        {
            Console.ForegroundColor = fg;
            Console.BackgroundColor = bg;

            Info();

            Console.ResetColor();
        }
    }

    public class Lab7
    {
        public static void Run_1()
        {

            Triangle t1 = new Triangle(3, 4);
            t1.Info(ConsoleColor.Yellow, ConsoleColor.Blue);


            Triangle t2 = new Triangle();
            t2.Input();
            t2.Info();

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}