//using Atlassian.Jira;
using JIRA_ConsoleApp.Credentials;
using JIRA_ConsoleApp.GetJiraDetailsModel;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
//using static JIRA_ConsoleApp.Fields2_Test;

namespace JIRA_ConsoleApp.ClassesWithJiraAPI
{
    public class GetJiraDetailsClass : CredDetails
    {
        //CredDetails cr = new CredDetails();
        public void GetJiraDetails() //Fields2 fs2 
        {
            try
            {
                // HttpClient with authentication
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(jiraUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{apiToken}")));

                // GetResponseDataAll
                #region

                Aggregateprogress aggregateprogress = new Aggregateprogress()
                {
                    progress = 1,
                    total = 1,
                };

                AvatarUrls avatarurls = new AvatarUrls()
                {
                    _48x48 = "",
                    _24x24 = "",
                    _16x16 = "",
                    _32x32 = "",
                };

                Comment comment = new Comment()
                {
                    comments = new List<object>(),
                    self = "",
                    maxResults = 1,
                    total = 1,
                    startAt = 1,
                };

                Content content = new Content()
                {
                    type = "",
                    content = new List<Content>(),
                    text = "",
                };

                Creator creator = new Creator()
                {
                    self = "",
                    accountId = "",
                    emailAddress = "",
                    avatarUrls = new AvatarUrls()
                    {
                        _48x48 = "",
                        _24x24 = "",
                        _16x16 = "",
                        _32x32 = "",
                    },
                    displayName = "",
                    active = true,
                    timeZone = "",
                    accountType = "",
                };

                Customfield10018 customfield10018 = new Customfield10018()
                {
                    hasEpicLinkFieldDependency = true,
                    showField = true,
                    nonEditableReason = new NonEditableReason()
                    {
                        reason = "",
                        message = "",
                    },
                };

                Description description = new Description()
                {
                    version = 1,
                    type = "",
                    content = new List<Content>(),
                };

                Fields fields = new Fields()
                {
                    // statuscategorychangedate = DateTime.Now,

                    issuetype = new Issuetype()
                    {
                        self = "",
                        id = "",
                        description = "",
                        iconUrl = "",
                        name = "",
                        subtask = true,
                        avatarId = 1,
                        entityId = "",
                        hierarchyLevel = 1,
                    },
                    // Unknown Property : timespent 
                    // Unknown Property : customfield_10030 
                    project = new Project()
                    {
                        self = "",
                        id = "",
                        key = "",
                        name = "",
                        projectTypeKey = "",
                        simplified = true,
                        avatarUrls = new AvatarUrls()
                        {
                            _48x48 = "",
                            _24x24 = "",
                            _16x16 = "",
                            _32x32 = "",
                        },
                    },
                    fixVersions = new List<object>(),
                    // Unknown Property : aggregatetimespent 
                    customfield_10034 = "",
                    // Unknown Property : resolution 
                    // Unknown Property : customfield_10035 
                    // Unknown Property : customfield_10027 
                    // Unknown Property : customfield_10028 
                    // Unknown Property : customfield_10029 
                    // Unknown Property : resolutiondate 
                    workratio = 1,
                    issuerestriction = new Issuerestriction()
                    {
                        issuerestrictions = new Issuerestrictions(),
                        shouldDisplay = true,
                    },
                    //lastViewed = DateTime.Now,
                    watches = new Watches()
                    {
                        self = "",
                        watchCount = 1,
                        isWatching = true,
                    },
                    //created = DateTime.Now,

                    // Unknown Property : customfield_10020 
                    // Unknown Property : customfield_10021 
                    // Unknown Property : customfield_10022 
                    // Unknown Property : customfield_10023 
                    priority = new Priority()
                    {
                        self = "",
                        iconUrl = "",
                        name = "",
                        id = "",
                    },
                    // Unknown Property : customfield_10024 
                    // Unknown Property : customfield_10025 
                    labels = new List<object>(),
                    // Unknown Property : customfield_10026 
                    // Unknown Property : customfield_10016 
                    // Unknown Property : customfield_10017 
                    customfield_10018 = new Customfield10018()
                    {
                        hasEpicLinkFieldDependency = true,
                        showField = true,
                        nonEditableReason = new NonEditableReason()
                        {
                            reason = "",
                            message = "",
                        },
                    },
                    customfield_10019 = "",
                    // Unknown Property : timeestimate 
                    // Unknown Property : aggregatetimeoriginalestimate 
                    versions = new List<object>(),
                    issuelinks = new List<object>(),
                    // Unknown Property : assignee 
                    //updated = DateTime.Now,
                    status = new Status()
                    {
                        self = "",
                        description = "",
                        iconUrl = "",
                        name = "",
                        id = "",
                        statusCategory = new StatusCategory()
                        {
                            self = "",
                            id = 1,
                            key = "",
                            colorName = "",
                            name = "",
                        },
                    },
                    components = new List<object>(),
                    // Unknown Property : timeoriginalestimate 
                    description = new Description()
                    {
                        version = 1,
                        type = "",
                        content = new List<Content>(),
                    },
                    // Unknown Property : customfield_10010 
                    // Unknown Property : customfield_10014 
                    // Unknown Property : customfield_10015 
                    timetracking = new Timetracking(),
                    // Unknown Property : customfield_10005 
                    // Unknown Property : customfield_10006 
                    // Unknown Property : security 
                    // Unknown Property : customfield_10007 
                    // Unknown Property : customfield_10008 
                    // Unknown Property : customfield_10009 
                    // Unknown Property : aggregatetimeestimate 
                    attachment = new List<object>(),
                    summary = "",
                    creator = new Creator()
                    {
                        self = "",
                        accountId = "",
                        emailAddress = "",
                        avatarUrls = new AvatarUrls()
                        {
                            _48x48 = "",
                            _24x24 = "",
                            _16x16 = "",
                            _32x32 = "",
                        },
                        displayName = "",
                        active = true,
                        timeZone = "",
                        accountType = "",
                    },
                    subtasks = new List<object>(),
                    reporter = new Reporter()
                    {
                        self = "",
                        accountId = "",
                        emailAddress = "",
                        avatarUrls = new AvatarUrls()
                        {
                            _48x48 = "",
                            _24x24 = "",
                            _16x16 = "",
                            _32x32 = "",
                        },
                        displayName = "",
                        active = true,
                        timeZone = "",
                        accountType = "",
                    },
                    aggregateprogress = new Aggregateprogress()
                    {
                        progress = 1,
                        total = 1,
                    },
                    // Unknown Property : customfield_10001 
                    // Unknown Property : customfield_10002 
                    // Unknown Property : customfield_10003 
                    // Unknown Property : customfield_10004 
                    // Unknown Property : environment 
                    // Unknown Property : duedate 
                    progress = new Progress()
                    {
                        progress = 1,
                        total = 1,
                    },
                    votes = new Votes()
                    {
                        self = "",
                        votes = 1,
                        hasVoted = true,
                    },
                    comment = new Comment()
                    {
                        comments = new List<object>(),
                        self = "",
                        maxResults = 1,
                        total = 1,
                        startAt = 1,
                    },
                    worklog = new Worklog()
                    {
                        startAt = 1,
                        maxResults = 1,
                        total = 1,
                        worklogs = new List<object>(),
                    },
                };

                Issuerestriction issuerestriction = new Issuerestriction()
                {
                    issuerestrictions = new Issuerestrictions(),
                    shouldDisplay = true,
                };

                Issuerestrictions issuerestrictions = new Issuerestrictions()
                {
                };

                Issuetype issuetype = new Issuetype()
                {
                    self = "",
                    id = "",
                    description = "",
                    iconUrl = "",
                    name = "",
                    subtask = true,
                    avatarId = 1,
                    entityId = "",
                    hierarchyLevel = 1,
                };

                NonEditableReason noneditablereason = new NonEditableReason()
                {
                    reason = "",
                    message = "",
                };

                Priority priority = new Priority()
                {
                    self = "",
                    iconUrl = "",
                    name = "",
                    id = "",
                };

                Progress progress = new Progress()
                {
                    progress = 1,
                    total = 1,
                };

                Project project = new Project()
                {
                    self = "",
                    id = "",
                    key = "",
                    name = "",
                    projectTypeKey = "",
                    simplified = true,
                    avatarUrls = new AvatarUrls()
                    {
                        _48x48 = "",
                        _24x24 = "",
                        _16x16 = "",
                        _32x32 = "",
                    },
                };

                Reporter reporter = new Reporter()
                {
                    self = "",
                    accountId = "",
                    emailAddress = "",
                    avatarUrls = new AvatarUrls()
                    {
                        _48x48 = "",
                        _24x24 = "",
                        _16x16 = "",
                        _32x32 = "",
                    },
                    displayName = "",
                    active = true,
                    timeZone = "",
                    accountType = "",
                };

                GetJiraDetailsClassModel fields2_Test = new GetJiraDetailsClassModel()
                {
                    expand = "",
                    id = "",
                    self = "",
                    key = "",
                    fields = new Fields()
                    {
                        //statuscategorychangedate = DateTime.Now,
                        issuetype = new Issuetype()
                        {
                            self = "",
                            id = "",
                            description = "",
                            iconUrl = "",
                            name = "",
                            subtask = true,
                            avatarId = 1,
                            entityId = "",
                            hierarchyLevel = 1,
                        },
                        // Unknown Property : timespent 
                        // Unknown Property : customfield_10030 
                        project = new Project()
                        {
                            self = "",
                            id = "",
                            key = "",
                            name = "",
                            projectTypeKey = "",
                            simplified = true,
                            avatarUrls = new AvatarUrls()
                            {
                                _48x48 = "",
                                _24x24 = "",
                                _16x16 = "",
                                _32x32 = "",
                            },
                        },
                        fixVersions = new List<object>(),
                        // Unknown Property : aggregatetimespent 
                        customfield_10034 = "",
                        // Unknown Property : resolution 
                        // Unknown Property : customfield_10035 
                        // Unknown Property : customfield_10027 
                        // Unknown Property : customfield_10028 
                        // Unknown Property : customfield_10029 
                        // Unknown Property : resolutiondate 
                        workratio = 1,
                        issuerestriction = new Issuerestriction()
                        {
                            issuerestrictions = new Issuerestrictions(),
                            shouldDisplay = true,
                        },
                        //lastViewed = DateTime.Now,
                        watches = new Watches()
                        {
                            self = "",
                            watchCount = 1,
                            isWatching = true,
                        },
                        //created = DateTime.Now,
                        // Unknown Property : customfield_10020 
                        // Unknown Property : customfield_10021 
                        // Unknown Property : customfield_10022 
                        // Unknown Property : customfield_10023 
                        priority = new Priority()
                        {
                            self = "",
                            iconUrl = "",
                            name = "",
                            id = "",
                        },
                        // Unknown Property : customfield_10024 
                        // Unknown Property : customfield_10025 
                        labels = new List<object>(),
                        // Unknown Property : customfield_10026 
                        // Unknown Property : customfield_10016 
                        // Unknown Property : customfield_10017 
                        customfield_10018 = new Customfield10018()
                        {
                            hasEpicLinkFieldDependency = true,
                            showField = true,
                            nonEditableReason = new NonEditableReason()
                            {
                                reason = "",
                                message = "",
                            },
                        },
                        customfield_10019 = "",
                        // Unknown Property : timeestimate 
                        // Unknown Property : aggregatetimeoriginalestimate 
                        versions = new List<object>(),
                        issuelinks = new List<object>(),
                        // Unknown Property : assignee 
                        //updated = DateTime.Now,
                        status = new Status()
                        {
                            self = "",
                            description = "",
                            iconUrl = "",
                            name = "",
                            id = "",
                            statusCategory = new StatusCategory()
                            {
                                self = "",
                                id = 1,
                                key = "",
                                colorName = "",
                                name = "",
                            },
                        },
                        components = new List<object>(),
                        // Unknown Property : timeoriginalestimate 
                        description = new Description()
                        {
                            version = 1,
                            type = "",
                            content = new List<Content>(),
                        },
                        // Unknown Property : customfield_10010 
                        // Unknown Property : customfield_10014 
                        // Unknown Property : customfield_10015 
                        timetracking = new Timetracking(),
                        // Unknown Property : customfield_10005 
                        // Unknown Property : customfield_10006 
                        // Unknown Property : security 
                        // Unknown Property : customfield_10007 
                        // Unknown Property : customfield_10008 
                        // Unknown Property : customfield_10009 
                        // Unknown Property : aggregatetimeestimate 
                        attachment = new List<object>(),
                        summary = "",
                        creator = new Creator()
                        {
                            self = "",
                            accountId = "",
                            emailAddress = "",
                            avatarUrls = new AvatarUrls()
                            {
                                _48x48 = "",
                                _24x24 = "",
                                _16x16 = "",
                                _32x32 = "",
                            },
                            displayName = "",
                            active = true,
                            timeZone = "",
                            accountType = "",
                        },
                        subtasks = new List<object>(),
                        reporter = new Reporter()
                        {
                            self = "",
                            accountId = "",
                            emailAddress = "",
                            avatarUrls = new AvatarUrls()
                            {
                                _48x48 = "",
                                _24x24 = "",
                                _16x16 = "",
                                _32x32 = "",
                            },
                            displayName = "",
                            active = true,
                            timeZone = "",
                            accountType = "",
                        },
                        aggregateprogress = new Aggregateprogress()
                        {
                            progress = 1,
                            total = 1,
                        },
                        // Unknown Property : customfield_10001 
                        // Unknown Property : customfield_10002 
                        // Unknown Property : customfield_10003 
                        // Unknown Property : customfield_10004 
                        // Unknown Property : environment 
                        // Unknown Property : duedate 
                        progress = new Progress()
                        {
                            progress = 1,
                            total = 1,
                        },
                        votes = new Votes()
                        {
                            self = "",
                            votes = 1,
                            hasVoted = true,
                        },
                        comment = new Comment()
                        {
                            comments = new List<object>(),
                            self = "",
                            maxResults = 1,
                            total = 1,
                            startAt = 1,
                        },
                        worklog = new Worklog()
                        {
                            startAt = 1,
                            maxResults = 1,
                            total = 1,
                            worklogs = new List<object>(),
                        },
                    },
                };

                Status status = new Status()
                {
                    self = "",
                    description = "",
                    iconUrl = "",
                    name = "",
                    id = "",
                    statusCategory = new StatusCategory()
                    {
                        self = "",
                        id = 1,
                        key = "",
                        colorName = "",
                        name = "",
                    },
                };

                StatusCategory statuscategory = new StatusCategory()
                {
                    self = "",
                    id = 1,
                    key = "",
                    colorName = "",
                    name = "",
                };

                Timetracking timetracking = new Timetracking()
                {
                };

                Votes votes = new Votes()
                {
                    self = "",
                    votes = 1,
                    hasVoted = true,
                };

                Watches watches = new Watches()
                {
                    self = "",
                    watchCount = 1,
                    isWatching = true,
                };

                Worklog worklog = new Worklog()
                {
                    startAt = 1,
                    maxResults = 1,
                    total = 1,
                    worklogs = new List<object>(),
                };

                #endregion

                Console.Write("Enter Issue Number: ");
                string IssueNumber = Console.ReadLine();

                // GET Data 
                var GetData = httpClient.GetAsync($"rest/api/3/issue/{"AP-" + IssueNumber}").Result; //AP-36
                var GetAllData = GetData.Content.ReadAsStringAsync().Result;

                //var GetAllDataFinal = Regex.Unescape(GetAllData);

                //var GetResponse = JsonSerializer.Deserialize<Fields2_Test>(GetAllData);
                GetJiraDetailsClassModel GetResponse = JsonSerializer.Deserialize<GetJiraDetailsClassModel>(GetAllData);

                Console.WriteLine("\n----------------------------------");
                Console.WriteLine("Key     : " + GetResponse.key);
                Console.WriteLine("Form ID : " + GetResponse.fields.customfield_10034);
                Console.WriteLine("Summary : " + GetResponse.fields.summary);
                Console.WriteLine("Status  : " + GetResponse.fields.status.name);

                Console.WriteLine("\nReporter Name  : " + GetResponse.fields.reporter.displayName);
                Console.WriteLine("Reporter Email : " + GetResponse.fields.reporter.emailAddress);
                Console.WriteLine("----------------------------------");
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                throw;
            }
        }
    }
}
