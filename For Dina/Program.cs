using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace For_Dina
{
    internal class Program
    {
        public static void uravn(int[] arr)
        {
            double discr = arr[1] * arr[1] - 4 * arr[0] * arr[2];

            if (discr > 0)
            {
                double x1 = (-arr[1] + Math.Sqrt(discr)) / (2 * arr[0]);
                double x2 = (-arr[1] - Math.Sqrt(discr)) / (2 * arr[0]);
                Console.WriteLine($"x1 = {x1}, x2 = {x2}");
                Console.WriteLine();
            }
            else if (discr == 0)
            {
                double x = -arr[1] / (2 * arr[0]);
                Console.WriteLine($"x = {x}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Корней нет");
            }
        }
        public static void puz(int[] bubl)
        {
            int dop_per;
            for (int i = 0; i < bubl.Length - 1; i++)
            {
                for (int j = i + 1; j < bubl.Length; j++)
                {
                    if (bubl[i] > bubl[i + 1])
                    {
                        dop_per = bubl[i + 1];
                        bubl[i + 1] = bubl[i];
                        bubl[i] = dop_per;
                    }
                }
            }
        }
        static int sum(ref int proizv, out double sr_ar, params int[] array)
        {
            int summ = 0;
            proizv = 1;

            for (int i = 0; i < array.Length; i++)
            {
                summ += array[i];
                proizv *= array[i];
            }

            sr_ar = summ / array.Length;

            Console.WriteLine($"Произведение массива = {proizv}\nСреднее арифметическое массива = {sr_ar}");
            return summ;
        }
        enum words
        {
            Just_good_boy = 0,
            Good_boy,
            Very_good_boy,
            Super_good_boy,
        }
        public struct Dedok
        {
            public string Name;
            public byte Lvl;
            public string[] Phrases;
            public byte Bruises;

            public Dedok(string name, byte lvl, string[] phrases, byte bruises)
            {
                this.Name = name;
                this.Lvl = lvl;
                this.Phrases = phrases;
                this.Bruises = bruises;
            }
        }
        internal static byte Tasking_6(Dedok dedok, params string[] arr)
        {
            foreach (string i in dedok.Phrases)
            {
                if (arr.Contains(i))
                {
                    dedok.Bruises++;
                }
            }
            return dedok.Bruises;
        }
        static int[] SortArr(int[] arr, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = arr[leftIndex];

            while (i <= j)
            {
                while (arr[i] < pivot)
                {
                    i++;
                }

                while (arr[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    int dop = arr[i];
                    arr[i] = arr[j];
                    arr[j] = dop;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                SortArr(arr, leftIndex, j);

            if (i < rightIndex)
                SortArr(arr, i, rightIndex);

            return arr;
        }
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Задание 1. Квадратное уравнение");
            Console.WriteLine();
            Console.Write("Введите кэффициенты a, b, c : ");
            try {
                int[] arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                uravn(arr);
            } 
            catch (FormatException)
            {
                Console.WriteLine("Ошибка!");
            } 
            finally
            {
             Console.WriteLine("Спасибо!");
            }

            Console.WriteLine();
            
            Console.WriteLine("Задание 2. Поменять местами 2 числа в массиве");
            Console.WriteLine();
            try
            {
                int[] arr = new int[20];
                Random b = new Random();
                for (int i = 0; i <= 19; i++)
                {
                    arr[i] = b.Next(1, 100);
                }
                Console.WriteLine($"Случайный массив: {String.Join(" ", arr)}");
                Console.Write("Введите 2 числа из массива: ");
                int[] arr1 = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                int metka1 = 0, metka2 = 0; 
                for (int i=0; i<=19; i++)
                {
                    if (arr[i] == arr1[0] && metka1==0)
                    {
                        arr[i] = arr1[1];
                        metka1 = 1;
                    }
                    else if (arr[i] == arr1[1] && metka2==0)
                    {
                        metka2 = 1;
                        arr[i] = arr1[0];
                    }   
                }
                Console.WriteLine($"Итоговый массив: {String.Join(" ", arr)}");
            }
            catch 
            {
                Console.WriteLine("Ошибка!");
            }
            finally
            {
                Console.WriteLine("Спасибо!");
            }

            Console.WriteLine();
            
            Console.WriteLine("Задание 3. Сортировка массива пузырьком");
            Console.WriteLine();
            Console.WriteLine("Сколько чисел будем сортировать?");
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите числа для сортировки:");
            int[] bubl = new int[N];
            for (int i = 0; i < bubl.Length; i++)
            {
                bubl[i] = int.Parse(Console.ReadLine());
            }
            puz(bubl);
            Console.WriteLine("Отсортированный массив:");
            for (int i = 0; i < bubl.Length; i++)
            {
                Console.WriteLine(bubl[i]);
            }

            Console.WriteLine();
            
            Console.WriteLine("Задание 4. Арифметические операции с элементами массива");
            Console.WriteLine();
            Console.Write("Введите массив: ");
            int[] arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            int proizv = 0;
            double sr_ar;
            int summa = sum(ref proizv, out sr_ar, arr);
            Console.WriteLine($"Сумма = {summa}");
            
            Console.WriteLine();
            
            Console.WriteLine("Задание 6. Ворчливый дед");
            Console.WriteLine();
            string[] n1 = { "Чмошники!" };
            string[] n2 = { "Чудо!", "Королева!" };
            string[] n3 = { "Аутисты!", "Окей", "Ослы!" };
            string[] n4 = { "Жесткие!", "Топовые!", "Имбовые!", "Ладно!" };
            string[] n5 = { "Умнички!", "Любимая моя!", "Молорик!", "Офигенные!", "Богиня!" };

            string[] words = { "Жесткие!", "Водку!", "Молорик!", "Богиня!", "Окей", "Чмошники!", "Офигеть!", "Топовые!" };

            Dedok dedok1 = new Dedok("Аюб", 0, n1, 0);
            Dedok dedok2 = new Dedok("Петр", 1, n2, 0);
            Dedok dedok3 = new Dedok("Гена", 0, n3, 0);
            Dedok dedok4 = new Dedok("Геракл", 2, n4, 0);
            Dedok dedok5 = new Dedok("Лев", 3, n5, 0);

            Console.WriteLine($"Количество синяков от бабки:" + Tasking_6(dedok1, words));
            Console.WriteLine($"Количество синяков от бабки:" + Tasking_6(dedok2, words));
            Console.WriteLine($"Количество синяков от бабки:" + Tasking_6(dedok3, words));
            Console.WriteLine($"Количество синяков от бабки:" + Tasking_6(dedok4, words));
            Console.WriteLine($"Количество синяков от бабки:" + Tasking_6(dedok5, words));

            Console.WriteLine();
            */
            Console.WriteLine("Задание 7. Быстрая сортировка массива");
            Console.WriteLine();
            Console.Write("Введите массив: ");
            try
            {
                int[] arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                Console.WriteLine($"Результат: {string.Join(" ", SortArr(arr, 0, arr.Length - 1))}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка!");
            }
            finally
            {
                Console.WriteLine("Спасибо!");
            }
        }
    }
}
