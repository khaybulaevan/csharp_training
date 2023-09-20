using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace addressbook_tests_autoit
{
    public class GroupHelper: HelperBase

    {
        public static string GROUPWINTITLE = "Group editor";
        public static string GROUPDELETEWINTITLE = "Delete group";
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public void Add(GroupData group)
        {
            OpenGroupsDealogue();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(group.Name);
            aux.Send("{ENTER}");
            CloseGroupsDialogue();

        }

        private void CloseGroupsDialogue()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        private void OpenGroupsDealogue()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITLE);
        }

        public List<GroupData> GetGroupList()
            
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDealogue();
            // AUtoIt всегда возвращает строку, поэтому надо преобразовать в число
            string count = aux.ControlTreeView
                (GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
               string item =  aux.ControlTreeView
                (GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetText", "#0|#"+i, "");
                list.Add(new GroupData() { 
                
                    Name = item
                });
                
            }
            CloseGroupsDialogue();
            return list;
        }

        public void Remove()
        {
            OpenGroupsDealogue();
            //aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d5");
            aux.Send("{DOWN}");
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.WinWait(GROUPDELETEWINTITLE);
            aux.ControlClick(GROUPDELETEWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            CloseGroupsDialogue();

        }
    }
}