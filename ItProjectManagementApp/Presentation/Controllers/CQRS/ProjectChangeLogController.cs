using Application.CQRS.Commands;
using Application.CQRS.Handlers;
using Application.CQRS.Queries;
using Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ItProjectManagementApp.Presentation.Controllers.CQRS
{
    [ApiController]
    [Route("/api/CQRS/projectChangeLog")]
    public class ProjectChangeLogController : ControllerBase
    {
        private readonly GenericHandler _genericHandler;

        public ProjectChangeLogController(GenericHandler genericHandler)
        {
            _genericHandler = genericHandler;
        }

        [HttpPost]
        public ActionResult AddProjectChangeLog([FromBody] AddProjectChangeLogCommand cmd)
        {
            _genericHandler.Handle<AddProjectChangeLogCommandHandler>(cmd);

            return Created("/api/CQRS/projectChangeLog", null);
        }

        [HttpGet("{projectId}")]
        public ActionResult<IEnumerable<ProjectChangeLogDto>> GetProjectChangeLog(int projectId)
        {
            var query = new GetProjectChangeLogQuery()
            {
                ProjectId = projectId
            };

            var logs = _genericHandler.Handle<GetProjectChangeLogQueryHandler, IEnumerable<ProjectChangeLogDto>>(query);

            return Ok(logs);
        }
    }
}
