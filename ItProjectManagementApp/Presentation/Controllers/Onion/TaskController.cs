using Application.Dtos;
using Application.Onion.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItProjectManagementApp.Presentation.Controllers.Onion
{
    [ApiController]
    [Route("/api/ONION/task")]
    public class TaskController : ControllerBase
    {
        private readonly TaskDependencyService _taskDependencyService;
        private readonly TaskService _taskService;

        public TaskController(
            TaskDependencyService taskDependencyService, TaskService taskService)
        {

            _taskDependencyService = taskDependencyService;
            _taskService = taskService;
        }

        [HttpPut("{taskId}/add-dependency/{dependentOnId}")]
        public IActionResult AddDependency(int taskId, int dependentOnId)
        {
            _taskDependencyService.AddDependency(taskId, dependentOnId);
            return Ok();
        }

        [HttpPut("{taskId}/add-comment")]
        public ActionResult AddComment(int taskId, [FromBody] string commentText)
        {
            _taskService.AddComment(taskId, commentText);

            return Ok();
        }

        [HttpGet("{taskId}/get-task-comments")]
        public ActionResult<IEnumerable<CommentDto>> GetTaskComments(int taskId)
        {
            var comments = _taskService.GetComments(taskId);

            return Ok(comments);
        }
    }
}
