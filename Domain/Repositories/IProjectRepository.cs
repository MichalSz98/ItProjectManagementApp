using Domain.Entities;

namespace Domain.Repositories
{

    public interface IProjectRepository
    {
        int Add(Project project);
        IEnumerable<Project> GetAll();
    }
}
