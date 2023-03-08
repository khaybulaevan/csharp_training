using OpenQA.Selenium.DevTools.V107.Network;
using System.Security.Cryptography;
using System;
using Microsoft.VisualStudio.TestPlatform;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class UnitTest2
    {

        [Test]
        public void TestMethod2()
        {
            IWebDriver driver = null;
            int attempt = 0;

            do

            {
                System.Threading.Thread.Sleep(1000);
                attempt++;

            } while (driver.FindElements(By.Id("test")).Count == 0 && attempt < 60);

            //..
        }

        // Самый примитивный представитель множестава объектов - массив
        //string[] s = new string[] { "I", "want", "to", "be", "better" };
         //  foreach (string elemebt in s)
           // {
             //   System.Console.Out.Write(elemebt + "\n");
            //}
}
}
