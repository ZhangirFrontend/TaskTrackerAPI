using System;

namespace TaskTrackerAPI.Models
{
    public abstract class BaseTask
    {
        public Guid Id { get; init; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; init; }
        public bool IsCompleted { get; private set; }

        public delegate void TaskCompletedHandler(BaseTask task);
        public event TaskCompletedHandler? OnTaskCompleted;

        protected BaseTask(string title)
        {
            Id = Guid.NewGuid();
            Title = title;
            CreatedAt = DateTime.UtcNow;
            IsCompleted = false;
        }

        public void CompleteTask()
        {
            if (!IsCompleted)
            {
                IsCompleted = true;
                OnTaskCompleted?.Invoke(this);
            }
        }
    }
}