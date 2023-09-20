using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_autoit

{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void TestGroupRemoval() 
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            if (oldGroups.Count() == 1)
            {
                GroupData group = new GroupData()
                {
                    Name = "nur"
                };
                app.Groups.Add(group);
                oldGroups = app.Groups.GetGroupList();
            }

            //GroupData toBeRemoved = oldGroups[0];            
            app.Groups.Remove();
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Sort();
            newGroups.Sort();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);


        }
    }
}
