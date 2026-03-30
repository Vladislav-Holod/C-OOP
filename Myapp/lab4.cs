using System;
using System.IO;

namespace Lab4  
{
    public class Lab4 
    {
        public static void Run_1()
        {
            TextWriter save_out = Console.Out;
            TextReader save_in = Console.In;
            var new_out = new StreamWriter("output.txt");
            var new_in = new StreamReader("input.txt");
            
            Console.SetOut(new_out);
            Console.SetIn(new_in);
            
            int N = Convert.ToInt32(Console.ReadLine());
            

            string str_all = Console.ReadLine()!;
            string[] str_elem = str_all.Split(' ');
            
            double[] mas = new double[N];
            for (int i = 0; i < N; i++)
            {
                mas[i] = Convert.ToDouble(str_elem[i]);
            }

            double maxNegative = double.MinValue;
            bool hasNegative = false;
            for (int i = 0; i < N; i++)
            {
                if (mas[i] < 0 && mas[i] > maxNegative)
                {
                    maxNegative = mas[i];
                    hasNegative = true;
                }
            }
            
            double minPositive = double.MaxValue;
            bool hasPositive = false;
            for (int i = 0; i < N; i++)
            {
                if (mas[i] > 0 && mas[i] < minPositive)
                {
                    minPositive = mas[i];
                    hasPositive = true;
                }
            }
            
            // Output results
            if (hasNegative)
            {
                Console.WriteLine(Math.Abs(maxNegative));
            }
            else
            {
                Console.WriteLine("No negative elements");
            }
            
            if (hasPositive)
            {
                Console.WriteLine(minPositive);
            }
            else
            {
                Console.WriteLine("No positive elements");
            }
            
            if (hasNegative && hasPositive)
            {
                for (int i = 0; i < N; i++)
                {
                    if (mas[i] > maxNegative && mas[i] < minPositive)
                    {
                        Console.Write(mas[i] + " ");
                    }
                }
            }
            
    
            Console.SetOut(save_out);
            new_out.Close();
            Console.SetIn(save_in);
            new_in.Close();
            
            Console.WriteLine("\nFile output.txt was created!!!");
            Console.ReadKey();
        }
    }
}