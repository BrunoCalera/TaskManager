using TaskManager.Domain.Enums;

namespace TaskManager.Application.DTO.Task
{
    public class TaskGetDTO
    {
        public string Name { get; set; } = string.Empty;
        public Priority Priority { get; set; }
        public DateTime DueDate { get; set; }
        public Status Status { get; set; }
    }
}
