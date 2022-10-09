using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov
{
    internal class Program
    {
        static void Max(int[] arr)
        {
            double max = Math.Max(arr[0], arr[1]);
            Console.WriteLine(max);
        }
        static void Task_2(int[] arr)
        {
            int dop = arr[0];
            arr[0] = arr[1];
            arr[1] = dop;
            Console.WriteLine($"Результат: {String.Join(" ", arr)}");
        }
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Здание 1. Наибольшее из 2 чисел");
            Console.WriteLine();
            Console.Write("Введите массив: ");
            int[] arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            Console.Write("Наибольшее число: ");
            Max(arr);

            Console.WriteLine();
            */
            Console.WriteLine("Задание 2. Поменять местами значения 2 параметров");
            Console.WriteLine();
            Console.Write("Введите 2 числа: ");
            int[] arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            Task_2(arr);
        }
    }
}
