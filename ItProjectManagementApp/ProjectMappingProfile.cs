using AutoMapper;
using ItProjectManagementApp.Entities;
using ItProjectManagementApp.Models;
using Task = ItProjectManagementApp.Entities.Task;

namespace ItProjectManagementApp
{
    public class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile()
        {
            CreateMap<Project, ProjectDto>();

            CreateMap<Task, TaskDto>();

            CreateMap<CreateProjectDto, Project>();
        }
    }
}
