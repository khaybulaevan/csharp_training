using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {



        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;
            GroupData modifData = new GroupData("ppp");
            newData.Header = null;
            newData.Footer = null;

            app.Navigator.GoToGroupsPage();

            if (!app.Groups.ChekGroupForSelect())
            {

                app.Groups
                .InitGroupCreation()
                .FillGroupForm(newData)
                .SubmitGroupCreation()
               . ReturnToGroupsPage();

            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups
            .SelectGroup(0)
            .InitGroupModification()
            .FillGroupForm(modifData)
            .SubmitGroupModification()
            .ReturnToGroupsPage();

            //app.Groups.Modify(newData);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = modifData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
