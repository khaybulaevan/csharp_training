using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;
using NUnit.Framework;



namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {



        [Test]
        public void GroupRemovalTest()
        {
            GroupData group = new GroupData("ccc");
            group.Header = "qqq";
            group.Footer = "www";
            app.Groups.Remove(1, group);
        }
    }
}
