using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Linq;

namespace NoteBook
{
    class Program
    {
        static void InputData(string path)
        {
            Console.WriteLine("\n Введите данные о контакте");

            XElement persons;

            XElement person;

            do
            {
                person = new XElement("Person");

                while (true)
                {
                    Console.WriteLine("\n Введите Ф.И.О.");

                    string fullName = Console.ReadLine();

                    if (String.IsNullOrEmpty(fullName) || String.IsNullOrWhiteSpace(fullName))
                    {
                        Console.WriteLine("\n Поле \"Ф.И.О.\" не может быть пустой строкой");

                        continue;
                    }
                    else
                    {
                        XAttribute personAttribute = new XAttribute("name", fullName);

                        person.Add(personAttribute);

                        break;
                    }
                }

                XElement street;

                while (true)
                {
                    Console.WriteLine("\n Введите название улицы");

                    string streetName = Console.ReadLine();

                    if (String.IsNullOrEmpty(streetName) || String.IsNullOrWhiteSpace(streetName))
                    {
                        Console.WriteLine("\n Поле \"Название улицы\" не может быть пустой строкой");

                        continue;
                    }
                    else
                    {
                        street = new XElement("Street", streetName);

                        break;
                    }
                }

                XElement houseNumber;

                while (true)
                {
                    Console.WriteLine("\n Введите номер дома");

                    string numberHouse = Console.ReadLine();

                    if (Int32.TryParse(numberHouse, out int numHouse))
                    {
                        houseNumber = new XElement("HouseNumber", numberHouse);

                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n Вы ввели не число");

                        continue;
                    }
                }

                XElement flatNumber;

                while (true)
                {
                    Console.WriteLine("\n Введите номер квартиры");

                    string numberFlat = Console.ReadLine();

                    if (Int32.TryParse(numberFlat, out int numFlat))
                    {
                        flatNumber = new XElement("HouseFlat", numberFlat);

                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n Вы ввели не число");

                        continue;
                    }
                }

                XElement address = new XElement("Address");

                address.Add(street, houseNumber, flatNumber);

                XElement mobilePhone;

                while (true)
                {
                    Console.WriteLine("\n Введите номер мобильного телефона(от 5 до 11 цифр)");

                    string mobileNumber = Console.ReadLine();

                    if (long.TryParse(mobileNumber, out long numberPhone) && (numberPhone > 9999 && numberPhone < 100000000000))
                    {
                        mobilePhone = new XElement("MobilePhone", mobileNumber);

                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n Вы ввели не число или неверный формат");

                        continue;
                    }
                }

                XElement flatPhone;

                while (true)
                {
                    Console.WriteLine("\n Введите номер домашнего телефона(от 5 до 7 цифр)");

                    string flatPhoneNumber = Console.ReadLine();

                    if (long.TryParse(flatPhoneNumber, out long numberPhone) && (numberPhone > 9999 && numberPhone < 10000000))
                    {
                        flatPhone = new XElement("FlatPhone", flatPhoneNumber);

                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n Вы ввели не число или неверный формат");

                        continue;
                    }
                }
                XElement phones = new XElement("Phones");

                phones.Add(mobilePhone, flatPhone);

                person.Add(address, phones);

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

            if (File.Exists(path))
            {
                XDocument xDoc = XDocument.Load(path);

                XElement child = xDoc.Descendants("Person").First();

                persons = child.Parent;               

                persons.Add(person);

                persons.Save(path);
            }
            else
            {
                persons = new XElement("Persons");

                persons.Add(person);

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

            InputData(path);

            Console.ReadLine();
        }
    }
}
