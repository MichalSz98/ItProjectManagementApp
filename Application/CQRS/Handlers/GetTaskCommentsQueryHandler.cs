using Application.CQRS.Commands;
using Application.CQRS.Queries;
using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Task = Domain.Entities.Task;

namespace Application.CQRS.Handlers
{
    public class GetTaskCommentsQueryHandler : IQueryHandler<GetTaskCommentsQuery, IEnumerable<CommentDto>>
    {
        private readonly IDataRepository<Task> _repository;
        private readonly IMapper _mapper;

        public GetTaskCommentsQueryHandler(IDataRepository<Task> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<CommentDto> Handle(GetTaskCommentsQuery query)
        {
            var task = _repository.GetById(query.TaskId, p => p.Comments);

            if (task == null)
            {
                throw new NotFoundException("Task not found.");
            }

            var commentsDto = _mapper.Map<List<CommentDto>>(task.Comments);

            return commentsDto;
        }
    }
}
