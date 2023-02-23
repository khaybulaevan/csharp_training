using OpenQA.Selenium.DevTools.V107.Network;
using System.Security.Cryptography;
using System;
using Microsoft.VisualStudio.TestPlatform;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Square s1 = new Square(5);
            Square s2 = new Square(10);
            Square s3 = s1;


            Assert.AreEqual(s1.getSize(), 5);
            Assert.AreEqual(s2.getSize(), 10);
            Assert.AreEqual(s3.getSize(), 5);

            s3.setSize(15);
            Assert.AreEqual(s1.getSize(), 15);
        }
    }
}