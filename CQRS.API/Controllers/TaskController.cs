using AutoMapper;
using CQRS.APPLICATION.Dtos;
using CQRS.APPLICATION.Features.Employee.Commands;
using CQRS.APPLICATION.Features.Employee.Queries;
using CQRS.APPLICATION.Features.Task.Commands;
using CQRS.CORE.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskController(ISender sender, UserManager<AppUserEntity> userManager, IMapper mapper) : ControllerBase
    {
        [HttpGet("user")]
        public async Task<IActionResult> GetUserTaskssAsync()
        {
            var userId = userManager.GetUserId(User);

            var result = await sender.Send(new GetUserTasksQuery(userId));

            var employeeDtos = mapper.Map<IEnumerable<TaskGetDto>>(result);

            return Ok(employeeDtos);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddTaskAsync([FromBody] TaskCreateDto taskDto)
        {
            var userId = userManager.GetUserId(User);
            var appUserEntity = await userManager.FindByIdAsync(userId);

            var taskEntity = mapper.Map<TaskEntity>(taskDto);

            taskEntity.AppUserId = userId;
            taskEntity.AppUserEntity = appUserEntity;

            var result = await sender.Send(new AddTaskCommand(taskEntity));

            return Ok(result);
        }
    }
}
