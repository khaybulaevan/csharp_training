using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {



        [Test]
        public void GroupModificationTest()
        {
            app.Groups.Modify(1);

        }
    }
}
