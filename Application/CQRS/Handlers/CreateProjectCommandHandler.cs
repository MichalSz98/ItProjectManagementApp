using Application.CQRS.Commands;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Application.CQRS.Handlers
{
    public class CreateProjectCommandHandler : ICommandHandler<CreateProjectCommand>
    {
        private readonly IDataRepository<Project> _repository;
        private readonly IMapper _mapper;

        public CreateProjectCommandHandler(IDataRepository<Project> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Handle(CreateProjectCommand command)
        {
            var project = _mapper.Map<Project>(command);

            _repository.Add(project);
        }
    }
}
