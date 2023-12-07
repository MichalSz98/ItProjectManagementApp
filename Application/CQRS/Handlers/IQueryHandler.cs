using Application.CQRS.Queries;

namespace Application.CQRS.Handlers
{
    public interface IQueryHandler<in TQuery, out TResponse> 
        where TQuery : IQuery
    {
        TResponse Handle(TQuery query);
    }
}
