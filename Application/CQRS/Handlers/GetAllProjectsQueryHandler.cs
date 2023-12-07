using Application.CQRS.Queries;
using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Application.CQRS.Handlers
{
    public class GetAllProjectsQueryHandler : IQueryHandler<GetAllProjectsQuery, IEnumerable<ProjectDto>>
    {
        private readonly IDataRepository<Project> _repository;
        private readonly IMapper _mapper;

        public GetAllProjectsQueryHandler(IDataRepository<Project> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<ProjectDto> Handle(GetAllProjectsQuery query)
        {
            var projects = _repository.GetAll(project => project.Tasks);

            var projectsDtos = _mapper.Map<List<ProjectDto>>(projects);

            return projectsDtos;
        }
    }
}
