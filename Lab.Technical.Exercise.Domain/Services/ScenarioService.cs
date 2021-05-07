using Lab.Technical.Exercise.Domain.Configuration;
using Lab.Technical.Exercise.Domain.EntityModels;
using Lab.Technical.Exercise.Domain.Interfaces.Repositories;
using Lab.Technical.Exercise.Domain.Interfaces.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab.Technical.Exercise.Domain.Services
{
    public class ScenarioService : IScenarioService
    {
        private readonly DataSettings _dataSettings;
        private readonly IScenarioRepository _scenarioRepository;

        public ScenarioService(IOptions<DataSettings> options, IScenarioRepository scenarioRepository)
        {
            _dataSettings = options.Value;
            _scenarioRepository = scenarioRepository;
        }

        public Scenario GetScenarioById(long id)
        {
            var scenarios = _scenarioRepository.GetScenarios(_dataSettings.Location);
            return scenarios.FirstOrDefault(x => x.ScenarioID == id);
        }

        public Scenario GetScenarioByUserId(string userId)
        {
            var scenarios = _scenarioRepository.GetScenarios(_dataSettings.Location);
            return scenarios.FirstOrDefault(x => x.UserID == userId);
        }

        public IEnumerable<Scenario> GetScenarios()
        {
            return _scenarioRepository.GetScenarios(_dataSettings.Location);
        }

        public IEnumerable<Scenario> GetScenariosByCreationDateRange(DateTime dateFrom, DateTime dateTo)
        {
            if (DateTime.Now > dateFrom)
            {
                var scenarios = _scenarioRepository.GetScenarios(_dataSettings.Location);

                if (dateFrom == dateTo)
                {
                    return scenarios.Where(x => x.CreationDate >= dateFrom && x.CreationDate < dateTo.AddDays(1));
                }
                return scenarios.Where(x => x.CreationDate >= dateFrom && x.CreationDate < dateTo);
            }

            return new List<Scenario>();
        }
    }
}