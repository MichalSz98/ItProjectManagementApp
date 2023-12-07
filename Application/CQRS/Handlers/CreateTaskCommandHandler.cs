using Application.CQRS.Commands;
using AutoMapper;
using Domain.Repositories;

namespace Application.CQRS.Handlers
{
    public class CreateTaskCommandHandler
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;

        public CreateTaskCommandHandler(ITaskRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public int Handle(CreateTaskCommand command)
        {
            var task = _mapper.Map<Domain.Entities.Task>(command);

            _repository.Add(task);

            return task.Id;
        }
    }
}
