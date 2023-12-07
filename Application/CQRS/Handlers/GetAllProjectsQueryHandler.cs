using Application.CQRS.Queries;
using Application.Dtos;
using AutoMapper;
using Domain.Repositories;

namespace Application.CQRS.Handlers
{
    public class GetAllProjectsQueryHandler
    {
        private readonly IProjectRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProjectsQueryHandler(IProjectRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<ProjectDto> Handle(GetAllProjectsQuery query)
        {
            var projects = _repository.GetAll();

            var projectsDtos = _mapper.Map<List<ProjectDto>>(projects);

            return projectsDtos;
        }
    }
}
