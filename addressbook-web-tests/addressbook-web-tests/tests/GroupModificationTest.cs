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
    public class GroupModificationTests : GroupTestBase
    {



        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;
            GroupData modifData = new GroupData("ppp");
            modifData.Header = null;
            modifData.Footer = null;

            app.Navigator.GoToGroupsPage();

            if (!app.Groups.ChekGroupForSelect())
            {

                app.Groups.Create(newData);
            }
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData groupToModif = oldGroups[0];

            app.Groups.Modify(groupToModif, modifData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = modifData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == groupToModif.Id)
                {
                   Assert.AreEqual( modifData.Name, group.Name);
                }
            }

        }
    }
}
