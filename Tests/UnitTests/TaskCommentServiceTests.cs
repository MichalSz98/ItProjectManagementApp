using Application.Hexagonal.Services;
using AutoMapper;
using Domain.Exceptions;
using Domain.Repositories;
using NSubstitute;
using Task = Domain.Entities.Task;

namespace Tests.UnitTests
{
    [TestFixture]
    public class TaskCommentServiceUnitTests
    {
        [Test]
        public void AddComment_ShouldAddCommentToTask_WhenTaskExists()
        {
            // Arrange
            var repository = Substitute.For<IDataRepository<Task>>();
            var mapper = Substitute.For<IMapper>();

            var task = new Task();
            repository.GetById(Arg.Any<int>()).Returns(task);

            var commentService = new TaskCommentService(repository);

            // Act
            commentService.AddComment(1, "Nowy komentarz do zadania.");

            // Assert
            Assert.That(task.Comments.Count, Is.EqualTo(1));
            Assert.IsTrue(task.Comments.Select(x => x.Text).Contains("Nowy komentarz do zadania."));
            repository.Received(1).Update(task);
        }

        [Test]
        public void AddComment_ShouldThrowNotFoundException_WhenTaskDoesNotExist()
        {
            // Arrange
            var repository = Substitute.For<IDataRepository<Task>>();
            var mapper = Substitute.For<IMapper>();

            repository.GetById(Arg.Any<int>()).Returns((Task)null);

            // Act
            var service = new TaskCommentService(repository);

            Assert.Throws<NotFoundException>(() => service.AddComment(1, "Nowy komentarz do zadania."));
        }
    }
}