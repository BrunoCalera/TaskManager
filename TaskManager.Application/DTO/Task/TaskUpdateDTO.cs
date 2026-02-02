using System.ComponentModel.DataAnnotations;
using TaskManager.Application.Common.Validation;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.DTO.Task
{
    public class TaskUpdateDTO
    {
        [Required(ErrorMessage = "O campo Name é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo Name não pode ter mais de 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "O campo Description não pode ter mais de 500 caracteres")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Priority é obrigatório")]
        [EnumValue(typeof(Priority), ErrorMessage = "Priority inválido")]
        public Priority Priority { get; set; }

        [Required(ErrorMessage = "O campo DueDate é obrigatório")]
        [FutureDate(ErrorMessage = "A DueDate não pode ser no passado")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "O campo Status é obrigatório")]
        [EnumValue(typeof(Status), ErrorMessage = "Status inválido")]
        public Status Status { get; set; }
    }
}
