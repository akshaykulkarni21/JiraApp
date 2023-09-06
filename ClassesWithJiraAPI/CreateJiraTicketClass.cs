using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using JIRA_ConsoleApp.CreateIssueAndSearchModel;
using JIRA_ConsoleApp.Credentials;
using JIRA_ConsoleApp.ModelClasses;
using static JIRA_ConsoleApp.ModelClasses.SearchIssueEntity;

namespace JIRA_ConsoleApp.ClassesWithJiraAPI
{
    public class CreateJiraTicketClass : CredDetails
    {
        CredDetails cr = new CredDetails();
        public (int, string) SearchIssue() //SearchIssueEntity searchIssueEntity
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
                //Console.WriteLine(searchIssueEntityResponse.maxResults);
                //Console.WriteLine(searchIssueEntityResponse.key);
                int duplicate = searchIssueEntityResponse.total;
                //Console.WriteLine(duplicate);
                return (duplicate, FormID); //summaryText
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                throw;
            }
        }
        public int CreateJiraRequest() //Fields fs
        {
            try
            {
                CreateJiraTicketClass pr = new CreateJiraTicketClass();
                var SearchResult = pr.SearchIssue();
                int dup = SearchResult.Item1;

                //string GetSummary = SearchResult.Item2;
                string FormID = SearchResult.Item2;

                if (dup > 0)
                {
                    Console.WriteLine("\nThe Form is already exist!");
                    Console.WriteLine($"\nThis Form ID Found {dup} Times");
                }
                else
                {
                    Console.Write("\nEnter the summary details: ");
                    string GetSummary = Console.ReadLine();

                    OldFields fields = new OldFields()
                    {
                        project = new Project2()
                        {
                            key = "AP",
                        },
                        summary = GetSummary,
                        customfield_10034 = FormID,
                        description = "Your issue description",
                        issuetype = new Issuetype2()
                        {
                            id = "10001",
                        },
                    };

                    Issuetype2 issuetype = new Issuetype2()
                    {
                        id = "10001",
                    };

                    Project2 project = new Project2()
                    {
                        key = "AP",
                    };

                    Root root = new Root()
                    {
                        fields = new OldFields()
                        {
                            project = new Project2()
                            {
                                key = "AP",
                            },
                            summary = GetSummary,
                            customfield_10034 = FormID,
                            description = "Your issue description",
                            issuetype = new Issuetype2()
                            {
                                id = "10001",
                            },
                        },
                    };

                    //HttpClient with authentication
                    var httpClient = new HttpClient();
                    httpClient.BaseAddress = new Uri(jiraUrl);
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{apiToken}")));
                    //Header for attachment
                    httpClient.DefaultRequestHeaders.Add("X-Atlassian-Token", "no-check");

                    // Request (POST)
                    var json = JsonSerializer.Serialize(root);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    if (dup < 1)
                    {
                        var response = httpClient.PostAsync("rest/api/2/issue", content).Result;

                        //Console.WriteLine("\nIssue Created with URL: " + httpClient.BaseAddress + "rest/api/2/issue");
                        //Console.WriteLine("\nIssue Created with Body: " + json);

                        // Response
                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = response.Content.ReadAsStringAsync().Result;

                            var options = new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true
                            };

                            var postResponse = JsonSerializer.Deserialize<PostResponse>(responseContent, options);

                            Console.WriteLine("\nThe JIRA Ticket is successfully Created! Key:" + postResponse.key);

                            Console.Write("\nWould you like to add attachment? Press 1 if Yes | Press 2 if No : ");
                            int option = Convert.ToInt32(Console.ReadLine());

                            if (option == 1)
                            {
                                //Attachment
                                Console.Write("\nEnter the file path like D:\\JIRA_Test\\demo.pdf: ");
                                var filePath = Console.ReadLine();
                                //var filePath = @"D:\JIRA_Test\demo.pdf";
                                try
                                {
                                    using (var multipartFormContent = new MultipartFormDataContent())
                                    {
                                        //Load the file and set the file's Content-Type header
                                        var fileStreamContent = new StreamContent(File.OpenRead(filePath));
                                        fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

                                        //Add the file
                                        multipartFormContent.Add(fileStreamContent, name: "file", fileName: "demo.pdf");

                                        //Send it
                                        var response2 = httpClient.PostAsync("rest/api/3/issue/" + postResponse.key + "/attachments", multipartFormContent).Result;
                                        Console.WriteLine("\nAttachment added successfully!");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("\nYou have entered invalid path attachement not added");
                                }
                            }
                            else if (option == 2)
                            {
                                Console.WriteLine("\nThe process is completed without attachment");
                            }
                            else
                            {
                                Console.WriteLine("\nPlease select the option either 1 or 2 ");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error creating issue. Status Code: " + response.StatusCode);
                        }
                    }
                }

                int IsSuccessCount = dup;
                return IsSuccessCount;

            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                throw;
            }
        }

    }
}
