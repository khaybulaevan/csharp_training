using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    // Базовый класс для тестов, кторые требуеют входа в систему
    public  class AuthTestBase : TestBase
    {

        [SetUp]
        // Метод для инициализации
        public void SetupLogin()
        {
            app.Auth.Login(new AccountData("admin", "secret"));

        }
    }
}
