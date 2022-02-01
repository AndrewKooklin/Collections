using System;
using System.IO;
//using System.Xml.Serialization;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

namespace NoteBook
{
    class Program
    {
        public class Person
        {
            public string FullName { get; set; }

            public string StreetName { get; set; }

            public int HouseNumber { get; set; }

            public int FlatNumber { get; set; }

            public long MobilePhoneNumber { get; set; }

            public long FlatPhoneNumber { get; set; }
        }

        static List<Person> InputData()
        {
            Console.WriteLine("\n Введите данные о контакте");

            List<Person> listPerson = new List<Person>();

            Person newPerson;

            do
            {
                newPerson = new Person();

                while (true)
                {
                    Console.WriteLine("\n Введите Ф.И.О.");

                    string tempFullName = Console.ReadLine();

                    if (String.IsNullOrEmpty(tempFullName) || String.IsNullOrWhiteSpace(tempFullName))
                    {
                        Console.WriteLine("\n Поле \"Ф.И.О.\" не может быть пустой строкой");

                        continue;
                    }
                    else
                    {
                        newPerson.FullName = tempFullName;

                        break;
                    }
                }

                while (true)
                {
                    Console.WriteLine("\n Введите название улицы");

                    string tempStreetName = Console.ReadLine();

                    if (String.IsNullOrEmpty(tempStreetName) || String.IsNullOrWhiteSpace(tempStreetName))
                    {
                        Console.WriteLine("\n Поле \"Название улицы\" не может быть пустой строкой");

                        continue;
                    }
                    else
                    {
                        newPerson.StreetName = tempStreetName;

                        break;
                    }
                }

                while (true)
                {
                    Console.WriteLine("\n Введите номер дома");

                    string tempNumberHouse = Console.ReadLine();

                    if (Int32.TryParse(tempNumberHouse, out int tempNumHouse))
                    {
                        newPerson.HouseNumber = tempNumHouse;

                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n Вы ввели не число");

                        continue;
                    }
                }

                while (true)
                {
                    Console.WriteLine("\n Введите номер квартиры");

                    string tempNumberFlat = Console.ReadLine();

                    if (Int32.TryParse(tempNumberFlat, out int tempNumFlat))
                    {
                        newPerson.FlatNumber = tempNumFlat;

                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n Вы ввели не число");

                        continue;
                    }
                }

                while (true)
                {
                    Console.WriteLine("\n Введите номер мобильного телефона(от 5 до 11 цифр)");

                    string tempMobileNumber = Console.ReadLine();

                    if (long.TryParse(tempMobileNumber, out long tempMobNumber) && (tempMobNumber > 9999 && tempMobNumber < 100000000000))
                    {
                        newPerson.MobilePhoneNumber = tempMobNumber;

                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n Вы ввели не число или неверный формат");

                        continue;
                    }
                }

                while (true)
                {
                    Console.WriteLine("\n Введите номер домашнего телефона(от 5 до 7 цифр)");

                    string tempFlatPhoneNumber = Console.ReadLine();

                    if (long.TryParse(tempFlatPhoneNumber, out long tempFlatPhoneNumb) && (tempFlatPhoneNumb > 9999 && tempFlatPhoneNumb < 10000000))
                    {
                        newPerson.FlatPhoneNumber = tempFlatPhoneNumb;

                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n Вы ввели не число или неверный формат");

                        continue;
                    }
                }

                listPerson.Add(newPerson);

                Console.WriteLine("\n Продолжить ввод данных? : y/n");

                char key = Console.ReadKey().KeyChar;

                if (key == 'y')
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            while (true);

            return listPerson;
        }

        static void SaveToXmlFile(List<Person> listPerson, string path)
        {
            XElement persons;

            if (listPerson.Count <= 0)
            {
                Console.WriteLine("\n Контакты не заполнены");

                InputData();
            }
            else
            {
                if (File.Exists(path))
                {
                    XDocument xDoc = XDocument.Load(path);

                    XElement child = xDoc.Descendants("Person").First();

                    persons = child.Parent;
                }
                else
                {
                    persons = new XElement("Persons");
                }

                for (int i = 0; i < listPerson.Count; i++)
                {
                    XElement person = new XElement("Person");

                    XAttribute personAttribute = new XAttribute("name", listPerson[i].FullName);

                    person.Add(personAttribute);

                    XElement street = new XElement("Street", listPerson[i].StreetName);

                    XElement houseNumber = new XElement("HouseNumber", listPerson[i].HouseNumber);

                    XElement flatNumber = new XElement("HouseFlat", listPerson[i].FlatNumber);

                    XElement address = new XElement("Address");

                    address.Add(street, houseNumber, flatNumber);

                    XElement mobilePhone = new XElement("MobilePhone", listPerson[i].MobilePhoneNumber);

                    XElement flatPhone = new XElement("FlatPhone", listPerson[i].FlatPhoneNumber);

                    XElement phones = new XElement("Phones");

                    phones.Add(mobilePhone, flatPhone);

                    person.Add(address, phones);

                    persons.Add(person);
                }

                persons.Save(path);
            }

           Console.WriteLine("\n Записи сохранены в файл");
        }

        //static void SerializePersons(XElement xElement, string path)
        //{
        //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(XElement));

        //    Stream fs = new FileStream(path, FileMode.Append, FileAccess.Write);

        //    xmlSerializer.Serialize(fs, xElement);

        //    fs.Close();
        //}

        //static XElement DeserializePersons(string path)
        //{
        //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(XElement));

        //    Stream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

        //    XElement xElement = xmlSerializer.Deserialize(fs) as XElement;

        //    fs.Close();

        //    return xElement;
        //}

        static void Main(string[] args)
        {
            Console.WriteLine("\n Программа - \"Записная книжка\"");

            string path = @"Persons.xml";

            SaveToXmlFile(InputData(), path);

            Console.ReadLine();
        }
    }
}
