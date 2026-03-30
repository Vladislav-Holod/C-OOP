using System;
using System.IO;

namespace Lab6
{
    public class Cone
    {

        private double r; // радиус основания
        private double h; // высота


        public double GetV()
        {
            return (1.0 / 3.0) * Math.PI * r * r * h;
        }

        public double GetS()
        {
            double l = Math.Sqrt(r * r + h * h);
            return Math.PI * r * (r + l);
        }

        public void Info()
        {
            string header = "***********************************\n" +
                           "*                                 *\n" +
                           "*           КОНУС                 *\n" +
                           "*                                 *\n" +
                           "***********************************\n";
            
            Console.WriteLine(header);
            Console.WriteLine($"Радиус основания (r) = {r:F2}");
            Console.WriteLine($"Высота (h)           = {h:F2}");
            Console.WriteLine($"Объем (V)            = {GetV():F2}");
            Console.WriteLine($"Площадь поверхности (S) = {GetS():F2}");
            Console.WriteLine();
        }


        public void Load()
        {
            r = Convert.ToDouble(Console.ReadLine());
            h = Convert.ToDouble(Console.ReadLine());
        }
    }

    // бейз класс лабораторной работы
    public class Lab6 
    {
        public static void Run_1()
        {
#if !DEBUG
            // RELEASE: перенаправляем ввод/вывод в файлы
            TextWriter originalOut = Console.Out;
            TextReader originalIn = Console.In;
            
            using (var reader = new StreamReader("cone_input.txt"))
            using (var writer = new StreamWriter("cone_output.txt"))
            {
                Console.SetIn(reader);
                Console.SetOut(writer);
                
                ExecuteConeLogic();
                
                Console.Out.Flush();
            }
            Console.SetOut(originalOut);
            Console.SetIn(originalIn);
#else
            // DEBUG: работаем с консолью
            ExecuteConeLogic();
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
#endif
        }

  
        private static void ExecuteConeLogic()
        {
            Cone cone = new Cone();
            cone.Load();
            cone.Info();
        }
    }
}


//mew