using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace WebAddressbookTests;

public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
{
    private string allPhones;
    private string allDetails;
    private string fio;

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
        return "Firstname" +  Firstname + "\nLastname" + Lastname + "\nMiddlename" + Middlename;
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

    public string Middlename { get; set; }

    public string Lastname { get; set; }

    public string Nikname { get; set; }

    public string Photo { get; set; }

    public string Company { get; set; }

    public string Title { get; set; }

    public string Address { get; set; }

    public string HomePhone { get; set; }

    public string MobilePhone { get; set; }

    public string WorkPhone { get; set; }

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


    public string FIO
    {
        get
        {
            if (fio != null)
            {
                return fio;
            }

            else
            {
                return (AddCaret(Firstname) + AddCaret(Lastname) + AddCaret(Middlename).Trim());
            }
        
        }

        set
        {
            fio = value;
        }
    }

    public string AllPhones
    {

        get
        {

            if (allPhones != null)
            {
                return allPhones;
            }
            else
            {
                return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
            }
        }

        set
        {
            allPhones = value;
        }
    }


     public string AllDetails

      {
          get
          {
              if (AllDetails != null)
              {
                  return AllDetails;
              }
              else
              {
                  return (AddCaret(FIO)
                          + AddCaret(Address)
                          + AddCaret(HomePhone)
                          + AddCaret(MobilePhone)
                          + AddCaret(WorkPhone).Trim());
              }
          }
          set
          {
              allDetails = value;
          }

      }
 
    public string CleanUp(string phone)
    {
        if (phone == null || phone == "")

        {
            return "";
        }
        return Regex.Replace(phone, "[() -]", "") + "\r\n";

    }

   
    private string AddCaret(string data)
    {
        if (data == null || data == "")
        {
            return "";
        }
        return data + "\r\n";
    }



}





