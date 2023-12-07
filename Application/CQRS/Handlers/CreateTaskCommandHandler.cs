using Application.CQRS.Commands;
using AutoMapper;
using Domain.Repositories;
using Task = Domain.Entities.Task;

namespace Application.CQRS.Handlers
{
    public class CreateTaskCommandHandler
    {
        private readonly IDataRepository<Task> _repository;
        private readonly IMapper _mapper;

        public CreateTaskCommandHandler(IDataRepository<Task> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public int Handle(CreateTaskCommand command)
        {
            var task = _mapper.Map<Task>(command);

            _repository.Add(task);

            return task.Id;
        }
    }
}
