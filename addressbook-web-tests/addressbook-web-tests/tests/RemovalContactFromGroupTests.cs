﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemovalContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovalContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();

            if (oldList.Count == 0)
            {
                app.Contacts.AddContactToGroup(ContactData.GetAll()[0], group);
            }
            ContactData contact = group.GetContacts()[0];

            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        
        }
    }
}
