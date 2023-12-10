using Application.CQRS.Commands;
using Application.CQRS.Handlers;
using Application.CQRS.Queries;
using Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ItProjectManagementApp.Presentation.Controllers.CQRS
{
    [ApiController]
    [Route("/api/CQRS/project")]
    public class ProjectController : ControllerBase
    {
        private readonly GenericHandler _genericHandler;

        public ProjectController(GenericHandler genericHandler)
        {
            _genericHandler = genericHandler;
        }

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

            return Created("/api/CQRS/task", null);
        }
    }
}
