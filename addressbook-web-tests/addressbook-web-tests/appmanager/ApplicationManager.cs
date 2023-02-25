using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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

        // Специальный объект, который будут устанавливать соотвествие между текущим потоком и объетом типа ApplicationManager
        private static ThreadLocal<ApplicationManager> app  = new ThreadLocal<ApplicationManager>();

        // Инициализация
        private ApplicationManager()

        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/addressbook";


            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);

        }

        // Создаем деструктор
        ~ApplicationManager()
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



       
        // Глобальный метод, который может быть вызван не в конкретном объекте, а по его имени
        public static ApplicationManager GetInstance()

        {
            // Для текущего потока внутри этого хранилища ничего пока еще ничего не созданано  - нужно создать
            if (! app.IsValueCreated)
            {
                app.Value = new ApplicationManager();
            }
            // Если уже создано - ничего не делать
            return app.Value;
        }


        public IWebDriver Driver
        {
            get 
            {
                return driver;            
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
