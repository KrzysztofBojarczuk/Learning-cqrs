using AutoMapper;
using CQRS.CORE.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController(ISender sender, UserManager<AppUserEntity> userManager, IMapper mapper) : ControllerBase
    {
    }
}
