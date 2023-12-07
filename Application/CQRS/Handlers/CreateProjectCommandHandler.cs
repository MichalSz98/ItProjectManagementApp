using Application.CQRS.Commands;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Application.CQRS.Handlers
{
    public class CreateProjectCommandHandler : BaseHandler
    {
        private readonly IProjectRepository _repository;
        private readonly IMapper _mapper;

        public CreateProjectCommandHandler(IProjectRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public int Handle(CreateProjectCommand command)
        {
            var project = _mapper.Map<Project>(command);

            _repository.Add(project);

            return project.Id;
        }
    }
}
