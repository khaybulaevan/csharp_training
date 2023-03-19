using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public  class ContactDetailsInformationTests : AuthTestBase
    {
        [Test]
        public void ContactDetailsInformationTest()
        {
            ContactData fromForm = app.Contacts.GetContacInformationFromEditForm(0);
            string fromDetails = app.Contacts.GetContacInformationFromDetails(0);


            string allDatailFromForm = fromForm.AllDetails; 
            
            Assert.AreEqual(allDatailFromForm, fromDetails);
        }
    }
}
