using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    // Атрибут SetUpFixture для того, чтобы браузер запускался один раз
    [SetUpFixture]
    public class TestSuiteFixture

    {
        // Передать информацию из Фиксутры в тесты - объявить переменную глобальной - static
        // Статическое поле общее для всех объектов данного класса
        // Когда один объект меняет значение этого поля, то другие объекты тоже работают с новым изменившимся значением этого поля
        // Дсотуп осуществляется не через объект, а на прямую

        [OneTimeSetUp]

        public void InitApplicationManager()
        {
            // Обращаемся к методу GetInstance - глобальному методу, то есть обращение без какого0либо объекта
            ApplicationManager app = ApplicationManager.GetInstance();
            app.Navigator.OpenHomePage();
            // Передаем не два значения вместе, а один объект
            app.Auth.Login(new AccountData("admin", "secret"));
        }

        // Приложение и браузер будут останавливаться только в самом конце, когда все тесты завершилилсь
        //[OneTimeTearDown]
        //public void StopApplicationmanager()

        //{
        //    ApplicationManager.GetInstance().Stop();
        //}

    }
}
