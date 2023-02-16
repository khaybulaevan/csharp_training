﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        public LoginHelper(IWebDriver driver) 
            : base(driver)
        {

        }

        // Login принимает один параметр типа AccountData
        public void Login(AccountData account)
        {
            driver.FindElement(By.Name("user")).Clear();
            // Будут вводиться в поля значения свойств этого объекта
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

    }
}