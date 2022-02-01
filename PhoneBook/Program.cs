using System;
using System.Collections.Generic;

namespace PhoneBook
{
    class Program
    {
        public static Dictionary<string, string> phoneBook = new Dictionary<string, string>();

        static void ChooseAction()
        {
            string input;

            do
            {
                Console.WriteLine("\n Выберите действие программы: " +
                    "\n 1 - Ввод данных в телефонную книгу" +
                    "\n 2 - Поиск владельца по номеру телефона" +
                    "\n 3 - Выход из программы");

                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        {
                            phoneBook = InputData();
                            break;
                        }
                    case "2":
                        {
                            SearchPerson(phoneBook);
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine(" Программа завершена");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine(" Введите цифру от 1 до 3");
                            break;
                        }
                }
            }
            while (input != "3");
        }

        /// <summary>
        /// Ввод данных в телефонную книгу
        /// </summary>
        /// <returns></returns>
        static Dictionary<string, string> InputData()
        {
            Console.WriteLine(" Введите номера телефонов (каждый с новой строки) от 5 до 11 цифр," +
                "\n после последнего введенного номера введите пустую стороку");

            List<string> listPhone = new List<string>();

            do
            {
                string telephone = Console.ReadLine();

                if (long.TryParse(telephone, out long numberPhone) && (numberPhone > 9999 && numberPhone < 100000000000))
                {
                    listPhone.Add(telephone);
                }
                else if (telephone == "")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n Введите номер от 5 до 11 цифр" +
                        "\n или пустую строку для выхода");
                }
            }
            while (true);

            Console.WriteLine("\n Введите Ф.И.О.");

            string fullName = Console.ReadLine();

            for (int i = 0; i < listPhone.Count; i++)
            {
                phoneBook.Add(listPhone[i], fullName);
            }

            Console.WriteLine("\n Запись в телефонной книге создана");

            return phoneBook;
        }

        /// <summary>
        /// Поиск владельца по номеру телефона
        /// </summary>
        /// <param name="phoneBook"></param>
        static void SearchPerson(Dictionary<string, string> phoneBook)
        {
            if (phoneBook.Count == 0)
            {
                Console.WriteLine(" Телефонная книга пустая");
                return;
            }

            do
            {
                Console.WriteLine("\n Введите номер телефона от 5 до 11 цифр," +
                    "\n или пустую строку для выхода");

                string telephone = Console.ReadLine();

                if (!string.IsNullOrEmpty(telephone))
                {
                    if (!phoneBook.ContainsKey(telephone))
                    {
                        Console.WriteLine(" Владельца с таким номером не существует");
                        continue;
                    }

                    if (long.TryParse(telephone, out long numberPhone) && (numberPhone > 9999 && numberPhone < 100000000000))
                    {
                        if(phoneBook.TryGetValue(telephone, out string name))
                        {
                            Console.WriteLine($" Владелец телефона - {name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine(" Вы ввели не число или некорректный формат");

                        continue;
                    }
                }
                else
                {
                    break;
                }
            }
            while (true);
        }

        static void Main(string[] args)
        {
            ChooseAction();

            Console.ReadLine();
        }
    }
}
