using Application.CQRS.Commands;
using Application.CQRS.Handlers;
using Application.CQRS.Queries;
using Application.Dtos;
using Application.Hexagonal.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItProjectManagementApp.Presentation.Controllers.CQRS
{
    [ApiController]
    [Route("/api/CQRS/task")]
    public class TaskController : ControllerBase
    {
        private readonly GenericHandler _genericHandler;

        public TaskController(GenericHandler genericHandler)
        {
            _genericHandler = genericHandler;
        }

        [HttpPost]
        public ActionResult CreateTask([FromBody] CreateTaskCommand cmd)
        {
            _genericHandler.Handle<CreateTaskCommandHandler>(cmd);

            return Created("/api/CQRS/task", null);
        }

        [HttpPut("add-comment")]
        public ActionResult AddComment([FromBody] AddCommentCommand cmd)
        {
            _genericHandler.Handle<AddCommentCommandHandler>(cmd);
            return Ok();
        }

        [HttpGet("{taskId}/get-task-comments")]
        public ActionResult<IEnumerable<CommentDto>> GetTaskComments(int taskId)
        {
            var query = new GetTaskCommentsQuery()
            {
                TaskId = taskId
            };

            var comments = _genericHandler.Handle<GetTaskCommentsQueryHandler, IEnumerable<CommentDto>>(query);

            return Ok(comments);
        }

        [HttpPut("assign-to-user")]
        public ActionResult AssignToUser([FromBody] AssignTaskCommand cmd)
        {
            _genericHandler.Handle<AssignTaskCommandHandler>(cmd);
            return Ok();
        }

        [HttpPut("send-notification")]
        public ActionResult SendNotification([FromBody] SendNotificationCommand cmd)
        {
            _genericHandler.Handle<SendNotificationCommandHandler>(cmd);
            return Ok();
        }
    }
}
