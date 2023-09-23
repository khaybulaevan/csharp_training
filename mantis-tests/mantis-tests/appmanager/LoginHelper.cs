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

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) 
            : base(manager)
        {

        }
        public void Login(AccountData account)

        {
            if (IsLoggedIn())

            {   if (IsLoggedIn(account))

                {
                    return;
                }

                Logout();
            }
            Type(By.Name("username"), account.Name);
            Type(By.Name("password"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Войти']")).Click();
        }


        public void Logout()
        {
            if (IsLoggedIn())
            { 
                driver.FindElement(By.XPath("//a[@id='logout-link']")).Click();
            }
        }

        public bool IsLoggedIn()

        {
           return IsElementPresent(By.XPath("//a[@id='logout-link']"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggetUserName() == account.Name;

        }

        public  string GetLoggetUserName()
        {
            string text = driver.FindElement(By.XPath("//span[@id='logged-in-user']")).Text;
            return text;

        }
    }
}
