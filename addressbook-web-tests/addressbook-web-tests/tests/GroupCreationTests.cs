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
    public class GroupCreationTests : AuthTestBase
    {



        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "ccc";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            // ???????? ?????? ????? ?????????? ?????????? ????? 
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            // List - ?????, ????????? ???  ????????, ?? ???? ??????, ??????? ?????? ????? ?????? ???????
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            // ???????? ? ????????????? ????
            oldGroups.Sort();
            newGroups.Sort();
            // ????????? ???????????????? ?????? 
            Assert.AreEqual(oldGroups, newGroups);

        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());


            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

