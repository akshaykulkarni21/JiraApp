using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JIRA_ConsoleApp.ModelClasses.SearchIssueEntity;

namespace JIRA_ConsoleApp.ModelClasses
{
    public class SearchIssueEntityResponse
    {
        public int maxResults { get; set; }
        public int startAt { get; set; }
        public int total { get; set; }
        public string expand { get; set; }
        //public Issue[] issues { get; set; }
        public List<Issue> issue { get; set; }
        public string key { get; internal set; }
    }

    public class Issue
    {
        public string expand { get; set; }
        public string id { get; set; }
        public string key { get; set; }
        public string self { get; set; }
        public string transitions { get; set; }
    }
}
