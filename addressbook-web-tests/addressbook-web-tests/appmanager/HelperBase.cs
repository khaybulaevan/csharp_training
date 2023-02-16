using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class HelperBase
    {

        protected IWebDriver driver;

        // на вход принимает ссылку на драйвер, через которую мы управляем браузером и присваиват ее в поле
        public HelperBase(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}