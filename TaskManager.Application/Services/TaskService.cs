using AutoMapper;
using TaskManager.Application.DTO.Task;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services
{
    public sealed class TaskService(IMapper mapper) : ITaskService
    {

        private static List<TodoTask> _tasks = new List<TodoTask>();

        public TodoTask Create(TaskCreateDTO dto)
        {
            var task = mapper.Map<TodoTask>(dto);
            _tasks.Add(task);
            return task;
        }

        public TodoTask GetById(Guid id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public List<TaskGetDTO> GetAll()
        {
            return mapper.Map<List<TaskGetDTO>>(_tasks);
        }

        public TodoTask? Update(Guid id, TaskUpdateDTO dto)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return null;
            mapper.Map(dto, task);
            return task;
        }

        public void DeleteById(Guid id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                _tasks.Remove(task);
            }
        }
    }
}
