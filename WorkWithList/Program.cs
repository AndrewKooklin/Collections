using System;
using System.Collections.Generic;

namespace WorkWithList
{
    class Program
    {
        /// <summary>
        /// Сщздание списка 100 случайных чисел в диапазоне от 1 до 100
        /// </summary>
        /// <returns></returns>
        static List<int> ListCreation()
        {
            List<int> collectionInt = new List<int>();

            Random rnd = new Random();

            for (int i = 0; i < 100; i++)
            {
                collectionInt.Add(rnd.Next(100));
            }

            return collectionInt;
        }

        /// <summary>
        /// Вывод данных на консоль
        /// </summary>
        /// <param name="collection"></param>
        static void Output(List<int> collection)
        {
            Console.WriteLine("\n");

            foreach (int item in collection)
            {               
                Console.Write($"{item} ");
            }
        }

        /// <summary>
        /// Удаление чисел больше 25 и меньше 50
        /// </summary>
        /// <param name="collection">Принимает коллекцию целых чисел</param>
        /// <returns>Возвращает новый список</returns>
        static List<int> DeleteNumber(List<int> collection)
        {
            for( int i = 0; i < collection.Count; i++)
            {
                if((collection[i] > 25) && (collection[i] < 50))
                {
                    collection.RemoveAt(i);

                    i--; // Уменьшаем индекс, т.к. при удалении элемента индексы не проверенных элементов уменьшаются на 1
                }
            }
            return collection;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\n Программа создания списка случайных чисел." +
                "\n\n Создаем список из 100 чисел из диапазона от 0 до 100.");

            List<int> collection = ListCreation();

            Console.WriteLine("\n Выводим список в консоль :");

            Output(collection);

            Console.WriteLine("\n\n Удаляем из списка элементы, которые больше 25 и меньше 50.");

            Console.WriteLine("\n Выводим список в консоль :");

            Output(DeleteNumber(collection));

            Console.ReadLine();
        }
    }
}
