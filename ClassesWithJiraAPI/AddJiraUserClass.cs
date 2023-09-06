using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JIRA_ConsoleApp.AddUserModel;
using JIRA_ConsoleApp.Credentials;

namespace JIRA_ConsoleApp.ClassesWithJiraAPI
{
    public class AddJiraUserClass : CredDetails
    {
        CredDetails cr = new CredDetails();
        public bool AddJiraUser()
        {
            try
            {
                Console.Write("Please Enter the User Name: ");
                string JIraUserName = Console.ReadLine();
                Console.Write("Please Enter the valid Email Address: ");
                string AddUser = Console.ReadLine();

                AddJiraUserModel addJiraUserClass = new AddJiraUserModel()
                {
                    name = JIraUserName,
                    emailAddress = AddUser
                };

                // HttpClient with authentication
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(jiraUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{apiToken}")));

                var json = JsonSerializer.Serialize(addJiraUserClass);
                json = Regex.Unescape(json);

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = httpClient.PostAsync("rest/api/3/user", content).Result;

                // Response
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var postResponse_User = JsonSerializer.Deserialize<AddJiraUserClassResponse>(responseContent, options);

                    Console.WriteLine("\nThe User has been added successfully!");
                    Console.WriteLine("\nUser Name is: " + postResponse_User.displayName);
                    Console.WriteLine("Email Address is: " + postResponse_User.emailAddress);
                    Console.WriteLine("Account ID is: " + postResponse_User.accountId);
                    string responseAccId = postResponse_User.accountId;

                    //Console.WriteLine("Email Address is: " + postResponse_User.accountId);
                    Console.WriteLine("\nWould you like to add user as a watcher? If Yes press 1 | If No press 2");

                    int userResponse = Convert.ToInt32(Console.ReadLine());

                    if (userResponse == 1)
                    {
                        AddWatcherClass addWatcherClass = new AddWatcherClass();
                        addWatcherClass.AddWatcher();
                    }
                    else if (userResponse == 2)
                    {
                        Console.WriteLine("Process completed. Thank you!");
                    }
                    else
                    {
                        Console.WriteLine("Please select valid option");
                    }
                }
                else
                {
                    Console.WriteLine("Error adding new user. Status Code: " + response.StatusCode);
                }
                bool userCreationResponse = response.IsSuccessStatusCode;
                //
                return userCreationResponse;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                throw;
            }
        }
    }
}
