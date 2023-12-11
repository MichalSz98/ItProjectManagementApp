using Application.CQRS.Commands;
using Application.CQRS.Handlers;
using Domain.Repositories;
using NSubstitute;
using Task = Domain.Entities.Task;

namespace Tests.UnitTests
{
    [TestFixture]
    public class AddCommentCommandHandlerUnitTests
    {
        [Test]
        public void ShouldAddCommentToTaskWhenTaskExists()
        {
            // Arrange
            var repository = Substitute.For<IDataRepository<Task>>();
            
            var task = new Task();
            repository.GetById(Arg.Any<int>()).Returns(task);
            
            var handler = new AddCommentCommandHandler(repository);

            // Act
            handler.Handle(new AddCommentCommand { TaskId = 1, CommentText = "Nowy komentarz do zadania." });

            // Assert
            Assert.That(task.Comments.Count, Is.EqualTo(1));
            Assert.That(task.Comments.First().Text, Is.EqualTo("Nowy komentarz do zadania."));
        }
    }
}