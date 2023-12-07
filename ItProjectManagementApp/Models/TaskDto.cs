using TaskStatus = ItProjectManagementApp.Enums.TaskStatus;
using ItProjectManagementApp.Enums;

namespace ItProjectManagementApp.Models
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskPriority Priority { get; set; }
        public TaskStatus Status { get; set; }
        public TaskType Type { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsUserStory => Type == TaskType.UserStory;
    }
}
