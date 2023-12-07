using Application.CQRS.Commands;

namespace Application.CQRS.Handlers
{
    public interface ICommandHandler<in TCommand> 
        where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
