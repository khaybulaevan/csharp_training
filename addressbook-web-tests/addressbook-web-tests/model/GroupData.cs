using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{

    // Класс содержит инфомацию об имени
    // Класс наследуется от IEquatable. Его можно сравнивать с другми объектами типа GroupData
    // чтобы можно было списки сортировать, нужно описать как сравниваются между собой элементы типа GroupData. Для этого добавляем интерфейс IComparable

    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {

        public GroupData()

        {

        }

        public GroupData(string name)

        {
            Name = name;
        }
        // Функция, которая реализует это сравнение. В качестве параметра принимает другой объект типа
        // Стандартный метод Equals
        public  bool Equals(GroupData other)

        {
            //Если тот объект, с котором мы сравниваем  = null
            if (Object.ReferenceEquals(other, null))
            {
                return false;

            }
            // Две ссылки указывают на один и тот же объект
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }
        // Помимо старндартного метода Equals неоходимо добавить стандартный метод GetHashCode()
        // Метод GetHashCode() Предназначен для оптимизации. Сначала сравниваются хеши, и если хеши оказались равными, то переходим к Equals
        public override int GetHashCode()

        {
            return Name.GetHashCode();
        }

        // Метод должен вернуть строковое представление объектов типа GroupData (Видим наименования групп для упавших тестов)
        // Метод ToString() переопределяет стандартный метод реализованный во всех классах, то нужно пометить ключевым словом override
        public override string ToString()
        {
            return "name = " + Name + "\n header  = " + Header + "\n footer = "  + Footer ;
        }

        // Функция  сравнения
        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        // Свойство
        [Column(Name = "group_name")]
        public string Name { get; set; }
        [Column(Name = "group_header")]
        public string Header { get; set; }
        [Column(Name = "group_footer")]
        public string Footer { get; set; }
        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<GroupData> GetAll() {
            // При использовании конструкции using метод закрытия Close() будет вызываться в конце автоматически и не надо писать db.Close()
            using (AddressBookDb db = new AddressBookDb())
            {
                return (from g in db.Groups select g).ToList();
            }
        }
        // Метод, который по группе будет получать список контактов, в которую в нее входят
        public List<ContactData> GetContacts()
        {
            using (AddressBookDb db = new AddressBookDb())
            {
                return (from c in db.Contacts
                            from gcr in db.GCR.Where(p => p.GroupId == Id && p.ContactId == c.Id && c.Deprecated == "0000-00-00 00:00:00")
                            select c).Distinct().ToList();
            }
        }
    }
}



