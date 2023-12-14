using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
namespace exercise
{
    class Program
    {
        static void PrintNumbers()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }

        static int CalculateSquare(int number)
        {
            return number * number;
        }
        static async Task<int> CalculateFactorial(int number)
        {
            await Task.Delay(8000);
            int factorial = 1;
            for (int i = 2; i <= number; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

        static void Main()
        {
            Console.WriteLine("Упражнение 1");
            Thread thread1 = new Thread(PrintNumbers);
            Thread thread2 = new Thread(PrintNumbers);
            Thread thread3 = new Thread(PrintNumbers);
            thread1.Start();
            thread2.Start();
            thread3.Start();

            Thread.Sleep(100);
            Console.WriteLine("\nУпражнение 2");
            Console.WriteLine("Введите число:");
            int number;
            int.TryParse(Console.ReadLine(), out number);
            int square = CalculateSquare(number);
            Console.WriteLine("Квадрат: {0}", square);
            Task<int> factorialTask = CalculateFactorial(number);
            factorialTask.Wait();
            Console.WriteLine("Факториал: {0}", factorialTask.Result);

            Console.WriteLine("\nУпражнение 3");
            Refl obj = new Refl();
            Type type = obj.GetType();
            MethodInfo[] methods = type.GetMethods();
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
            }
            Console.ReadKey();
        }
    }
}
