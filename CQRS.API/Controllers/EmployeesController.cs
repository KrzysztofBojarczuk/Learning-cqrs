using AutoMapper;
using CQRS.APPLICATION.Commands;
using CQRS.APPLICATION.Dtos;
using CQRS.APPLICATION.Queries;
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
    public class EmployeesController(ISender sender, UserManager<AppUserEntity> userManager, IMapper mapper) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] EmployeeCreateDto employeeDto)
        {
            var userId = userManager.GetUserId(User);
            var appUserEntity = await userManager.FindByIdAsync(userId);

            var employeeEntity = mapper.Map<EmployeeEntity>(employeeDto);

            employeeEntity.AppUserId = userId;
            employeeEntity.AppUserEntity = appUserEntity;

            var result = await sender.Send(new AddEmployeeCommand(employeeEntity));

            return Ok(result);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            var employees = await sender.Send(new GetAllEmployeesQuery());

            var employeeDtos = mapper.Map<IEnumerable<EmployeeGetDto>>(employees);

            return Ok(employeeDtos);
        }

        [HttpGet("GetNumberOfEmployee")]
        public async Task<IActionResult> GetNumberOfEmployeesAsync()
        {
            var result = await sender.Send(new GetNumberOfEmployeesQuery());

            return Ok(result);
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployeeByIdAsync([FromRoute] Guid employeeId)
        {
            var result = await sender.Send(new GetEmployeeByIdQuery(employeeId));

            var employeeDtos = mapper.Map<EmployeeGetDto>(result);

            return Ok(employeeDtos);
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> UpdateEmployeeAsync([FromRoute] Guid employeeId, [FromBody] EmployeeCreateDto updateEmployeeDto)
        {
            var employeeEntity = mapper.Map<EmployeeEntity>(updateEmployeeDto);

            var result = await sender.Send(new UpdateEmployeeCommand(employeeId, employeeEntity));

            return Ok(result);
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteEmployeeAsync([FromRoute] Guid employeeId)
        {
            var result = await sender.Send(new DeleteEmployeeCommand(employeeId));

            return Ok(result);
        }
    }
}
