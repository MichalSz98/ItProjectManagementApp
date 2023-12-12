using Application.CQRS.Queries;
using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Application.CQRS.Handlers
{
    public class GetProjectChangeLogQueryHandler : IQueryHandler<GetProjectChangeLogQuery, IEnumerable<ProjectChangeLogDto>>
    {
        private readonly IDataRepository<ProjectChangeLog> _repository;
        private readonly IMapper _mapper;

        public GetProjectChangeLogQueryHandler(IDataRepository<ProjectChangeLog> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<ProjectChangeLogDto> Handle(GetProjectChangeLogQuery query)
        {
            var projectChangeLogs = _repository
                .GetAll(x => x.ProjectId == query.ProjectId);

            return _mapper.Map<List<ProjectChangeLogDto>>(projectChangeLogs);
        }
    }
}
