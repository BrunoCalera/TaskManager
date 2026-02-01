using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.VisualBasic;
using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Entities
{
    public class Task
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O campo Name é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo Name não pode ter mais de 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "O campo Description não pode ter mais de 500 caracteres")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Priority é obrigatório")]
        public Priority Priority { get; set; }

        [Required(ErrorMessage = "O campo DueDate é obrigatório")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "O campo Status é obrigatório")]
        public Status Status { get; set; }
    }
}
