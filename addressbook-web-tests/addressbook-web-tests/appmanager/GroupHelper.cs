using System;
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

        public GroupHelper Modify( GroupData group)
        {

            SelectGroup(1);
            InitGroupModification();
            FillGroupForm(group);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
           
        }

        public GroupHelper Remove()
        {
            SelectGroup(1);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
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
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + (index + 1) + "]/input")).Click();
            return this;
        }

        public bool ChekGroupForSelect()

        {
            if (IsElementPresent(By.CssSelector("[name='selected[]'")))
                return true;
            return false;
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

        public  List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigator.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
             {
        
                groups.Add(new GroupData(element.Text));

             }

            return groups;
           
        }
    }
}
