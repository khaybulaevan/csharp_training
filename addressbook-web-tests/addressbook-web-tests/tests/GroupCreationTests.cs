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


        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> group = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                group.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
    
            return group;
        }


        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTest(GroupData group)
        {
  
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            // Операция быстро будет возвращать количестов групп 
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            // List - класс, контейнер или  колекция, то есть объект, который хранит набор других объктов
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            // Приводим к кононическому виду
            oldGroups.Sort();
            newGroups.Sort();
            // Сравнение отсортированными списки 
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

