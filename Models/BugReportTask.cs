    namespace TaskTrackerAPI.Models
    {
        public class BugReportTask : BaseTask
        {
            public string SeverityLevel { get; set; }

            public BugReportTask(string title, string severityLevel) : base(title)
            {
                SeverityLevel = severityLevel;
            }
        }
    }