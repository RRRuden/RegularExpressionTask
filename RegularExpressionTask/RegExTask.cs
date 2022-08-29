using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegularExpressionTask
{
    public static class RegExTask
    {
        // Напишите регулярное выражения для вещественного числа с периодом.
        //Подходят: 0, -6, -0.5, +2, 0,0(64),
        //Не подходят: -0, 001, 0,(35)00, -3,750

        public static bool IsRealNumberWithPeriod(string str)
        {
            var regex = new Regex(@"^(([+-]?[1-9]+)([.,]\d[1-9]*)?|[+-]?0([.,]\d[1-9]*)|0)(\(\d+\))?$");
            return regex.IsMatch(str);
        }
        //На вход подается массив строк, каждая строка представляет собой двоичный код.
        //Правильным кодом называется строка, которая состоит либо только из нулей, либо только
        //из единиц, либо нули и единицы в ней чередуются
        //Например, 010101, 11, 00, 101 - правильные коды, 0110, 001, 11101 - неправильные.
        //Написать программу с использованием регулярных выражений, которая выводит строки,
        //представляющих собой правильный код (использовать matches)

        public static void PritnCorrectBinarySequence(string[] words)
        {
            MatchCollection match = new Regex(@"(([1][0])+[1]?)|(([0][1])+[0]?)|1+|0+").Matches(String.Join(" ", words));
            Console.WriteLine(string.Join(" ", match.Cast<Match>().Select(m => m.Value).ToArray()));
        }
        //Генерировать случайные положительные целые числа. Вывести первые 10
        //сгенерированных четных чисел, остановить генератор, вывести общее количество
        //сгенерированных чисел. Проверку на четность осуществлять регулярным выражением. НЕ
        //использовать математические операции (использовать matches).
        public static bool IsEvenNum(string str)
        {
            var regex = new Regex(@"(\d*)?[24680]$");
            return regex.IsMatch(str);
        }
        public static void PrintEvenNumbers()
        {
            int count = 0, evenNumsCount = 0;
            Random rnd = new Random(0);
            Console.WriteLine("Первые 10 сгенерированных четных чисел:/n");
            while (evenNumsCount != 10)
            {
                int num = rnd.Next();
                if (IsEvenNum(num.ToString()))
                {
                    Console.WriteLine(num);
                    evenNumsCount++;
                }
                count++;
            }
            Console.WriteLine("Общее кол-во чисел: {0}",count );
        }
        //Генерировать случайные положительные целые числа. Вывести первые 10
        //сгенерированных чисел, в которых нет трех четных цифр подряд. Остановить генератор,
        //вывести общее количество сгенерированных чисел. Проверку осуществлять регулярным
        //выражением. НЕ использовать математические операции для анализа числа

        public static bool ContainsThreeEvenNumsInRow(string str)
        {
            var regex = new Regex(@"\d*[24680]{3}\d*");
            return regex.IsMatch(str);
        }
        public static void PrintEx4()
        {
            int count = 0, numCount = 0;
            Random rnd = new Random(0);
            while (numCount != 10)
            {
                int num = rnd.Next();
                if (!ContainsThreeEvenNumsInRow(num.ToString()))
                {
                    Console.WriteLine(num);
                    numCount++;
                }
                count++;
            }
            Console.WriteLine("Общее кол-во чисел: " + count);
        }

        //Генерировать случайные положительные целые числа. Вывести первые 10
        //сгенерированных чисел, которые содержат более 3 и менее 6 четных цифр и ни одной
        //нечетной. Остановить генератор, вывести общее количество сгенерированных чисел.
        //Проверку осуществлять регулярным(-и) выражением(-ями).
        //НЕ использовать математические операции для анализа числа.
        public static void PrintEx5()
        {
            int i = 0, j = 0;
            Random rnd = new Random(0);
            Regex regex = new Regex(@"\b[02468]{4,5}\b");
            while (j != 10)
            {
                int num = rnd.Next();
                if (regex.IsMatch(num.ToString()))
                {
                    Console.WriteLine(num);
                    j++;
                }
                i++;
            }
            Console.WriteLine("Общее кол-во чисел: " + i);
        }
        //Генерировать случайные положительные целые числа. Вывести первые 10
        //сгенерированных чисел, в которых есть как минимум два раза встречается группа из 2
        //четных цифр. Остановить генератор, вывести общее количество сгенерированных чисел.
        //Проверку осуществлять регулярным выражением.
        //НЕ использовать математические операции для анализа числа.
        public static void PrintEx6()
        {
            int i = 0, j = 0;
            Random rnd = new Random(0);
            Regex regex = new Regex(@"\d*[02468]{2}\d*[02468]{2}\d*");
            while (j != 10)
            {
                int num = rnd.Next();
                if (regex.IsMatch(num.ToString()))
                {
                    Console.WriteLine(num);
                    j++;
                }
                i++;
            }
            Console.WriteLine("Общее кол-во чисел: " + i);
        }
        public static bool isPhoneCorrect(string str)
        {
            Regex regex = new Regex(@"^(\+7|8)[-]?(\()?(\d{3})(\))?[-]?(\d{3})[-]?(\d{2}[-]?)(\d{2})$");
            return regex.IsMatch(str);
        }

        public static bool isPasswordCorrect(String str)
        {
            Regex regex = new Regex(@"(?=.*[0-9])(?=.*[-+!@#+$%^&*])(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z!@#$%^&*+-]{8,}");
            return regex.IsMatch(str);
        }
        public static bool isCurrentData(String str)
        {
            Regex regex = new Regex(@"^(?:(?:1[6-9]|[2-9]\d)?\d{2})(?:(?:(\/|-|\.)(?:0?[13578]|1[02])\1(?:31))|(?:(\/|-|\.)(?:0?[13-9]|1[0-2])\2(?:29|30)))$|
^(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(\/|-|\.)0?2\3(?:29)$|
^(?:(?:1[6-9]|[2-9]\d)?\d{2})(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:0?[1-9]|1\d|2[0-8])$");
            return regex.IsMatch(str);
        }
        public static bool isEmailCorrect(String str)
        {
            Regex regex = new Regex(@"^[\w\.]+@([\w]+\.)+[\w]{2,4}$");
            return regex.IsMatch(str);
        }
    }
}
