using AutoMapper;
using TaskManager.Application.DTO.Task;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services
{
    public sealed class TaskService(IMapper mapper) : ITaskService
    {

        private static List<TodoTask> tasks = new List<TodoTask>();

        public Guid Create(TaskCreateDTO dto)
        {
            var task = mapper.Map<TodoTask>(dto);
            tasks.Add(task);
            return task.Id;
        }

        public TodoTask GetById(Guid id)
        {
            return tasks.FirstOrDefault(t => t.Id == id);
        }
    }
}
