
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    // Переносим в этот класс весь код относящийся к управлению помощниками
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected  string baseURL;


        // ссылки на вспомогательные методы
        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        // Инициализация
        public ApplicationManager()

        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/addressbook";


            loginHelper = new LoginHelper(driver);
            navigator = new NavigationHelper(driver, baseURL);
            groupHelper = new GroupHelper(driver);
            contactHelper = new ContactHelper(driver);

        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }



        // Добавляется свойство, чтобы не делать ссылки на вспомогательными методы public

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }

        }

        public NavigationHelper Navigator
        {
            get
            {
                return navigator;
            }

        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;


            }

        }

        public ContactHelper Contacts
        {
            get
            {
                return contactHelper;


            }

        }
    }
}
