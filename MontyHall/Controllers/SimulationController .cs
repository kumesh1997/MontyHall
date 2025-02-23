﻿using Microsoft.AspNetCore.Mvc;
using MontyHall.Services;
using MontyHall.DTO;

namespace MontyHall.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SimulationController : Controller
    {
        private readonly IMontyHallSimulationService _simulationService;
        
        public SimulationController(IMontyHallSimulationService simulationService)
        {
            _simulationService = simulationService;
        }

        [HttpPost("simulate")]
        public ActionResult<SimulationResultsDto> SimulateGames([FromBody] SimulationParametersDto parameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var results = _simulationService.SimulateGames(parameters.NumberOfSimulations, parameters.ChangeDoor);
            return Ok(results);
        }
    }
}
