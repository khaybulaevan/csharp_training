using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebAddressbookTests;

namespace WebAddressbookTests
{
    public class TestBase
    {

        protected ApplicationManager app;


        [SetUp]
        // Метод для инициализации
        public void SetupTest()
        {

            // Инициализируем ApplicationManager
            app = new ApplicationManager();

        }



        [TearDown]
        // Метод, который останавливает драйвер в конце
        public void TeardownTest()
        {
            app.Stop();

        }



    }
}
