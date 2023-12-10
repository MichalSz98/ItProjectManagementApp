using Domain.Enums;
using TaskStatus = Domain.Enums.TaskStatus;

namespace Domain.Entities
{
    public class Comment : Entity
    {
        public string Text { get; private set; }

        public int TaskId { get; private set; }
        public virtual Task Task { get; private set; }

        public Comment(string text)
        {
            this.Text = text;
        }
    }
}
