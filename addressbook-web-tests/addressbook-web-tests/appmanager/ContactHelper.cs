using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
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

        public ContactHelper Modify( ContactData newData)
        {
            SelectContactToModify();
            ContactModify(newData);
            SubmitContactModification();
            ReturnHomePage();
            return this;

        }


        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middleame);
            Type(By.Name("lastname"), contact.Lastname);
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


        public ContactHelper SelectContactToModify()

        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }


        public ContactHelper ContactModify(ContactData newData)

        {
            Type(By.Name("address"), newData.Address);
            return this;
        }

        public ContactHelper  SubmitContactModification()
        {

            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            return this;
        }

    }

}
