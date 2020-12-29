using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM6
{
    delegate double DoOperation(double x, double y);
    delegate double Min(double x, double y);
    public delegate double Fun(double x);


    class Program
    {
        public static double F(double x)
        {
            return x * x;
        }
        public static double G(double x)
        {
            return x * x * x;
        }
        public static double H(double x)
        {
            return 1 - x;
        }

        public static void FunMin(Fun oper, double x, double y)
        {
            double min = oper(x);
            for (double i = x + 1; i <= y; i++)
            {
                if (min > oper(i)) min = oper(i);
            }
            Console.Write(min);
        }


        public static int[] Load(string fileName, out int min)
        {
            StreamReader sr = new StreamReader(fileName);
            string[] s = sr.ReadLine().Split(' ');
            int[] arrNum = new int [s.Length];
            min = int.Parse(s[0]);
            for (int j = 0; j < s.Length; j++) 
            {
                arrNum[j] = int.Parse(s[j]);
                if (min > arrNum[j])
                {
                    min = arrNum[j];
                }
            }

            return arrNum;
        }

        #region Methods
        public static void Process(DoOperation operation, double x, double y)
        {
            var res = operation(x, y);
            Console.Write($" = {res}");
            Console.WriteLine();
        }

        public static double Plus(double x, double y)
        {
            Console.Write($"{x} + {y}");
            return x + y;
        }
        

        public static double Minus(double x, double y)
        {
            Console.Write($"{x} - {y}");
            return x - y;
        }

        public static double Power(double x, double y)
        {
            Console.Write($"{x}^2 * {y}");
            return Math.Pow(x, 2) * y;
        }
        public static double Sin(double x, double y)
        {
            Console.Write($"sin({x}) * {y}");
            return Math.Round(Math.Sin(x), 2) * y;
        }
        #endregion

       
        static void Main(string[] args)
        {
            #region Условия

            //1.Изменить программу вывода функции так, чтобы можно было передавать функции типа double(double, double).Продемонстрировать работу на функции с функцией a*x ^ 2 и функцией a* sin(x).
            //2.Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
            //    а) Сделайте меню с различными функциями и предоставьте пользователю выбор, для какой функции и на каком отрезке находить минимум.
            //    б) Используйте массив(или список) делегатов, в котором хранятся различные функции.
            //    в) *Переделайте функцию Load, чтобы она возвращала массив считанных значений.Пусть она
            //    возвращает минимум через параметр.

            //3.Переделать программу «Пример использования коллекций» для решения следующих задач:
            //    а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
            //    б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(частотный массив);
            //    в) отсортировать список по возрасту студента;
            //    г) *отсортировать список по курсу и возрасту студента;
            //    д) разработать единый метод подсчета количества студентов по различным параметрам
            //    выбора с помощью делегата и методов предикатов.
            //    *Достаточно решить 2 задачи.Старайтесь разбивать программы на подпрограммы.Переписывайте в начало программы условие и свою фамилию. Все программы сделайте в одном решении.

            #endregion

            #region Зд.1
            //Process(Plus, 15, 23);
            //Process(Minus, 453, 196);

            //DoOperation multiOperation = delegate (double x, double y)
            //{
            //    Console.Write($"{x} * {y}");
            //    return x * y;
            //};
            //Console.WriteLine($" = {multiOperation(5, 5)}");

            //Process(Power, 5, 2);
            //Process(Sin, 45, 3);

            //Console.WriteLine();
            #endregion

            #region Зд.2(а, )

            int ch;
            Console.Write("1) x * x\n2) x * x * x\n3) 1 - x\n");
            do
            {
                Console.Write("Выбор функции: ");
                ch = Convert.ToInt32(Console.ReadLine());
            } while (ch != 1 && ch != 2 && ch != 3);

            Console.Write("Введите отрезкок для нахождения минимума x1: ");
            int x1 = Convert.ToInt32(Console.ReadLine());
            int x2;
            do
            {
                Console.Write("x2 (x2 > x1): ");
                x2 = Convert.ToInt32(Console.ReadLine());
            } while (x2 <= x1);

            switch (ch)
            {
                case 1:
                    Console.Write("Минимальное значение функции на отрезке: ");
                    FunMin(F, x1, x2);
                    break;
                case 2:
                    Console.Write("Минимальное значение функции на отрезке: ");
                    FunMin(G, x1, x2);
                    break;
                case 3:
                    Console.Write("Минимальное значение функции на отрезке: ");
                    FunMin(H, x1, x2);
                    break;
            }
            Console.WriteLine();
          
            //2(б) массив делегатов
            Fun[] arr = { F, G, H };
            Console.Write("\nЭта же задача через массив делегатов");
            Console.Write("\n1. x * x\n2.x * x * x\n3. 1 - x\n");
            do
            {
                Console.Write("Выбор функции: ");
                ch = Convert.ToInt32(Console.ReadLine());
            } while (ch != 1 && ch != 2 && ch != 3);

            Console.Write("Введите отрезкок для нахождения минимума x1: ");
            x1 = Convert.ToInt32(Console.ReadLine());
            do
            {
                Console.Write("x2 (x2 > x1): ");
                x2 = Convert.ToInt32(Console.ReadLine());
            } while (x2 <= x1);

            Console.Write("Минимальное значение функции на отрезке: ");
            FunMin(arr[ch - 1], x1, x2);

            //2(в)
            int min = int.MaxValue;
            Console.Write("\n\nИз файла в массив считали данные и вывели минимальное значение: ");
            Load("file.txt", out min);
            Console.WriteLine(min);

            #endregion      
            Console.ReadLine();

        }
      
    }
}
