using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(20), GenerateRandomString(20))
                {
                    Middlename = GenerateRandomString(20)
                });
        }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)
                 new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contacts.xml"));

        }

        public static IEnumerable<ContactData> ContactDataFronJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));
        }


        [Test, TestCaseSource("ContactDataFronJsonFile")]
        public void ContactCreationTest(ContactData contact)
        {

            List<ContactData> oldContacts = ContactData.GetAll();

            app.Contacts.Create(contact);

            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);


        }

        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<ContactData> fromUi = app.Contacts.GetContactList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            start = DateTime.Now;
            List<ContactData> fromDb = ContactData.GetAll();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

        }

    }
}