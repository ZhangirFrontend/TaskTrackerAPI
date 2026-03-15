using System;
using System.Collections.Generic;
using System.Linq;
using TaskTrackerAPI.Models;

namespace TaskTrackerAPI.Services
{
    public interface ITaskRepository
    {
        IEnumerable<BaseTask> GetAll();
        void Add(BaseTask task);
        BaseTask? GetById(Guid id);
    }

    public class TaskRepository : ITaskRepository
    {
        private readonly List<BaseTask> _tasks = new();

        public IEnumerable<BaseTask> GetAll() => _tasks;

        public void Add(BaseTask task)
        {
            _tasks.Add(task);
        }

        public BaseTask? GetById(Guid id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }
    }
}