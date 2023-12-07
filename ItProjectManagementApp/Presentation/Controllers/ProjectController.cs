using Application.CQRS.Commands;
using Application.CQRS.Handlers;
using Application.CQRS.Queries;
using Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ItProjectManagementApp.Presentation.Controllers
{
    [ApiController]
    [Route("/api/project")]
    public class ProjectController : ControllerBase
    {
        private readonly GenericHandler _genericHandler;

        public ProjectController(GenericHandler genericHandler)
        {
            _genericHandler = genericHandler;
        }

        // Metody z wykorzystaniem CQRS
        [HttpGet]
        public ActionResult<IEnumerable<ProjectDto>> GetAll()
        {
            var query = new GetAllProjectsQuery();

            var projects = _genericHandler.Handle<GetAllProjectsQueryHandler, IEnumerable<ProjectDto>>(query);

            return Ok(projects);
        }

        [HttpPost]
        public ActionResult CreateProject([FromBody] CreateProjectCommand cmd)
        {
            _genericHandler.Handle<CreateProjectCommandHandler>(cmd);

            return Created("/api/task", null);
        }
    }
}
