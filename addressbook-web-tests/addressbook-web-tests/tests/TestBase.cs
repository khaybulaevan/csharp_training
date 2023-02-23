using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


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
            app.Navigator.OpenHomePage();
            // Передаем не два значения вместе, а один объект
            app.Auth.Login(new AccountData("admin", "secret"));

        }

        [TearDown]
        // Метод, который останавливает драйвер в конце
        public void TeardownTest()
        {
            app.Stop();

        }



    }
}
