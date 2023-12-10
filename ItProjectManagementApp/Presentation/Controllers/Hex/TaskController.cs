using Application.Dtos;
using Application.Hexagonal.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItProjectManagementApp.Presentation.Controllers.Hex
{
    [ApiController]
    [Route("/api/HEX/task")]
    public class TaskController : ControllerBase
    {
        private readonly TaskAssignmentService _taskAssignmentService;
        private readonly ITaskCommentService _taskCommentService;

        public TaskController(TaskAssignmentService taskAssignmentService,
            ITaskCommentService taskCommentService)
        {
            _taskAssignmentService = taskAssignmentService;
            _taskCommentService = taskCommentService;
        }

        [HttpPut("{taskId}/assign-to/{userId}")]
        public ActionResult AssignToUser(int taskId, int userId)
        {
            _taskAssignmentService.AssignTaskToUser(taskId, userId);
            return Ok();
        }

        [HttpPut("{taskId}/add-comment")]
        public ActionResult AddComment(int taskId, [FromBody] string commentText)
        {
            _taskCommentService.AddComment(taskId, commentText);

            return Ok();
        }

        [HttpGet("{taskId}/get-task-comments")]
        public ActionResult<IEnumerable<CommentDto>> GetTaskComments(int taskId)
        {
            var comments = _taskCommentService.GetComments(taskId);

            return Ok(comments);
        }
    }
}
