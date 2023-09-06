using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JIRA_ConsoleApp.Credentials;
using JIRA_ConsoleApp.ModelClasses;
using static JIRA_ConsoleApp.ModelClasses.SearchIssueEntity;

namespace JIRA_ConsoleApp
{
    public class GetJiraDetailsWIthCustomField : CredDetails
    {
        CredDetails cr = new CredDetails();
        public void SearchIssueCustomField() //SearchIssueEntity searchIssueEntity
        {
            //Console.WriteLine("Enter Summary Text: ");
            //string summaryText = Console.ReadLine();
            try
            {
                Console.Write("Enter Form ID : ");
                string FormID = Console.ReadLine();

                List<Fields3> fields = new List<Fields3>();
                Fields3 fields_id_key1 = new Fields3
                {
                    id = 10001,
                    key = "AP"
                };
                fields.Add(fields_id_key1);

                SearchIssueEntity searchIssueEntity2 = new SearchIssueEntity()
                {
                    //This is summary number 18
                    //jql = $"project = ABC AND summary ~ '{summaryText}'",
                    jql = $"project = ABC AND formid ~ '{FormID}'",
                    startAt = 0,
                    maxResults = 20,
                    fields = new List<Fields3>(fields)
                };

                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(cr.jiraUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{cr.username}:{cr.apiToken}")));

                var json = JsonSerializer.Serialize(searchIssueEntity2);
                json = Regex.Unescape(json);

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = httpClient.PostAsync("rest/api/3/search", content).Result;

                //Console.WriteLine("Body: " + json);

                var responseContent = response.Content.ReadAsStringAsync().Result;

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var searchIssueEntityResponse = JsonSerializer.Deserialize<SearchIssueEntityResponse>(responseContent, options);

                //Console.WriteLine(searchIssueEntityResponse.issue);

                var issueItem = searchIssueEntityResponse.issue;
                foreach (var i in issueItem)
                {
                    Console.WriteLine(i);
                }


                //Console.WriteLine(searchIssueEntityResponse.maxResults);
                //Console.WriteLine(searchIssueEntityResponse.key);
                //int duplicate = searchIssueEntityResponse.total;
                //Console.WriteLine(duplicate);
                //return (duplicate, FormID); //summaryText
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                throw;
            }
        }
    }
}
