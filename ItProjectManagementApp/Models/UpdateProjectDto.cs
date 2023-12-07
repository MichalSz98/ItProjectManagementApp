using System.ComponentModel.DataAnnotations;

namespace ItProjectManagementApp.Models
{
    public class UpdateProjectDto
    {
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
    }
}
