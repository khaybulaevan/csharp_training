﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public  class SearchTest : AuthTestBase
    {
        [Test]
        public void TestSearsh()
        {
            System.Console.Out.Write(app.Contacts.GetNumberOfSearshResults());
        }
    }
}
