using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static JIRA_ConsoleApp.ModelClasses.SearchIssueEntity;

namespace JIRA_ConsoleApp.ModelClasses
{
    public class SearchIssueEntity
    {
        //    {
        //"jql": ""project = ABC AND summary ~ 'This is summary number 18'"",
        //"startAt": 0,
        //"maxResults": 2,
        //"fields": [
        //    "10001",
        //    "AP"
        //]
        //}
        public string jql { get; set; }
        public int startAt { get; set; }
        public int maxResults { get; set; }
        //public string[] fields_id_key { get; set; }
        public List<Fields3> fields { get; set; }

        //public Fields_id_key fields_id_key { get; set; }

        public class Fields3
        {
            public int id { get; set; }
            public string key { get; set; }

        }
    }
}
