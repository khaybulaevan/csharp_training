using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {


        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToContactsPage();
            ContactData contact = new ContactData("Lev", "Tolstoy");
            contact.Lastname = "Nikolaevish";
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnHomePage();
        }

    }
}