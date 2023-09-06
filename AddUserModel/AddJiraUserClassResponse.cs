using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JIRA_ConsoleApp.AddUserModel
{
    internal class AddJiraUserClassResponse
    {
        public string self { get; set; }
        public string key { get; set; }
        public string accountId { get; set; }
        public string accountType { get; set; }
        public string name { get; set; }
        public string emailAddress { get; set; }
        public Avatarurls avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
        public Groups groups { get; set; }
        public Applicationroles applicationRoles { get; set; }

        public class Avatarurls
        {
            public string _48x48 { get; set; }
            public string _24x24 { get; set; }
            public string _16x16 { get; set; }
            public string _32x32 { get; set; }
        }

        public class Groups
        {
            public int size { get; set; }
            public object[] items { get; set; }
        }

        public class Applicationroles
        {
            public int size { get; set; }
            public object[] items { get; set; }
        }

    }
}
