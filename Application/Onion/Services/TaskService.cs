using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Task = Domain.Entities.Task;

namespace Application.Onion.Services
{
    public class TaskService
    {
        private readonly IDataRepository<Task> _repository;

        public TaskService(IDataRepository<Task> repository)
        {
            _repository = repository;
        }

        public void AddComment(int taskId, string commentText)
        {
            var task = _repository.GetById(taskId);

            if (task == null)
            {
                throw new NotFoundException("Task not found.");
            }

            var comment = new Comment(commentText);

            task.AddComment(comment);

            _repository.Update(task);
        }

        //public IEnumerable<CommentDto> GetComments(int taskId)
        //{
        //    var task = _repository.GetById(taskId, p => p.Comments);

        //    if (task == null)
        //    {
        //        throw new NotFoundException("Task not found.");
        //    }

        //    var commentsDto = _mapper.Map<List<CommentDto>>(task.Comments);

        //    return commentsDto;
        //}
    }
}
