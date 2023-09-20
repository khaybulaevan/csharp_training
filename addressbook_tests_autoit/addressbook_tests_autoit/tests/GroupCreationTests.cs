using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupCreationTests : TestBase 
    {
        [Test]
        public void TestGroupCreation()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData group = new GroupData()
            {
                Name = "nur"
            };

            app.Groups.Add(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
