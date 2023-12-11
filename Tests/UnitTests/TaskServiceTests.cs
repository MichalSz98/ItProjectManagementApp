using Application.Hexagonal.Services;
using Application.Onion.Services;
using AutoMapper;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Task = Domain.Entities.Task;

namespace Tests.UnitTests
{
    [TestFixture]
    public class TaskServiceTests
    {
        // Test jednostkowy
        [Test]
        public void AddComment_ShouldAddCommentToTask_WhenTaskExists()
        {
            // Arrange
            var repository = Substitute.For<IDataRepository<Task>>();

            var task = new Task();
            repository.GetById(Arg.Any<int>()).Returns(task);

            var taskService = new TaskService(repository);

            // Act
            taskService.AddComment(1, "Nowy komentarz do zadania.");

            // Assert
            Assert.IsTrue(task.Comments.Select(x => x.Text).Contains("Nowy komentarz do zadania."));
            repository.Received(1).Update(task);
        }

        // Test integracyjny
        [Test]
        public void AddComment_ShouldPersistCommentToDatabase()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                 .UseSqlServer("Server=localhost\\SQLEXPRESS;" +
                 "Database=ProjectDb;Trusted_Connection=True;" +
                 "TrustServerCertificate=True")
                 .Options;

            using (var context = new ApplicationContext(options))
            {
                var repository = new EfGenericRepository<Task>(context);

                var taskService = new TaskService(repository);
                taskService.AddComment(1, "Nowy komentarz do zadania.");

                var task = repository.GetById(1);
                Assert.IsTrue(task.Comments.Select(x => x.Text).Contains("Nowy komentarz do zadania."));
            }
        }
    }
}