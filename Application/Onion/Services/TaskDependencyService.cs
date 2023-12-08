using Domain.Exceptions;
using Domain.Repositories;
using Task = Domain.Entities.Task;

namespace Application.Onion.Services
{
    public class TaskDependencyService
    {
        private readonly IDataRepository<Task> _taskRepository;

        public TaskDependencyService(IDataRepository<Task> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void AddDependency(int taskId, int dependentOnId)
        {
            var task = _taskRepository.GetById(taskId);
            var dependentOnTask = _taskRepository.GetById(dependentOnId);

            if (task == null || dependentOnTask == null)
                throw new NotFoundException("Task not found.");

            task.AddDependency(dependentOnTask);

            _taskRepository.Update(task);
        }
    }
}
