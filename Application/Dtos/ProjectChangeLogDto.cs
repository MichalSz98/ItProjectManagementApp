using Domain.Entities;

namespace Application.Dtos
{
    public class ProjectChangeLogDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string ChangeDescription { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
