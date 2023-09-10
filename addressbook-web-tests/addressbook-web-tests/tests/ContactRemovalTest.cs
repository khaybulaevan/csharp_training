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
                app.Contacts.Create(contact);
            }

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];

            app.Contacts.Remove(toBeRemoved);
            System.Threading.Thread.Sleep(100);
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts); 
         }

    }
}