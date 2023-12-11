using Task = Domain.Entities.Task;

namespace Tests.UnitTests
{
    public class TaskWritable : Task
    {
        public Task WithId(int id) { Id = id; return this; }
    }
}