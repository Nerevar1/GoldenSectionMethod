using System;

namespace GoldenSectionMethod
{
    class Program
    {
        static void Main(string[] args)
        {

            //Ввод начальных условий для расчёта
            Console.WriteLine("В данном случае выполняется поиск минимума функции x^2");
            Console.WriteLine("Введите a");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите b");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите e");
            double e = double.Parse(Console.ReadLine());

            //Вызов метода выполняющего минимизацию
            GoldenRatioMethod(a, b, e);
            Console.ReadKey();
        }
        private static double F(double x)
        {//метод выполняющий заренее золоженную функцию
            double y = Math.Pow(x, 2);
            return y;
        }
        private static double GoldenRatioMethod(double a, double b, double e)
        {

            int cnt = 1;//счётчик итераций

            double x;
            double R;
            double x1 = a + 0.382 * (b - a);
            double x2 = b - 0.382 * (b - a);

            double A = F(x1);
            double B = F(x2);

        Start:
            Console.WriteLine("Итерация {0,-5} || a= {1,-15} || b= {2,-15} || b-a= {3,-15}", 
                cnt, Math.Round(a, 10), Math.Round(b, 10), Math.Round(b - a, 10));
            cnt++;

            if (A < B)
            {
                b = x2;
                if ((b - a) < e)
                {
                    x = (b + a) / 2;
                    R = Math.Round(F(x), 5);
                    Console.WriteLine($"F(x)= {R} x = {x}");
                    return x;
                }
                else
                {
                    x2 = x1;
                    B = A;
                    x1 = a + 0.382 * (b - a);
                    A = F(x1);
                    goto Start;
                }
            }
            else
            {
                a = x1;
                if ((b - a) < e)
                {
                    x = (b + a) / 2;
                    R = Math.Round(F(x), 5);
                    Console.WriteLine($"F(x)= {R} x = {x}");
                    return x;
                }
                else
                {
                    x1 = x2;
                    A = B;
                    x2 = b - 0.382 * (b - a);
                    B = F(x2);
                    goto Start;
                }
            }
        }
    }
}