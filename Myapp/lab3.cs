using System;
using System.IO; 

namespace Lab3  
{
    public class Lab3 
    {
        public static void Run_1()
        {
            TextWriter save_out = Console.Out;
            TextReader save_in = Console.In;
            

            var new_out = new StreamWriter("output.txt");
            var new_in = new StreamReader("input.txt");

            Console.SetOut(new_out);
            Console.SetIn(new_in);

            int t = 0, N = 1;
            double X = 0, Y = 0, Z = 0;

            // Считывание данных из input
            // 1 строка: t (тип цикла)
            // 2 строка: N (кол-во слагаемых)
            // 3 строка: X
            // 4 строка: Y
            try 
            {
                t = Convert.ToInt32(Console.ReadLine());
                N = Convert.ToInt32(Console.ReadLine());
                X = Convert.ToDouble(Console.ReadLine());
                Y = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception)
            {        

                t = 0; N = 1; X = 1; Y = 1;
            }

            int i = 1;
            double chisl, znam;

            if (t == 0) 
            {
                for (i = 1; i <= N; i++)
                {
  
                    int stepY = 2 * i + 1;


                    int stepX = (i == 1) ? 0 : (2 * i - 3);


                    double part1 = 2 * i;
                    double part2 = (i == 1) ? 1 : (2 * i - 2);
                    
                    if (i % 2 != 0) 
                        znam = part1 + part2;
                    else         
                        znam = part1 - part2;

   
                    chisl = Math.Pow(Y, stepY) * Math.Pow(X, stepX);

                    if (i % 2 == 0)
                        chisl = -chisl;

                    Z += chisl / znam;
                }
            }
            else if (t == 1) 
            {
                i = 1;
                while (i <= N)
                {
                    int stepY = 2 * i + 1;
                    int stepX = (i == 1) ? 0 : (2 * i - 3);

                    double part1 = 2 * i;
                    double part2 = (i == 1) ? 1 : (2 * i - 2);

                    if (i % 2 != 0)
                        znam = part1 + part2;
                    else
                        znam = part1 - part2;

                    chisl = Math.Pow(Y, stepY) * Math.Pow(X, stepX);

                    if (i % 2 == 0)
                        chisl = -chisl;

                    Z += chisl / znam;
                    i++;
                }
            }
            else if (t == 2) 
            {
                i = 1;
                if (N >= 1) 
                {
                    do
                    {
                        int stepY = 2 * i + 1;
                        int stepX = (i == 1) ? 0 : (2 * i - 3);

                        double part1 = 2 * i;
                        double part2 = (i == 1) ? 1 : (2 * i - 2);

                        if (i % 2 != 0)
                            znam = part1 + part2;
                        else
                            znam = part1 - part2;

                        chisl = Math.Pow(Y, stepY) * Math.Pow(X, stepX);

                        if (i % 2 == 0)
                            chisl = -chisl;

                        Z += chisl / znam;
                        i++;
                    } while (i <= N);
                }
            }


            Console.WriteLine(String.Format("{0:0.000000}", Z));

            Console.SetOut(save_out); 
            new_out.Close();
            Console.SetIn(save_in); 
            new_in.Close();
        }
    }
}