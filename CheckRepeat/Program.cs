using System;
using System.Collections.Generic;

namespace CheckRepeat
{
    class Program
    {
        static void Start()
        {
            Console.WriteLine("\n Программа проверки наличия числа в коллекции");

            Console.WriteLine("\n Вводите каждое число с новой строки" +
                    "\n или пустую строку для выходв из программы");

            HashSet<int> set = new HashSet<int>();

            do
            {
                string input = Console.ReadLine();

                if (String.IsNullOrEmpty(input))
                {
                    Console.WriteLine("\n Программа завершена");

                    break;
                }               
                else if(Int32.TryParse(input, out int number))
                {
                    if (!set.Contains(number))
                    {
                        set.Add(number);

                        Console.WriteLine($"\n Число {number} добавлено в коллекцию");
                    }
                    else
                    {
                        Console.WriteLine($"\n Число {number} уже есть в коллекции");

                        continue;
                    }
                }
                else
                {
                    Console.WriteLine(" Вы ввели не число");

                    continue;
                }
            }
            while (true);
        }


        static void Main(string[] args)
        {
            Start();

            Console.ReadLine();
        }
    }
}
