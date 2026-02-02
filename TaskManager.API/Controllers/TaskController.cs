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
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
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
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ProducesResponseType(typeof(TodoTask), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetTaskById(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Id não pode ser null ou vazio");

            var task = taskService.GetById(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TaskGetDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAllTask()
        {
            var tasks = taskService.GetAll();
            return Ok(tasks);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ProducesResponseType(typeof(TaskUpdateDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateTask(Guid id, [FromBody] TaskUpdateDTO taskUpdateDto)
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

            var updatedTask = taskService.Update(id, taskUpdateDto);
            if (updatedTask == null) return NotFound();
            return Ok(updatedTask);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteTask(Guid id)
        {
            taskService.DeleteById(id);
            return NoContent();
        }
    }
}
