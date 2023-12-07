using Domain.Repositories;
using Task = Domain.Entities.Task;

namespace Infrastructure.Data
{
    public class EfProjectRepository2 : ITaskRepository
    {
        private readonly ApplicationContext _context;

        public EfProjectRepository2(ApplicationContext context)
        {
            _context = context;
        }

        public int Add(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();

            return task.Id;
        }
    }
}
