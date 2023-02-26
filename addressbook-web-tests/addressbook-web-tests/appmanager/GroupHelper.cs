﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager) 
            : base(manager)
        {
        }

        public GroupHelper Create (GroupData group)
        {
            // Navigator обращается к manager
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }


        public GroupHelper Remove(int p, GroupData group)
        {
            // Navigator обращается к manager
            manager.Navigator.GoToGroupsPage();
            if (IsElementPresent(By.Name("selected[]")))
            {

                SelectGroup(1);
                RemoveGroup();
                ReturnToGroupsPage();
                return this;
            }

            else

            {
                InitGroupCreation();
                FillGroupForm(group);
                SubmitGroupCreation();
                ReturnToGroupsPage();
                return this;

            }
        }

        public GroupHelper Modify( int p, GroupData newData)
        {
         manager.Navigator.GoToGroupsPage();

            if (IsElementPresent(By.Name("selected[]")))
                //(IsElementPresent(By.CssSelector("[name='checkbox']")))
            { 
                SelectGroup(1);
                InitGroupModification();
                FillGroupForm(newData);
                SubmitGroupModification();
                ReturnToGroupsPage();
                return this;
            }
            else
            {
                InitGroupCreation();
                FillGroupForm(newData);
                SubmitGroupCreation();
                ReturnToGroupsPage();
                return this;

            }

        }

        // Чтобы умееньшить дублирование кода в тесте (GroupCreationTests) делаем так,
        // чтомы методы в GroupHelper возвращал тот же самый GroupHelper
        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            
            // Передаем информацию не как набор полей, а как объект
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;

        }

        public GroupHelper SubmitGroupCreation()

        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }


        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)

        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
            return this;
        }


        public GroupHelper RemoveGroup()

        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()

        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

    }
}
