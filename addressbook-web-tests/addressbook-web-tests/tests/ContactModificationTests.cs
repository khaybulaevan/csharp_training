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

            //app.Navigator.GoToContactsPage();

            //app.Contacts.Modify(newData);

            if (!app.Contacts.ChekContactForSelect())
            {
                //app.Navigator.GoToContactsPage();

                app.Navigator.GoToContactsPage();
                app.Contacts
                    .FillContactForm(newData)
                    .SubmitContactCreation()
                    .ReturnHomePage();
            }
           List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts
               .SelectContact(0)
               .FillContactForm(modifData)
               .SubmitContactModification()
               .ReturnHomePage();

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[i].Firstname = modifData.Firstname;
            oldContacts[i].Lastname = modifData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }

    }
};