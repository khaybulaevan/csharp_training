using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData
    {
        private string firstname;
        private string middlename;
        // Значения по умолчанию - пусто
        private string lastname = "";
        private string nickname = "";
        private string photo = "";
        private string company = "";
        private string title = "";
        private string address = "";
        private string home = "";
        private string mobile = "";
        private string work = "";
        private string fax = "";
        private string email = "";
        private string email2 = ""; 
        private string email3 = "";
        private string homepage = "";
        private int? bday = null;
        private string bmonth = "";
        private int?  byear = null;
        private int?  aday = null;
        private string amonth = "";
        private string new_group = ""; 

        public ContactData(string firstname, string middlename)

        {
            this.firstname = firstname;
            this.middlename = middlename; 
        
        }


        public string Firstname

        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value; 
            }
             
            }
        public string Middleame

        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }

        }
        public string Lastname

        {
            get

            {
                return lastname;
            }

            set

            {
                lastname = value;
            }
        }

        public string Nikname

        {
            get

            {
                return nickname;
            }

            set

            {
                nickname = value;
            }
        }
        public string Photo

        {
            get

            {
                return photo;
            }

            set

            {
                photo = value;
            }
        }
        public string Company

        {
            get

            {
                return company;
            }

            set

            {
                company = value;
            }
        }

        public string Title

        {
            get

            {
                return title;
            }

            set

            {
                title = value;
            }
        }

        public string Address

        {
            get

            {
                return address;
            }

            set

            {
                address = value;
            }
        }
        public string Home

        {
            get

            {
                return home;
            }

            set

            {
                home = value;
            }
        }

        public string Mobile

        {
            get

            {
                return mobile;
            }

            set

            {
                mobile = value;
            }
        }

        public string Work

        {
            get

            {
                return work;
            }

            set

            {
                work = value;
            }
        }

        public string Fax

        {
            get

            {
                return fax;
            }

            set

            {
                fax = value;
            }
        }

        public string Email

        {
            get

            {
                return email;
            }

            set

            {
                email = value;
            }
        }

        public string Email2

        {
            get

            {
                return email2;
            }

            set

            {
                email2 = value;
            }
        }
        public string Email3

        {
            get

            {
                return email3;
            }

            set

            {
                email3 = value;
            }
        }
        public string Homepage

        {
            get

            {
                return homepage;
            }

            set

            {
                homepage = value;
            }
        }

        public int? Bday

        {
            get

            {
                return bday;
            }

            set

            {
                bday = value;
            }
        }

        public string Bmonth

        {
            get
            {
                return bmonth;
            }
            set
            {
                bmonth = value;
            }

         

        }

        public int? Byear

        {
            get
            {
                return byear;
            }
            set
            {
                byear = value;
            }



        }

        public int? Aday

        {
            get
            {
                return aday;
            }
            set
            {
                aday = value;
            }



        }
        public string  Amonth

        {
            get
            {
                return amonth;
            }
            set
            {
                amonth = value;
            }



        }


        public string New_group

        {
            get
            {
                return new_group;
            }
            set
            {
                new_group = value;
            }



        }
      

    }
}


