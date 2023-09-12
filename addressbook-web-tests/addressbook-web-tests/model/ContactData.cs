using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;
using System.Text.RegularExpressions;

namespace WebAddressbookTests;

[Table(Name = "addressbook")]
public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
{
    private string allPhones;
    private string allDetails;
    private string fio;

    public ContactData()

    {
    }

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
        return "Firstname" + Firstname + "\n Lastname" + Lastname + "\n Middlename" + Middlename;
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
    [Column(Name = "firstname")]
    public string Firstname { get; set; }
    [Column(Name = "middlename")]
    public string Middlename { get; set; }
    [Column(Name = "lastname")]
    public string Lastname { get; set; }
    [Column(Name = "nickname")]
    public string Nikname { get; set; }
    [Column(Name = "photo")]
    public string Photo { get; set; }
    [Column(Name = "company")]
    public string Company { get; set; }
    [Column(Name = "title")]
    public string Title { get; set; }
    [Column(Name = "address")]
    public string Address { get; set; }
    [Column(Name = "home")]
    public string HomePhone { get; set; }
    [Column(Name = "mobile")]
    public string MobilePhone { get; set; }
    [Column(Name = "work")]
    public string WorkPhone { get; set; }
    [Column(Name = "fax")]
    public string Fax { get; set; }
    [Column(Name = "email")]
    public string Email { get; set; }
    [Column(Name = "email2")]
    public string Email2 { get; set; }
    [Column(Name = "email3")]
    public string Email3 { get; set; }
    [Column(Name = "homepage")]
    public string Homepage { get; set; }
    [Column(Name = "bday")]
    public int? Bday { get; set; }
    [Column(Name = "bmonth")]
    public string Bmonth { get; set; }
    [Column(Name = "byear")]
    public string Byear { get; set; }
    [Column(Name = "aday")]
    public int? Aday { get; set; }
    [Column(Name = "amonth")]
    public string Amonth { get; set; }
    public string New_group { get; set; }
    [Column(Name = "id"), PrimaryKey]
    public string Id { get; set; }

    [Column(Name ="deprecated")]
    public string Deprecated { get; set; }


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


    public static List<ContactData> GetAll()
    {
        // При использовании конструкции using метод закрытия Close() будет вызываться в конце автоматически и не надо писать db.Close()
        using (AddressBookDb db = new AddressBookDb())
        {
            return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
        }
    }


}





