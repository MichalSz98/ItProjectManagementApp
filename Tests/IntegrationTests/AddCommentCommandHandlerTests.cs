using Application.CQRS.Commands;
using Application.CQRS.Handlers;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Entities.Task;

namespace Tests
{
    public class AddCommentCommandHandlerIntegrationTests
    {
        [Test]
        public void ShouldPersistCommentToDatabase()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseSqlServer("Server=localhost\\SQLEXPRESS;" +
                "Database=ProjectDb;Trusted_Connection=True;" +
                "TrustServerCertificate=True")
                .Options;

            using (var context = new ApplicationContext(options))
            {
                var repository = new EfGenericRepository<Task>(context);

                var handler = new AddCommentCommandHandler(repository);

                handler.Handle(new AddCommentCommand { TaskId = 1, CommentText = "Nowy komentarz do zadania." });

                var task = repository.GetById(1);
                Assert.IsTrue(task.Comments.Select(x => x.Text).Contains("Nowy komentarz do zadania."));
            }
        }
    }
}