using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MaterialAspNetCoreBackend.WebApp.Controllers
{
    public class UserInfo
    {
        // public DateTimeOffset BirthDate { set; get; }
        public DateTime BirthDate { set; get; }
    }

    [Route("api/[controller]")]
    public class PersianDatepickerController : Controller
    {
        private readonly ILogger<PersianDatepickerController> _logger;

        public PersianDatepickerController(ILogger<PersianDatepickerController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody]UserInfo model)
        {
            _logger.LogInformation($"model.BirthDate: {model.BirthDate}");
            return Ok(model.BirthDate);
        }
    }
}