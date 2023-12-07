using ItProjectManagementApp.Entities;
using ItProjectManagementApp.Models;
using ItProjectManagementApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace ItProjectManagementApp.Controllers
{
    [ApiController]
    [Route("/api/project")]
    public class ProjectController : ControllerBase
    {
        public readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Project>> GetAll()
        {
            var projects = _projectService.GetAll();

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public ActionResult<ProjectDto> Get([FromRoute] int id)
        {
            var project = _projectService.GetById(id);

            return Ok(project);
        }
    }
}
