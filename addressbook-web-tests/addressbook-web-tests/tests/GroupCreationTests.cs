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
    public class GroupCreationTests : TestBase
    {



        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "ccc";

            app.Groups.Create(group);

        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);
        }
        }
}

