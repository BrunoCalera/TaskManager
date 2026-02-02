using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Contracts;
using TaskManager.Application.DTO.Task;
using TaskManager.Application.Services;

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
            return CreatedAtAction(string.Empty, new { id = response });
        }
    }
}
