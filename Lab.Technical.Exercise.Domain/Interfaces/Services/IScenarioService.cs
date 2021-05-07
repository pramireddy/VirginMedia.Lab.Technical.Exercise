using Lab.Technical.Exercise.Domain.EntityModels;
using System;
using System.Collections.Generic;

namespace Lab.Technical.Exercise.Domain.Interfaces.Services
{
    public interface IScenarioService
    {
        IEnumerable<Scenario> GetScenarios();

        Scenario GetScenarioByUserId(string userId);

        Scenario GetScenarioById(long id);

        IEnumerable<Scenario> GetScenariosByCreationDateRange(DateTime dateFrom, DateTime dateTo);
    }
}