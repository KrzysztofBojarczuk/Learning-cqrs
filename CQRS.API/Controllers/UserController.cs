using AutoMapper;
using CQRS.APPLICATION.Dtos;
using CQRS.APPLICATION.Features.Employee.Commands;
using CQRS.APPLICATION.Features.Employee.Queries;
using CQRS.APPLICATION.Features.User.Commands;
using CQRS.APPLICATION.Features.User.Queries;
using CQRS.CORE.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(ISender sender, UserManager<AppUserEntity> userManager, IMapper mapper) : ControllerBase
    {
        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUserAsync()
        {
            var result = await sender.Send(new GetAllUserQuery());

            return Ok(result);
        }

        [HttpDelete("{appUserId}")]
        public async Task<IActionResult> DeleteEmployeeAsync([FromRoute] string appUserId)
        {
            var result = await sender.Send(new DeleteUserCommand(appUserId));

            return Ok(result);
        }
    }
}
