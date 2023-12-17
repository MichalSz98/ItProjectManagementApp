using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Domain.Ports
{
    // Port
    public interface IProjectChangeLogTracker
    {
        void AddProjectChangeLog(int projectId, string changeDescription);
        IEnumerable<ProjectChangeLogDto> GetProjectChangeLog(int projectId);
    }

    // Adapter (Serwis)
    public class ProjectChangeLogService : IProjectChangeLogTracker
    {
        private readonly IDataRepository<ProjectChangeLog> _repository;
        private readonly IMapper _mapper;   

        public ProjectChangeLogService(IDataRepository<ProjectChangeLog> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AddProjectChangeLog(int projectId, string changeDescription)
        {
            var changeLog = new ProjectChangeLog
            {
                ProjectId = projectId,
                ChangeDescription = changeDescription,
                ChangeDate = DateTime.UtcNow
            };

            _repository.Add(changeLog);
        }

        public IEnumerable<ProjectChangeLogDto> GetProjectChangeLog(int projectId)
        {
            var projectChangeLogs = _repository
                .GetAll(x => x.ProjectId == projectId);

            return _mapper.Map<List<ProjectChangeLogDto>>(projectChangeLogs);
        }
    }

}
