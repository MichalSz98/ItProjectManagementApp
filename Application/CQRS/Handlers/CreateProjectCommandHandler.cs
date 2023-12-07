using Application.CQRS.Commands;
using Domain.Entities;
using Domain.Repositories;

namespace Application.CQRS.Handlers
{
    public class CreateProjectCommandHandler
    {
        private readonly IProjectRepository _repository;

        public CreateProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public int Handle(CreateProjectCommand command)
        {
            var project = new Project(command.Name,
                                      command.Description,
                                      command.StartDate,
                                      command.EndDate);

            _repository.Add(project);

            return project.Id;
        }
    }
}
