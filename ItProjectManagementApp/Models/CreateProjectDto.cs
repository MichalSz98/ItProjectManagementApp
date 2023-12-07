using System.ComponentModel.DataAnnotations;

namespace ItProjectManagementApp.Models
{
    public class CreateProjectDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
