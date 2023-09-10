using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class AddressBookDb : LinqToDB.Data.DataConnection

    {
        public AddressBookDb() : base(ProviderName.MySql, @"server=localhost; database=addressbook; port=3306; Uid=root; Pwd=; charset=utf8; Allow Zero Datetime=true") { }
        // Собираемся из базы данных извлекать информацию о группах и контактах из таблицы,
        // привязка которая описана в классе GroupData и ContactData
        public ITable<GroupData> Groups { get { return this.GetTable<GroupData>(); } }
        public ITable<ContactData> Contacts { get { return this.GetTable<ContactData>();} }


    }
}
