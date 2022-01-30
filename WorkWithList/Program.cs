using System;
using System.Collections.Generic;

namespace WorkWithList
{
    class Program
    {
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

        static void Output(List<int> collection)
        {
            Console.WriteLine("\n");

            foreach (int item in collection)
            {
                
                Console.Write($"{item} ");
            }
        }

        static List<int> DeleteNumber(List<int> collection)
        {
            for( int i = 0; i < collection.Count; i++)
            {
                if(collection[i] > 25 && collection[i] < 50)
                {
                    collection.RemoveAt(i);
                }
            }
            return collection;
        }

        static void Main(string[] args)
        {
            List<int> collection = ListCreation();

            Output(collection);

            DeleteNumber(collection);

            Output(collection);

            Console.ReadLine();
        }
    }
}
