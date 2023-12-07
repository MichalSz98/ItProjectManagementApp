using ItProjectManagementApp.Enums;
using TaskStatus = ItProjectManagementApp.Enums.TaskStatus;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItProjectManagementApp.Entities
{
    public class Task
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // TODO USUNĄĆ
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskPriority Priority { get; set; }
        public TaskStatus Status { get; set; }
        public TaskType Type { get; set; }
        public bool IsUserStory { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public int? UserStoryId { get; set; }
        public virtual Task UserStory { get; set; }
        public List<Task> SubTasks { get; set; }
    }
}