using System;
using System.IO;

namespace Lab5  
{
    public class Lab5 
    {
        public static void Run_1()
        {
            TextWriter save_out = Console.Out;
            TextReader save_in = Console.In;
            var new_out = new StreamWriter(@"output.txt");
            var new_in = new StreamReader(@"inp2.txt");
            Console.SetOut(new_out);
            Console.SetIn(new_in);

            int N = Convert.ToInt32(Console.ReadLine());
            int M = Convert.ToInt32(Console.ReadLine());

            int[,] mas = new int[N, M];
            for (int i = 0; i < N; i++)
            {
                string str_all = Console.ReadLine()!;
                string[] str_elem = str_all.Split(' ');
                for (int j = 0; j < M; j++)
                {
                    mas[i, j] = Convert.ToInt32(str_elem[j]);
                }
            }

            Console.WriteLine("Input matrix");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write(mas[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < N; i++)
            {
                int rowSum = 0;
                for (int j = 0; j < M; j++)
                {
                    rowSum += mas[i, j];
                }
                Console.WriteLine("Sum of row " + i + ": " + rowSum);
            }
            Console.WriteLine();


            Console.WriteLine("Column sums");
            for (int j = 0; j < M; j++)
            {
                int colSum = 0;
                for (int i = 0; i < N; i++)
                {
                    colSum += mas[i, j];
                }
                Console.WriteLine("Sum of column " + j + ": " + colSum);
            }

            Console.SetOut(save_out); new_out.Close();
            Console.SetIn(save_in); new_in.Close();
        }
    }
}