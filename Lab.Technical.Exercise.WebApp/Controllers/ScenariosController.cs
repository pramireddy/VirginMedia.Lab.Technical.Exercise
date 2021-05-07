using AutoMapper;
using Lab.Technical.Exercise.DataContracts;
using Lab.Technical.Exercise.Domain.Exceptions;
using Lab.Technical.Exercise.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Lab.Technical.Exercise.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScenariosController : ControllerBase
    {
        private readonly IScenarioService _scenarioService;
        private readonly IMapper _mapper;

        public ScenariosController(IScenarioService scenarioService, IMapper mapper)
        {
            _scenarioService = scenarioService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ScenarioDto), StatusCodes.Status200OK)]
        public ActionResult<ScenarioDto> Get()
        {
            var scenarioEntities = _scenarioService.GetScenarios();

            var scenarios = _mapper.Map<IEnumerable<ScenarioDto>>(scenarioEntities);

            return Ok(scenarios);
        }

        [HttpGet]
        [Route("[action]/{userId}")]
        [ProducesResponseType(typeof(ScenarioDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        public ActionResult<ScenarioDto> ByUserId(string userId)
        {
            if (String.IsNullOrEmpty(userId))
            {
                return new BadRequestObjectResult
                    (
                        new Error
                        {
                            ErrorCode = "Invaliad UserId",
                            ErrorDescription = "Invalid UserId"
                        }
                    );
            }
            var scenarioEntity = _scenarioService.GetScenarioByUserId(userId);

            if (scenarioEntity == null)
            {
                throw new NotFoundException($"Scenario was not found for userId {userId}");
            }

            var scenarioDto = _mapper.Map<ScenarioDto>(scenarioEntity);
            return Ok(scenarioDto);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        [ProducesResponseType(typeof(ScenarioDto), StatusCodes.Status200OK)]
        public ActionResult<ScenarioDto> ByScenarioId(long id)
        {
            var scenarioEntity = _scenarioService.GetScenarioById(id);
            var scenarioDto = _mapper.Map<ScenarioDto>(scenarioEntity);
            return Ok(scenarioDto);
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(ScenarioDto), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ScenarioDto>> ByCreationDateRange([FromQuery] DateTime dateFrom, DateTime dateTo)
        {
            var scenarioEntities = _scenarioService.GetScenariosByCreationDateRange(dateFrom, dateTo);
            var scenarios = _mapper.Map<IEnumerable<ScenarioDto>>(scenarioEntities);
            return Ok(scenarios);
        }
    }
}