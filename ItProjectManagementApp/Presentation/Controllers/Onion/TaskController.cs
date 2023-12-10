using Application.Onion.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItProjectManagementApp.Presentation.Controllers.Onion
{
    [ApiController]
    [Route("/api/ONION/task")]
    public class TaskController : ControllerBase
    {
        private readonly TaskDependencyService _taskDependencyService;

        public TaskController(
            TaskDependencyService taskDependencyService)
        {

            _taskDependencyService = taskDependencyService;
        }

        [HttpPut("{taskId}/add-dependency/{dependentOnId}")]
        public IActionResult AddDependency(int taskId, int dependentOnId)
        {
            _taskDependencyService.AddDependency(taskId, dependentOnId);
            return Ok();
        }
    }
}
