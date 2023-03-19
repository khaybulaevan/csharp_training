using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {
       //private IWebDriver driver;
        public LoginHelper(ApplicationManager manager) 
            : base(manager)
        {

        }

        // Login принимает один параметр типа AccountData
        public void Login(AccountData account)

        {
            if (IsLoggedIn())

            {   if (IsLoggedIn(account))

                {
                    return;
                }

                Logout();
            }
            // Будут вводиться в поля значения свойств этого объекта
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }


        public void Logout()
        {
            if (IsLoggedIn())
            { 
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }

        public bool IsLoggedIn()

        {
            return IsElementPresent(By.Name("logout"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggetUserName() == account.Username;

        }

        public  string GetLoggetUserName()
        {
            string text =  driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            // Substring режит кусочек. Принимае два параметра: начало (индексация начинается с 0) и сколько символов нужно извлечь
            return text.Substring(1, text.Length - 2);

        }
    }
}
