using Application.CQRS.Commands;
using Application.CQRS.Handlers;
using Application.Hexagonal.Services;
using Application.Onion.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItProjectManagementApp.Presentation.Controllers
{
    [ApiController]
    [Route("/api/task")]
    public class TaskController : ControllerBase
    {
        private readonly GenericHandler _genericHandler;
        private readonly TaskAssignmentService _taskAssignmentService;
        private readonly TaskDependencyService _taskDependencyService;

        public TaskController(GenericHandler genericHandler,
            TaskAssignmentService taskAssignmentService,
            TaskDependencyService taskDependencyService)
        {
            _genericHandler = genericHandler;
            _taskAssignmentService = taskAssignmentService;
            _taskDependencyService = taskDependencyService;
        }

        // Metody z wykorzystaniem CQRS
        [HttpPost]
        public ActionResult CreateProject([FromBody] CreateTaskCommand cmd)
        {
            _genericHandler.Handle<CreateTaskCommandHandler>(cmd);

            return Created("/api/task", null);
        }

        // Metody z wykorzystaniem architektury heksagonalnej
        [HttpPut("{taskId}/assign-to/{userId}")]
        public ActionResult AssignToUser(int taskId, int userId)
        {
            _taskAssignmentService.AssignTaskToUser(taskId, userId);
            return Ok();
        }

        // Metody z wykorzystaniem architektury cebulowej
        [HttpPut("{taskId}/add-dependency/{dependentOnId}")]
        public IActionResult AddDependency(int taskId, int dependentOnId)
        {
            _taskDependencyService.AddDependency(taskId, dependentOnId);
            return Ok();
        }
    }
}
