using System;
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
            contact.Lastname = "Mukh";
            app.Contacts.Remove(contact);
            
        }

    }
}