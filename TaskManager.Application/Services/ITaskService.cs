using TaskManager.Application.DTO.Task;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services
{
    public interface ITaskService
    {
        public TodoTask Create(TaskCreateDTO dto);
        public TodoTask GetById(Guid id);
        public List<TaskGetDTO> GetAll();
        public TodoTask? Update(Guid id, TaskUpdateDTO dto);
        public void DeleteById(Guid id);
    }
}
