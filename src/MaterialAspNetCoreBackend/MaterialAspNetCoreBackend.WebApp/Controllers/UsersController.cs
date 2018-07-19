using System;
using System.Threading.Tasks;
using MaterialAspNetCoreBackend.DomainClasses;
using MaterialAspNetCoreBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace MaterialAspNetCoreBackend.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _usersService.GetAllUsersIncludeNotesAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _usersService.GetUserIncludeNotesAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _usersService.AddUserAsync(user);
            return Created("", user);
        }
    }
}