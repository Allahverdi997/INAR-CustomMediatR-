using CustomMediatr.Commands;
using CustomMediatr.MediatrLibrary.Interfaces;
using CustomMediatr.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomMediatr.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public INAM NAM { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, INAM inam,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            NAM = inam;
            UnitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var b = UnitOfWork;
            var a=NAM.Send<string>(new GetAllDepartmentQuery());
            
            var rng = new Random();
            return a.Result;
        }

        [HttpGet("A")]
        public async Task<string> GetA()
        {
            var a = NAM.Send<string>(new CreateCommand());

            var rng = new Random();
            return a.Result;
        }

        [HttpGet("getAll")]
        public List<string> GetAll()
        {
            return new List<string>() { "A","B","C","D","E"};
        }
        [HttpGet("get")]
        public List<string> Get()
        {
            return "A";
        }
    }
}
