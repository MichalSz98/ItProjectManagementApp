using Application.CQRS.Commands;
using Application.CQRS.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace ItProjectManagementApp.Presentation.Controllers
{
    [ApiController]
    [Route("/api/task")]
    public class TaskController : ControllerBase
    {
        private readonly GenericHandler _genericHandler;

        public TaskController(GenericHandler genericHandler)
        {
            _genericHandler = genericHandler;
        }

        // Metody z wykorzystaniem CQRS
        [HttpPost]
        public ActionResult CreateProject([FromBody] CreateTaskCommand cmd)
        {
            _genericHandler.Handle<CreateTaskCommandHandler>(cmd);

            return Created();
        }
    }
}
