using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public ContactHelper Modify(ContactData contact)
        {
            
            SelectContact(0);
            FillContactForm(contact);
            SubmitContactModification();
            ReturnHomePage();
            return this;
        }

        public ContactHelper Remove()

        {
             SelectContactToDelete(0);
             RemoveContact();
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

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index+1) + "]")).Click();
            return this;
        }

        public ContactHelper SelectContactToDelete(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public bool ChekContactForSelect()

        {
            if (IsElementPresent(By.XPath("//img[@alt='Edit']")))
                return true;
            return false;
        }

        public ContactHelper RemoveContact()

        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;

        }


        public ContactHelper  SubmitContactModification()
        {

            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            return this;
        }

        public  List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));

            foreach (IWebElement element in elements)
            {
                string[] contactsFL = element.Text.Split(new char[] { ' ' });
                contacts.Add(new ContactData(contactsFL[1], contactsFL[0]));
            }

            return contacts;
        }
    }

}
