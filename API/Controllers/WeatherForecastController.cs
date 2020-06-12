using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly DataContext _context;

        private WeatherForecastController(DataContext context)
        {
            _context = context;
        }

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("weatherforcast")]
        public ActionResult <IEnumerable<WeatherForcast>> Get()
        {
            var WeatherForecast = _context.WeatherForcasts.ToList();

            return Ok(WeatherForecast);
           
        }

          [HttpGet  ("{Id}")] 
        public async Task <ActionResult <WeatherForcast>> Get(int Id)
        {
            var WeatherForecast = await _context.WeatherForcasts.FindAsync(Id);

            return Ok(WeatherForecast);
           
        }
    }
}
