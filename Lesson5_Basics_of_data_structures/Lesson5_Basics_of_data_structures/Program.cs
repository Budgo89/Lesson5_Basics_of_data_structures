using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson5_Basics_of_data_structures
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 2
            //Реализовать метод расширения для поиска количество символов в строке
            string test = "Hello";

            var charTest = test.CharCount();

            Console.WriteLine(charTest);
            #endregion

            #region 3
            //Дана коллекция List<T>. Требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:
            List<double> a = new List<double> { 1.5, 2, 4.5, 2, 5.5, 4.4, 6, 2.3, 6 };

            // a. для целых чисел;
            var test2 = Integer(a);
            Console.WriteLine(test2);
            Console.WriteLine();

            //b * для обобщенной коллекции;
            RepeatingElements(a);
            Console.WriteLine();

            //** используя Linq.
            IntegerLinq(a);
            Console.WriteLine();
            #endregion

            #region 4

            //* Дан фрагмент программы:
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };
            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            foreach (var pair in d)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
            Console.WriteLine();

            // а. Свернуть обращение к OrderBy с использованием лямбда-выражения =>.
            var d1 = dict.OrderBy(pair => pair.Value);
            foreach (var pair in d1)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
            Console.WriteLine();

            //* Развернуть обращение к OrderBy с использованием делегата
            int muDelegate(KeyValuePair<string, int> pair)
            {
                return pair.Value;
            }
            Func<KeyValuePair<string, int>, int> predicate = muDelegate;
            var d2 = dict.OrderBy(predicate);
            foreach (var pair in d2)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
            #endregion
        }

        static int Integer(List<double> list)
        {
            int counter = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == Math.Truncate(list[i]))
                {
                    counter++;
                }
            }
            return counter;
        }

        static void RepeatingElements(List<double> list)
        {
            foreach (double val in list.Distinct())
            {
                Console.WriteLine(val + " - " + list.Where(x => x == val).Count() + " раз");
            }
        }
        
        static void IntegerLinq(List<double> list)
        {
            var integer = from n
                          in list
                          where n == Math.Truncate(n)
                          select n;
            foreach (double i in integer)
            {
                Console.WriteLine(i);
            }
        }
    }
}
