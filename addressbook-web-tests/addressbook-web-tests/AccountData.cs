using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class AccountData
    {

        private string username;
        private string password;

        // Коснтруктор, чтобы конструировать объект в одну строчку. Коструировать новые объекты
        public AccountData(string username, string password)
        {
            // в поле присваиваем значение, которое передано в качестве параметра
            this.username = username;
            this.password = password;
        }

        public string Username
        {
            // get и set позволяют менять значения свойст объекта, когда это понадобится 
            get
            {
                return username;
            }
            set
            {
                username = value;
            }

        }
        public string Password
        {
            get
            {
                return password;          
            }
            set
            {
                password = value;
            }

}

}

     }
