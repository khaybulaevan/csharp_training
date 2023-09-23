using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.IdentityModel.Logging;
using NUnit.Framework.Constraints;

namespace mantis_tests
{
    // Переносим в этот класс весь код относящийся к управлению помощниками
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected  string baseURL;
        public RegisrtationHelper Registration { get; }
        public FtpHelper Ftp { get; set; }
        public ProjectHelper projectHelper;
        public NavigationHelper navigator;
        private LoginHelper loginHelper;


        // Специальный объект, который будут устанавливать соотвествие между текущим потоком и объетом типа ApplicationManager
        private static ThreadLocal<ApplicationManager> app  = new ThreadLocal<ApplicationManager>();

        // Инициализация
        private ApplicationManager()

        {
            driver = new EdgeDriver();
            baseURL = "http://localhost/mantisbt-1.3.20/login_page.php";
            Registration = new RegisrtationHelper(this);
            Ftp = new FtpHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            projectHelper = new ProjectHelper(this);
            loginHelper = new LoginHelper(this);

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
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt-1.3.20/login_page.php";
                // Присваиваем новый созданный объект в хранилиже ThreadLocal
                app.Value = newInstance;
                

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

        public ProjectHelper Projects
        {
            get {
                return projectHelper;
            }
        }

        public NavigationHelper Navigator
        {
            get
            {
                return navigator;
            }

        }
        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }

        }

    }
}
