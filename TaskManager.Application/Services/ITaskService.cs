using TaskManager.Application.DTO.Task;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services
{
    public interface ITaskService
    {
        public Guid Create(TaskCreateDTO dto);
        public TodoTask GetById(Guid id);
    }
}
