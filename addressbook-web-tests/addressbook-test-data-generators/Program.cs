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
            // count - Количево тетсовых данных, которыу хотим сгенерировать
            int count = Convert.ToInt32(args[0]);
            string filename = args[1];
            string format = args[2];

            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });
            }
            if (format == "excel")
            {
                writeGroupsToExcelFile(groups, filename);
            }
            else
            {
                StreamWriter writer = new StreamWriter(filename);
                if (format == "csv")
                {
                    writeGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    writeGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    writeGroupsToJsonFile(groups, writer);
                }

                else
                {
                    System.Console.Out.Write("Unrecognized format" + format);
                }
                writer.Close();

            }

        }

        static void writeGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            // Visible дает возможность наблюдать за тем, что просиходит в окне приложения
            app.Visible = true;
            // Создается одна страницв при создании нового документа Workbook
            Excel.Workbook wb =  app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;


            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }

            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);

            wb.Close();
            app.Visible = false;
            app.Quit();

        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2})",
                    group.Name, group.Header, group.Footer));
            }
        
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