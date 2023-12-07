using Application.CQRS.Commands;
using Application.CQRS.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace ItProjectManagementApp.Presentation.Controllers
{
    [ApiController]
    [Route("/api/task")]
    public class TaskController : ControllerBase
    {
        private readonly CreateTaskCommandHandler _createTaskCommandHandler;

        public TaskController(CreateTaskCommandHandler createTaskCommandHandler)
        {
            _createTaskCommandHandler = createTaskCommandHandler;
        }

        // Metody z wykorzystaniem CQRS
        [HttpPost]
        public ActionResult CreateProject([FromBody] CreateTaskCommand cmd)
        {
            var id = _createTaskCommandHandler.Handle(cmd);

            return Created($"/api/task/{id}", null);
        }
    }
}
