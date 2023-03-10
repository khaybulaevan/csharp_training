using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {

        [Test]
        public void ContactModificationTest()
        {
            int i = 0;
            ContactData newData = new ContactData("Ivan", "Inamov");
            ContactData modifData = new ContactData("Petr", "Petrov");

            if (!app.Contacts.ChekContactForSelect())
            {
                app.Contacts.Create(newData);

            }
           List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(modifData);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[i].Firstname = modifData.Firstname;
            oldContacts[i].Lastname = modifData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }

    }
};