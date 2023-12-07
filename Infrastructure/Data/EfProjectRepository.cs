using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class EfProjectRepository : IProjectRepository
    {
        private readonly ApplicationContext _context;

        public EfProjectRepository(ApplicationContext context)
        {
            _context = context;
        }

        public int Add(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();

            return project.Id;
        }

        public IEnumerable<Project> GetAll()
        {
            var projects = _context
                .Projects
                .Include(r => r.Tasks)
                .ToList();

            return projects;
        }
    }
}
