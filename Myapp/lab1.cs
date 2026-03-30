using System;

namespace Lab1  
{
    public class Lab1 
    {
        public static void Run_1()
        {
            Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА 1. РАЗРАБОТКА КОНСОЛЬНОГО ПРИЛОЖЕНИЯ ");
            Console.WriteLine("Катигин Владислав Геннадьевич");
            Console.WriteLine("ИДПО_ИСИТ-3-24/1");
            Console.WriteLine("24.01.2004");
            Console.WriteLine("Ставрополь");
            Console.WriteLine("Информатика");
            Console.WriteLine("Программирования,Музыка");
        }

        public static void Run_2(){
            float f = 5.0f;  
            float y = 3.0f;   

            double Z = 35.0 / f + y * f - (f + y) / 4.0;

            Console.WriteLine($"Значение f = {f}");
            Console.WriteLine($"Значение y = {y}");
            Console.WriteLine($"Результат выражения Z = {Z}");
        }

    }
}