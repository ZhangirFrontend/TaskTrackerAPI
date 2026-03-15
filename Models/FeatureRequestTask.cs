namespace TaskTrackerAPI.Models
{
    public class FeatureRequestTask : BaseTask
    {
        public int EstimatedHours { get; set; }

        public FeatureRequestTask(string title, int estimatedHours) : base(title)
        {
            EstimatedHours = estimatedHours;
        }
    }
}