using Microsoft.AspNetCore.Mvc;
using TaskTrackerAPI.Models;
using TaskTrackerAPI.Services;

namespace TaskTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _repository;

        public TasksController(ITaskRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<BaseTask> GetAll()
        {
            return _repository.GetAll();
        }

        [HttpPost("bug")]
        public IActionResult CreateBug([FromBody] BugReportTask bug)
        {
            _repository.Add(bug);
            return CreatedAtAction(nameof(GetAll), new { id = bug.Id }, bug);
        }

        [HttpPost("feature")]
        public IActionResult CreateFeature([FromBody] FeatureRequestTask feature)
        {
            _repository.Add(feature);
            return CreatedAtAction(nameof(GetAll), new { id = feature.Id }, feature);
        }

        [HttpPut("{id}/complete")]
        public IActionResult CompleteTask(Guid id)
        {
            var task = _repository.GetById(id);
            if (task == null) return NotFound();
            task.CompleteTask();
            return NoContent();
        }
    }
}