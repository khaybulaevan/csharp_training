using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {


        [Test]
        public void ContactRemovalTest()
        {

            ContactData contact = new ContactData("Naida", "Khaybulaeva");

            if (!app.Contacts.ChekContactForSelect())
            {

                app.Navigator.GoToContactsPage();
                app.Contacts
                    .FillContactForm(contact)
                    .SubmitContactCreation()
                    .ReturnHomePage();
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts
                .SelectContactToDelete(0)
                .RemoveContact();

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts);

        }

    }
}