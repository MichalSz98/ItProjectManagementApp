using Application.CQRS.Commands;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Task = Domain.Entities.Task;

namespace Application.CQRS.Handlers
{
    public class AssignTaskCommandHandler : ICommandHandler<AssignTaskCommand>
    {
        private readonly IDataRepository<User> _userRepository;
        private readonly IDataRepository<Task> _taskRepository;

        public AssignTaskCommandHandler(IDataRepository<User> userRepository,
            IDataRepository<Task> taskRepository)
        {
            _userRepository = userRepository;
            _taskRepository = taskRepository;
        }

        public void Handle(AssignTaskCommand command)
        {
            var user = _userRepository.GetById(command.UserId);

            if (user == null)
                throw new NotFoundException("User not found.");

            if (!user.HasRole())
                throw new ApplicationException("User does not have any role.");

            var task = _taskRepository.GetById(command.TaskId, p => p.Project);
            if (task == null)
                throw new NotFoundException("Task not found.");

            if (task.Project.TeamId != user.TeamId)
                throw new ApplicationException("Inappropriate user team");

            task.SetUserId(user.Id);
            _taskRepository.Update(task);
        }
    }
}
