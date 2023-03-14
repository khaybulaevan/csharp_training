using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {


        public ContactData(string firstname, string lastname)

        {
            Firstname = firstname;
            Lastname = lastname;
        }
        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname
                && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return (Firstname + Lastname).GetHashCode();
        }

        public override string ToString()
        {
            return Firstname + Lastname;
        }


        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            int compareResult = Lastname.CompareTo(other.Lastname);

            if (compareResult == 0)
            {
                return Lastname.CompareTo(other.Firstname);
            }
            return compareResult;
        }

        public string Firstname { get; set; }

        public string Middleame { get; set; }

        public string Lastname { get; set; }

        public string Nikname { get; set; }

        public string Photo { get; set; }

        public string Company { get; set; }

        public string Title { get; set; }

        public string Address { get; set; }

        public string Home { get; set; }

        public string Mobile { get; set; }

        public string Work { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Homepage { get; set; }

        public int? Bday { get; set; }

        public string Bmonth { get; set; }

        public int? Byear { get; set; }

        public int? Aday { get; set; }

        public string Amonth { get; set; }

        public string New_group { get; set; }

    }
}


  


