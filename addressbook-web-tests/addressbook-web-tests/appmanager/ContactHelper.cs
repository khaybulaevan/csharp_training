using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
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

        public ContactHelper Modify(ContactData contact, ContactData modifyData)
        {
            SelectContactToModify(contact.Id);
            SelectContact(0);
            FillContactForm(modifyData);
            SubmitContactModification();
            ReturnHomePage();
            return this;
        }

        public ContactHelper Remove(int p)

        {
             SelectContactToDelete(0);
             RemoveContact();
             return this;
        }

        public ContactHelper Remove(ContactData contact)
        {
            SelectContact(contact.Id);
            RemoveContact();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Enter']")).Click();
            contactCache = null;
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

        public ContactHelper SelectContactToModify(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value = '" + id + "'])")).Click();
            return this;
        }



        public ContactHelper SelectContactToDelete(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        private ContactHelper SelectContact(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value = '"+id+"'])")).Click();
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
            contactCache = null;
            return this;
        }

        
        public ContactHelper InitDeteilsInformations(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Details'])[" + (index + 1) + "]")).Click();
            return this;
        }


        public ContactHelper  SubmitContactModification()
        {
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            contactCache = null;
            return this;
        }
        private List<ContactData> contactCache = null;
        public  List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                List<ContactData> contacts = new List<ContactData>();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));

                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    contactCache.Add(new ContactData(cells[2].Text, cells[1].Text));
                }
            }
            return new List<ContactData>(contactCache);
        }

        public ContactData GetContacInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastname = cells[1].Text;
            string firstname = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstname, lastname)
            {
                Address = address,
                AllPhones = allPhones
 
            };


        }

        public ContactData GetContacInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(0);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactData(firstname, lastname)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone
            };

        }
        public int GetNumberOfSearshResults()
        {
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m= new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);

        }

       public string  GetContacInformationFromDetails(int index)
        {
            manager.Navigator.OpenHomePage();
            InitDeteilsInformations(index);
            string contentDetails = driver.FindElement(By.Id("content")).Text;
            return contentDetails;


        }
    }

}
