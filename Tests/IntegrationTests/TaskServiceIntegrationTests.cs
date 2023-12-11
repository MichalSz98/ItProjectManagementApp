using Application.Hexagonal.Services;
using Application.Onion.Services;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Entities.Task;

namespace Tests
{
    [TestFixture]
    public class TaskServiceIntegrationTests
    {
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