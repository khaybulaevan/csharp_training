using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) 
            : base(manager)
        {
        
        }

        public ContactHelper Create(ContactData contact)
         {
            manager.Navigator.GoToContactsPage();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnHomePage();
            return this;

        }

        public ContactHelper Remove()
        {
            SelectContact();
            RemoveContact();
            return this;

        }

        public ContactHelper Modify()
        {
            SelectContactToModify();
            ContactModify();
            ReturnHomePage();
            return this;

        }


        public ContactHelper FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.Middleame);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            return this;

        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Enter']")).Click();
            return this;
        }
        public ContactHelper ReturnHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public ContactHelper SelectContact()

        {
           driver.FindElement(By.XPath("//div[4]/form[2]/table/tbody/tr[2]/td[1]/input")).Click();
            return this;
        }

        public ContactHelper RemoveContact()

        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;

        }


        private ContactHelper SelectContactToModify()

        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }


        private ContactHelper ContactModify()

        {

            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys("Moscow");
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            return this;
        }
    }

}
