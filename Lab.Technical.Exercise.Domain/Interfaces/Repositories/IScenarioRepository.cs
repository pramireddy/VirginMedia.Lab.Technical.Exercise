using Lab.Technical.Exercise.Domain.EntityModels;
using System.Collections.Generic;

namespace Lab.Technical.Exercise.Domain.Interfaces.Repositories
{
    public interface IScenarioRepository
    {
        IEnumerable<Scenario> GetScenarios(string dataFileLocation);
    }
}