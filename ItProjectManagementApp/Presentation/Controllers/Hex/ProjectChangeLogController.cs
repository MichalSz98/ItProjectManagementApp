using Application.Dtos;
using Domain.Ports;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ItProjectManagementApp.Presentation.Controllers.Hex
{
    [ApiController]
    [Route("/api/HEX/projectChangeLog")]
    public class ProjectChangeLogController : ControllerBase
    {
        private readonly IProjectChangeLogTracker _projectChangeLogTracker;

        public ProjectChangeLogController(IProjectChangeLogTracker projectChangeLogTracker)
        {
            _projectChangeLogTracker = projectChangeLogTracker;
        }

        [HttpPost]
        public ActionResult AddProjectChangeLog([FromBody] AddProjectChangeLogDto dto)
        {
            _projectChangeLogTracker.AddProjectChangeLog(dto.ProjectId, dto.ChangeDescription);

            return Created("/api/HEX/projectChangeLog", null);
        }

        [HttpGet("{projectId}")]
        public ActionResult<IEnumerable<ProjectChangeLogDto>> GetProjectChangeLog(int projectId)
        {
            var logs = _projectChangeLogTracker.GetProjectChangeLog(projectId);

            return Ok(logs);
        }

        public class AddProjectChangeLogDto
        {
            [Required]
            public int ProjectId { get; set; }

            [Required]
            [MaxLength(250)]
            public string ChangeDescription { get; set; }
        }
    }
}
