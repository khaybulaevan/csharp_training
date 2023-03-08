using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;
using NUnit.Framework;
using System.Collections.Generic;



namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {



        [Test]
        public void GroupRemovalTest()

        {
            GroupData newdata = new GroupData("ccc");
            newdata.Header = "qqq";
            newdata.Footer = "www";

            if (!app.Groups.ChekGroupForSelect())

            {
                app.Groups
                .InitGroupCreation()
                .FillGroupForm(newdata)
                .SubmitGroupCreation()
                .ReturnToGroupsPage();
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups
            .SelectGroup(0)
            .RemoveGroup()
            .ReturnToGroupsPage();

            //app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            // Удаление первого элемента в списке
            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
