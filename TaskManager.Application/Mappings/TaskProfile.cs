using AutoMapper;
using TaskManager.Application.DTO.Task;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Mappings
{
    public sealed class AssemblyReference
    {
    }

    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskCreateDTO, TodoTask>();
            CreateMap<TodoTask, TaskGetDTO> ();
            CreateMap<TaskUpdateDTO, TodoTask>();
        }
    }
}
