namespace Application.Dtos
{
    public class TaskWithCommentsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<CommentDto> Comments { get; set; }
    }
}
