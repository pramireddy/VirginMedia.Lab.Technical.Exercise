using System;

namespace Lab.Technical.Exercise.DataContracts
{
    public class ScenarioDto
    {
        public long ScenarioId { get; set; }
        public string Name { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string NetworkLayerId { get; set; }
        public int NumberOfMonths { get; set; }
        public DateTime SampleDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string MarketId { get; set; }
        public string UserId { get; set; }
    }
}