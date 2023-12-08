using Domain.Entities;
using Domain.Exceptions;
using Domain.Ports;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Domain.Entities.Task;

namespace Application.Hexagonal.Services
{
    public class TaskAssignmentService
    {
        private readonly IDataRepository<User> _userRepository;
        private readonly IDataRepository<Task> _taskRepository;
        private readonly INotificationService _notificationService;

        public TaskAssignmentService(IDataRepository<User> userRepository,
                                             IDataRepository<Task> taskRepository,
                                             INotificationService notificationService)
        {
            _userRepository = userRepository;
            _taskRepository = taskRepository;
            _notificationService = notificationService;
        }

        public void AssignTaskToUser(int taskId, int userId)
        {
            var user = _userRepository.GetById(userId);

            if (user == null)
                throw new NotFoundException("User not found.");

            if (!user.HasRole())
                throw new ApplicationException("User does not have any role.");

            var task = _taskRepository.GetById(taskId, p => p.Project);
            if (task == null)
                throw new NotFoundException("Task not found.");

            if (task.Project.TeamId != user.TeamId)
                throw new ApplicationException("Inappropriate user team");

            task.SetUserId(user.Id);
            _taskRepository.Update(task);

            _notificationService.SendAssignmentNotification(user.Email, null, task.Title);
        }
    }
}
