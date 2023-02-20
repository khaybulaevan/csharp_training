using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace WebAddressbookTests
{
    public class HelperBase
    {

        protected IWebDriver driver;
        protected ApplicationManager manager;

        // на вход принимает ссылку на драйвер, через которую мы управляем браузером и присваиват ее в поле
        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            // HelperBase получает ссылку на драйвер у менеджера и далее этой ссылкой все могут пользоваться
            driver = manager.Driver;
        }
    }
}