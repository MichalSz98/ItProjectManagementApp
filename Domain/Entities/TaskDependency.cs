namespace Domain.Entities
{
    public class TaskDependency
    {
        public int TaskId { get; set; }
        public Task Task { get; set; }

        public int DependentOnId { get; set; }
        public Task DependentOn { get; set; }
    }
}
