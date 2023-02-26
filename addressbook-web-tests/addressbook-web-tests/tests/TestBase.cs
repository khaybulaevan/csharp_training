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
        public void SetupApplicationManager()
        {

            
            // Инициализируем ApplicationManager
            app = ApplicationManager.GetInstance();

        }


    }
}
