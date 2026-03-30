using System;
using System.IO;
using System.Globalization;

namespace Lab2
{
    public class Lab2
    {
        public static void Run_1()
        {
            TextWriter originalOut = Console.Out;
            TextReader originalIn = Console.In;

            if (!File.Exists("input.txt"))
            {
                Console.WriteLine("файл input.txt не найден!");
                return;
            }

            using (StreamWriter writer = new StreamWriter("output.txt"))
            using (StreamReader reader = new StreamReader("input.txt"))
            {
                Console.SetOut(writer);
                Console.SetIn(reader);

                try
                {
                    float a = float.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
                    float b = float.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
                    float c = float.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
                    float d = float.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
                    float e = float.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

                    bool isError = false;

                    if (b <= c)
                    {
                        isError = true;
                    }
                    if (MathF.Abs((e + a) - 1.0f) < 1e-6f)
                    {
                        isError = true;
                    }
                    if (b + c - d < 0)
                    {
                        isError = true;
                    }
                    if (b - c - a * a <= 0)
                    {
                        isError = true;
                    }

                    if (isError)
                    {
                        Console.WriteLine("ERROR");
                    }
                    else
                    {
                        float s = (b / MathF.Sqrt(b - c)) + (e / (MathF.Sqrt(e + a) - 1));
                        float k = MathF.Sqrt(b + c - d) / MathF.Sqrt(b - c - a * a);
                        
                        Console.WriteLine($"{s:F3}");
                        Console.WriteLine($"{k:F3}");
                    }
                }
                catch (Exception)
                {
                    Console.SetOut(originalOut);
                    Console.SetOut(writer);
                    Console.WriteLine("ERROR");
                }
                finally
                {
                    Console.SetOut(originalOut);
                    Console.SetIn(originalIn);
                }
            }
        }
    }
}