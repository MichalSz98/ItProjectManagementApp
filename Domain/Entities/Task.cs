using Domain.Enums;
using System.Threading.Tasks;
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

        public bool IsCompleted => Status == TaskStatus.Completed;
        public virtual List<TaskDependency> Dependencies { get; private set; }

        public virtual List<Comment> Comments { get; private set; }

        public Task() {
            Comments = new List<Comment>();
        }

        public Task(string title, string description, TaskPriority priority, TaskStatus status, TaskType type, DateTime? startDate, DateTime? endDate)
        {
            Title = title;
            Description = description;
            Priority = priority;
            Status = status;
            Type = type;
            StartDate = startDate;
            EndDate = endDate;
            SubTasks = new List<Task>();
            Dependencies = new List<TaskDependency>();
            Comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            if (comment == null)
                throw new ArgumentNullException(nameof(comment));

            Comments.Add(comment);
        }

        public void AddSubtask(Task task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            if (!SubTasks.Any(d => d.Id == task.Id))
            {
                SubTasks.Add(task);
            }
        }

        public void AddDependency(Task task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            if (!Dependencies.Any(d => d.DependentOnId == task.Id))
            {
                Dependencies.Add(new TaskDependency { DependentOn = task });
            }
        }

        public bool CanStart()
        {
            return Dependencies.All(d => d.DependentOn.IsCompleted);
        }

        public void SetUserId(int userId)
        {
            UserId = userId;
        }
    }
}
