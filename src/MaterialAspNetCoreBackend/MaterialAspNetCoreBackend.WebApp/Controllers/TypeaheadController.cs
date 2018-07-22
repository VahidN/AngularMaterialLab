using System;
using System.Threading.Tasks;
using MaterialAspNetCoreBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace MaterialAspNetCoreBackend.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class TypeaheadController : Controller
    {
        private readonly IUsersService _usersService;

        public TypeaheadController(IUsersService usersService)
        {
            _usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> SearchUsers(string term)
        {
            return Ok(await _usersService.SearchUsersAsync(term));
        }
    }
}