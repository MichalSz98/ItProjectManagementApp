using Task = Domain.Entities.Task;

namespace Domain.Repositories
{

    public interface ITaskRepository
    {
        int Add(Task Task);
    }
}
