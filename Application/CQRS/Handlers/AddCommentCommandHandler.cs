using Application.CQRS.Commands;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Task = Domain.Entities.Task;

namespace Application.CQRS.Handlers
{
    public class AddCommentCommandHandler : ICommandHandler<AddCommentCommand>
    {
        private readonly IDataRepository<Task> _repository;

        public AddCommentCommandHandler(IDataRepository<Task> repository)
        {
            _repository = repository;
        }

        public void Handle(AddCommentCommand command)
        {
            var task = _repository.GetById(command.TaskId);

            if (task == null)
            {
                throw new NotFoundException("Task not found.");
            }

            var comment = new Comment(command.CommentText);

            task.AddComment(comment);

            _repository.Update(task);
        }
    }
}
