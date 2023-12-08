using Domain.Enums;
using TaskStatus = Domain.Enums.TaskStatus;

namespace Domain.Entities
{
    public class Task : Entity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public TaskPriority Priority { get; private set; }
        public TaskStatus Status { get; private set; }
        public TaskType Type { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public bool IsUserStory => Type == TaskType.UserStory;

        public int ProjectId { get; private set; }
        public virtual Project Project { get; private set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }

        public int? UserStoryId { get; private set; }
        public virtual Task UserStory { get; private set; }
        public List<Task> SubTasks { get; private set; }

        public Task(string title, string description, TaskPriority priority, TaskStatus status, TaskType type, DateTime? startDate, DateTime? endDate)
        {
            Title = title;
            Description = description;
            Priority = priority;
            Status = status;
            Type = type;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void SetUserId(int userId)
        {
            UserId = userId;
        }
    }
}
