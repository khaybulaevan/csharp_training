using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {


        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Ivan", "Inamov");
            newData.Address = "Moscow";
            app.Contacts.Modify(newData);
            
        }

    }
}