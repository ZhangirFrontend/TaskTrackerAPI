using System.Collections.Generic;
using System.Linq;
using TaskTrackerAPI.Models;

namespace TaskTrackerAPI.Services
{
    public static class TaskFilterService
    {
        public static (List<BugReportTask> HighSeverityBugs, int TotalEstimatedHours) FilterTasks(IEnumerable<BaseTask> tasks)
        {
            var highBugs = tasks
                .OfType<BugReportTask>()
                .Where(t => !t.IsCompleted && t.SeverityLevel == "High")
                .OrderByDescending(t => t.CreatedAt)
                .ToList();

            var totalHours = tasks
                .OfType<FeatureRequestTask>()
                .Where(t => !t.IsCompleted)
                .Sum(t => t.EstimatedHours);

            return (highBugs, totalHours);
        }
    }
}