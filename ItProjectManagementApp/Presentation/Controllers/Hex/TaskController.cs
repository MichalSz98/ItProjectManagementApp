using Application.Hexagonal.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItProjectManagementApp.Presentation.Controllers.Hex
{
    [ApiController]
    [Route("/api/HEX/task")]
    public class TaskController : ControllerBase
    {
        private readonly TaskAssignmentService _taskAssignmentService;

        public TaskController(TaskAssignmentService taskAssignmentService)
        {
            _taskAssignmentService = taskAssignmentService;
        }

        [HttpPut("{taskId}/assign-to/{userId}")]
        public ActionResult AssignToUser(int taskId, int userId)
        {
            _taskAssignmentService.AssignTaskToUser(taskId, userId);
            return Ok();
        }
    }
}
