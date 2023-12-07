using System.ComponentModel.DataAnnotations.Schema;

namespace ItProjectManagementApp.Entities
{
    public class Project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // TODO USUNĄĆ
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual List<Task> Tasks { get; set; }
    }
}
