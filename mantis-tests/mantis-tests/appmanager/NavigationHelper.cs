﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace mantis_tests
{
    public class NavigationHelper : HelperBase
    {
        public string baseURL;
        public NavigationHelper(ApplicationManager manager, string baseURL)
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToControlMainPage()
        {
            driver.FindElement(By.XPath("//a[@class='manage-menu-link']")).Click();
        }
        public void GoToProjectControlPage()
        {
            driver.FindElement(By.XPath("//a[@href='/mantisbt-1.3.20/manage_proj_page.php']")).Click();
        }

    }
}