using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using JIRA_ConsoleApp.Credentials;

namespace JIRA_ConsoleApp.ClassesWithJiraAPI
{
    public class AttachmentClass : CredDetails
    {
        CredDetails cr = new CredDetails();
        public void AttachmentPost()
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(cr.jiraUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{cr.username}:{cr.apiToken}")));
                httpClient.DefaultRequestHeaders.Add("X-Atlassian-Token", "no-check");

                var filePath = @"D:\JIRA_Test\demo.pdf";
                using (var multipartFormContent = new MultipartFormDataContent())
                {
                    //Load the file and set the file's Content-Type header
                    var fileStreamContent = new StreamContent(File.OpenRead(filePath));

                    fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("application/pdf"); //application / pdf

                    //Add the file
                    multipartFormContent.Add(fileStreamContent, name: "file", fileName: "demo.pdf");

                    //Send it
                    var response2 = httpClient.PostAsync("rest/api/3/issue/AP-11/attachments", multipartFormContent).Result;
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
