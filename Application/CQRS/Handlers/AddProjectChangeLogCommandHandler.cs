using Application.CQRS.Commands;
using Domain.Entities;
using Domain.Repositories;

namespace Application.CQRS.Handlers
{
    public class AddProjectChangeLogCommandHandler : ICommandHandler<AddProjectChangeLogCommand>
    {
        private readonly IDataRepository<ProjectChangeLog> _repository;

        public AddProjectChangeLogCommandHandler(IDataRepository<ProjectChangeLog> repository)
        {
            _repository = repository;
        }

        public void Handle(AddProjectChangeLogCommand command)
        {
            var changeLog = new ProjectChangeLog
            {
                ProjectId = command.ProjectId,
                ChangeDescription = command.ChangeDescription,
                ChangeDate = DateTime.UtcNow
            };

            _repository.Add(changeLog);
        }
    }
}
