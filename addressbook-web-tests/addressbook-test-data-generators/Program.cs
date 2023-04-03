using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using WebAddressbookTests;
using System.Xml;
using System.Xml.Serialization;
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;


namespace addressbook_test_data_generators

{
    class Program

    {
        static void Main(string[] args)
        {
            // count - количество тетсовых данных, которые хотим сгенерировать
            string datatype = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];

            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });
            }
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                {
                    Address = TestBase.GenerateRandomString(10)
                });
                    
            }

            {
                StreamWriter writer = new StreamWriter(filename);
                if (format == "xml" && datatype == "groups")
                {
                    writeGroupsToXmlFile(groups, writer);
                }
                else if (format == "xml" && datatype == "contacts")
                {
                    writeContactsToXmlFile(contacts, writer);
                }
                else if (format == "json" && datatype == "groups")
                {
                    writeGroupsToJsonFile(groups, writer);
                }
                else if (format == "json" && datatype == "contacts")
                {
                    writeContactsToJsonFile(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format" + format);
                }
                writer.Close();

            }

        }

        static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)

        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)

        {
            writer.Write(JsonConvert.SerializeObject(groups,  Newtonsoft.Json.Formatting.Indented));

        }

    }


}