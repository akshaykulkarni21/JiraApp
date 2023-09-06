using JIRA_ConsoleApp.ClassesWithJiraAPI;
using System.Runtime.Intrinsics.Arm;

class Program
{
    public void SelectList()
    {
        Console.WriteLine("Select below option to complete the jira related transaction");
        Console.WriteLine("\n- Select option 1 to create the jira ticket");
        Console.WriteLine("- Select option 2 to add watcher in jira ticket");
        Console.WriteLine("- Select option 3 to add new jira user");
        Console.WriteLine("- Select option 4 to get jira details");
        Console.WriteLine("- Select option 5 Complete Flow");
        int options = Convert.ToInt32(Console.ReadLine());

        if (options == 1)
        {
            CreateJiraTicketClass ticket = new CreateJiraTicketClass();
            ticket.CreateJiraRequest();
        }
        else if (options == 2)
        {
            AddWatcherClass addWatcherClass = new AddWatcherClass();
            addWatcherClass.AddWatcher();
        }
        else if (options == 3)
        {
            AddJiraUserClass addJiraUserClass = new AddJiraUserClass();
            addJiraUserClass.AddJiraUser();
        }
        else if (options == 4)
        {
            GetJiraDetailsClass getJiraDetailsClass = new GetJiraDetailsClass();
            getJiraDetailsClass.GetJiraDetails();
        }
        else if (options == 5)
        {
            CreateJiraTicketClass ticket = new CreateJiraTicketClass();
            int isSuccessCount = ticket.CreateJiraRequest();

            if (isSuccessCount == 0)
            {
                Console.WriteLine("\n------------- Add Jira User -------------\n");
                AddJiraUserClass addJiraUserClass = new AddJiraUserClass();
                bool userCreatedResponseStat = addJiraUserClass.AddJiraUser();

                if (userCreatedResponseStat)
                {
                    Console.WriteLine("\n------------- Get Complete Jira Details -------------\n");
                    GetJiraDetailsClass getJiraDetailsClass = new GetJiraDetailsClass();
                    getJiraDetailsClass.GetJiraDetails();
                }
                else
                {
                    Console.WriteLine("--------Process Finished---------");
                }
            }            

        }
        else
        {
            Console.WriteLine("Please choose the valid option");
        }
    }
    static void Main()
    {
        Program p = new Program();
        p.SelectList();

        //GetJiraDetailsWIthCustomField a = new GetJiraDetailsWIthCustomField();
        //a.SearchIssueCustomField();    
    }
}
