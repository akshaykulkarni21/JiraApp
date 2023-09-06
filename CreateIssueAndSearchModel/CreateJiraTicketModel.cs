using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace JIRA_ConsoleApp.CreateIssueAndSearchModel
{
    public class OldFields
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

        public Project2 project { get; set; }
        public string summary { get; set; }
        public string customfield_10034 { get; set; }
        public string description { get; set; }
        public Issuetype2 issuetype { get; set; }
    }

    public class Issuetype2
    {
        public string id { get; set; }
    }

    public class Project2
    {
        public string key { get; set; }
    }

    public class Root
    {
        public OldFields fields { get; set; }
    }


}
