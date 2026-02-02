using TaskManager.Application.DTO.Task;

namespace TaskManager.Application.Services
{
    public interface ITaskService
    {
        public Guid Create(TaskCreateDTO dto);
    }
}
