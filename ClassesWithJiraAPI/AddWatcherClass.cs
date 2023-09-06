using JIRA_ConsoleApp.AddWatcherClassModel;
using JIRA_ConsoleApp.Credentials;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JIRA_ConsoleApp.ClassesWithJiraAPI
{
    public class AddWatcherClass : CredDetails
    {
        CredDetails cr = new CredDetails();
        public void AddWatcher()
        {
            try
            {
                Console.Write("Enter the issue number: ");
                string issue_key = Console.ReadLine();

                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(jiraUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{apiToken}")));

                WatcherModel watcher_class = new WatcherModel()
                {
                    accountId = "712020:09d9906b-d4f8-4d2b-b97e-0ca2ac5fe872"
                };
                var json = System.Text.Json.JsonSerializer.Serialize(watcher_class);

                Console.Write("Please enter the account Id: ");
                var accountId = Console.ReadLine();
                var accId = accountId.Replace(accountId, "\"" + accountId + "\"");
                //var accountId = "\"712020:7bd0f4f5-165f-48b7-82a5-521da2fd89de\"";

                var content = new StringContent(accId, Encoding.UTF8, "application/json");
                var response = httpClient.PostAsync($"rest/api/3/issue/AP-{issue_key}/watchers", content).Result;//rest/api/3/issue/AP-23/watchers

                if (response.IsSuccessStatusCode)
                {
                    //Console.WriteLine("URL: " + httpClient.BaseAddress + $"rest/api/3/issue/{issue_key}/watchers");
                    Console.WriteLine("\nThe jira watcher added succesfully!");
                }
                else
                {
                    Console.WriteLine("\nYou have entered wrong User Id Or Issue Number");
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                throw;
            }
        }

    }
}
