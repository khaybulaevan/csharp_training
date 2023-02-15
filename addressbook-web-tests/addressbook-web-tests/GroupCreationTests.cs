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
            OpenHomePage();
            // Передаем не два значения вместе, а один объект
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitGroupCreation();
            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "ccc";
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();

        }

        }
    }

