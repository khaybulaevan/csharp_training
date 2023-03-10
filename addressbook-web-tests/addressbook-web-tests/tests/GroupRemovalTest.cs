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
            GroupData newData = new GroupData("ccc");
            newData.Header = "qqq";
            newData.Footer = "www";

            if (!app.Groups.ChekGroupForSelect())

            {
                app.Groups.Create(newData);
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove();

            //app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            // Удаление первого элемента в списке
            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
