using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public  class LoginTests :TestBase
    {
        [Test]
        public void LoginWithValidCredention()

        {
            // Подготовка
            app.Auth.Logout();

            // Действие
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);

            // Проверка
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
            
        }

        [Test]
        public void LoginWithInvalidCredention()

        {
            // Подготовка
            app.Auth.Logout();

            // Действие
            AccountData account = new AccountData("admin", "12345");
            app.Auth.Login(account);

            // Проверка
            Assert.IsFalse(app.Auth.IsLoggedIn(account));

        }
    }
}
