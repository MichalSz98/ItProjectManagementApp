using AutoMapper;
using ItProjectManagementApp.Entities;
using ItProjectManagementApp.Exceptions;
using ItProjectManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ItProjectManagementApp.Service
{
    public interface IProjectService
    {
        int Create(CreateProjectDto dto);
        void Update(int id, UpdateProjectDto dto);
        IEnumerable<ProjectDto> GetAll();
        ProjectDto GetById(int id);
    }

    public class ProjectService : IProjectService
    {
        private readonly ProjectDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectService> _logger;

        public ProjectService(ProjectDbContext dbContext, IMapper mapper, ILogger<ProjectService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public int Create(CreateProjectDto dto)
        {
            var project = _mapper.Map<Project>(dto);
            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();

            return project.Id;
        }

        public void Update(int id, UpdateProjectDto dto)
        {
            var restaurant = _dbContext
                .Projects
                .FirstOrDefault(r => r.Id == id);

            if (restaurant is null)
                throw new NotFoundException("Project not found");

            restaurant.Description = dto.Description;

            _dbContext.SaveChanges();
        }

        public IEnumerable<ProjectDto> GetAll()
        {
            var projects = _dbContext
                .Projects
                .Include(r => r.Tasks)
                .ToList();

            var projectsDtos = _mapper.Map<List<ProjectDto>>(projects);

            return projectsDtos;
        }

        public ProjectDto GetById(int id)
        {
            var restaurant = _dbContext
               .Projects
               .Include(r => r.Tasks)
               .FirstOrDefault(r => r.Id == id);

            if (restaurant is null) throw new NotFoundException("Project not found");

            var result = _mapper.Map<ProjectDto>(restaurant);

            return result;
        }
    }
}
