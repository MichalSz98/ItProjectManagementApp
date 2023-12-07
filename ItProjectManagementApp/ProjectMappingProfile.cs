using Application.CQRS.Commands;
using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Task = Domain.Entities.Task;

namespace ItProjectManagementApp
{
    public class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile()
        {
            CreateMap<Project, ProjectDto>();

            CreateMap<Task, TaskDto>();

            CreateMap<CreateProjectCommand, Project>();
        }
    }
}
