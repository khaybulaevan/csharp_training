using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;
using NUnit.Framework;



namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {



        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;
            app.Groups.Modify(1, newData);

        }
    }
}
