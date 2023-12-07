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
        private readonly GetAllProjectsQueryHandler _getAllProjectsQueryHandler;
        private readonly CreateProjectCommandHandler _createProjectCommandHandler;

        public ProjectController(GetAllProjectsQueryHandler getAllProjectsQueryHandler,
            CreateProjectCommandHandler createProjectCommandHandler)
        {
            _getAllProjectsQueryHandler = getAllProjectsQueryHandler;
            _createProjectCommandHandler = createProjectCommandHandler;
        }

        // Metody z wykorzystaniem CQRS
        [HttpGet]
        public ActionResult<IEnumerable<ProjectDto>> GetAll()
        {
            var query = new GetAllProjectsQuery();

            var projects = _getAllProjectsQueryHandler.Handle(query);

            return Ok(projects);
        }

        [HttpPost]
        public ActionResult CreateProject([FromBody] CreateProjectCommand cmd)
        {
            var id = _createProjectCommandHandler.Handle(cmd);

            return Created($"/api/project/{id}", null);
        }
    }
}
