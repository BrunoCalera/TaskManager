using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Contracts;
using TaskManager.Application.DTO.Task;
using TaskManager.Application.Services;
using TaskManager.Domain.Entities;

namespace TaskManager.API.Controllers
{
    public class TaskController(ITaskService taskService) : TaskManagerController
    {
        [HttpPost]
        [ProducesResponseType(typeof(TaskCreateDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
        public IActionResult CreateTask([FromBody] TaskCreateDTO taskCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ValidationErrorResponse
                {
                    Title = "Erro de validação",
                    Status = 400,
                    Errors = ModelState.ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value!.Errors.Select(e => e.ErrorMessage).ToArray()
                    )
                });
            }
            
            var response = taskService.Create(taskCreateDto);
            return CreatedAtAction(nameof(GetById), new { id = response });
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(TodoTask), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetById(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Id não pode ser null ou vazio");

            var task = taskService.GetById(id);
            if (task == null) return NotFound();
            return Ok(task);
        }
    }
}
