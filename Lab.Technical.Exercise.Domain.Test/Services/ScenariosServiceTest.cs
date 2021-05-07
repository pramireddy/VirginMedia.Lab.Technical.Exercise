using FluentAssertions;
using Lab.Technical.Exercise.Domain.Configuration;
using Lab.Technical.Exercise.Domain.EntityModels;
using Lab.Technical.Exercise.Domain.Interfaces.Repositories;
using Lab.Technical.Exercise.Domain.Interfaces.Services;
using Lab.Technical.Exercise.Domain.Services;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Lab.Technical.Exercise.Domain.Test.Services
{
    public class ScenariosServiceTest
    {
        private readonly Mock<IScenarioRepository> _mockScenarioRepository;
        private readonly Mock<IOptions<DataSettings>> _mockDataSettings;

        public ScenariosServiceTest()
        {
            _mockScenarioRepository = new Mock<IScenarioRepository>();
            _mockScenarioRepository.Setup(x => x.GetScenarios(It.IsAny<string>())).Returns(ScenariosTestData());

            _mockDataSettings = new Mock<IOptions<DataSettings>>();
            _mockDataSettings.Setup(x => x.Value).Returns(new DataSettings { Location = @"C:\temp\data.xml" });
        }

        [Fact]
        public void Should_return_scenarios()
        {
            // Arrange
            IScenarioService scenarioService = new ScenarioService(_mockDataSettings.Object, _mockScenarioRepository.Object);

            // Act
            var scenarios = scenarioService.GetScenarios();

            // Assert
            scenarios.Should().NotBeEmpty();
            scenarios.Count().Should().Be(6);
        }

        [Fact]
        public void Should_fetch_scenarios_for_given_creation_date_range()
        {
            // Arrange
            IScenarioService scenarioService = new ScenarioService(_mockDataSettings.Object, _mockScenarioRepository.Object);
            var dateFrom = DateTime.Now.AddDays(-1);
            var dateTo = DateTime.Now;

            // Act
            var scenarios = scenarioService.GetScenariosByCreationDateRange(dateFrom, dateTo)
;
            // Assert
            scenarios.Should().NotBeEmpty();
            scenarios.Count().Should().Be(3);
        }

        [Theory]
        [InlineData("6F55DFD1-A235-4BAE-B958-C1A0AB4D5232", "6F55DFD1-A235-4BAE-B958-C1A0AB4D5232")]
        [InlineData("ECA4A6AA-72FF-4885-9BEB-5B040FC5EF5C", "ECA4A6AA-72FF-4885-9BEB-5B040FC5EF5C")]
        public void Should_fetch_scenario_when_getscenariobyuserid_called_and_userid_exists(string userId, string expectedResult)
        {
            // Arrange
            IScenarioService scenarioService = new ScenarioService(_mockDataSettings.Object, _mockScenarioRepository.Object);

            // Act
            var scenario = scenarioService.GetScenarioByUserId(userId)
;
            // Assert
            scenario.UserID.Should().Be(expectedResult);
            scenario.Should().NotBeNull();
        }

        [Theory]
        [InlineData(12345678, 12345678)]
        [InlineData(2, 2)]
        public void Should_fetch_scenario_when_getscenariobyid_called_and_scenarioid_exists(long scenarioId, long expectedId)
        {
            // Arrange
            IScenarioService scenarioService = new ScenarioService(_mockDataSettings.Object, _mockScenarioRepository.Object);

            // Act
            var scenario = scenarioService.GetScenarioById(scenarioId)
;
            // Assert
            scenario.ScenarioID.Should().Be(expectedId);
            scenario.Should().NotBeNull();
        }

        [Theory]
        [InlineData("6F55DFD1-A235-4BAE-B958-C1A0AB4D5238")]
        [InlineData("ECA4A6AA-72FF-4885-9BEB-5B040FC5EF59")]
        public void Should_retrun_null_when_getscenariobyuserid_called_and_userid_not_exists(string userId)
        {
            // Arrange
            IScenarioService scenarioService = new ScenarioService(_mockDataSettings.Object, _mockScenarioRepository.Object);

            // Act
            var scenario = scenarioService.GetScenarioByUserId(userId)
;
            // Assert
            scenario.Should().BeNull();
        }

        private IEnumerable<Scenario> ScenariosTestData()
        {
            var scenarios = new List<Scenario>
            {
                new Scenario
                {
                    ScenarioID = 1,
                    Name = "Scenario1",
                    Forename= "EDWARD",
                    Surname= "BALDWIN",
                    NetworkLayerID= "1",
                    NumMonths= 12,
                    SampleDate= DateTime.Now,
                    CreationDate= DateTime.Now,
                    MarketID= "2",
                    UserID= "6F55DFD1-A235-4BAE-B958-C1A0AB4D5231"
                },
                new Scenario
                {
                    ScenarioID = 2,
                    Name = "Scenario2",
                    Forename= "EDWARD",
                    Surname= "BALDWIN",
                    NetworkLayerID= "1",
                    NumMonths= 12,
                    SampleDate= DateTime.Now,
                    CreationDate= DateTime.Now,
                    MarketID= "2",
                    UserID= "6F55DFD1-A235-4BAE-B958-C1A0AB4D5232"
                },
                new Scenario
                {
                    ScenarioID = 12345678,
                    Name = "Scenario3",
                    Forename= "EDWARD",
                    Surname= "BALDWIN",
                    NetworkLayerID= "1",
                    NumMonths= 12,
                    SampleDate= DateTime.Now,
                    CreationDate= DateTime.Now.AddDays(-1),
                    MarketID= "2",
                    UserID= "6F55DFD1-A235-4BAE-B958-C1A0AB4D5233"
                },
                new Scenario
                {
                    ScenarioID = 4,
                    Name = "Scenario4",
                    Forename= "EDWARD",
                    Surname= "BALDWIN",
                    NetworkLayerID= "1",
                    NumMonths= 12,
                    SampleDate= DateTime.Now,
                    CreationDate= DateTime.Now.AddDays(-2),
                    MarketID= "2",
                    UserID= "6F55DFD1-A235-4BAE-B958-C1A0AB4D5234"
                },
                new Scenario
                {
                    ScenarioID = 5,
                    Name = "Scenario5",
                    Forename= "EDWARD",
                    Surname= "BALDWIN",
                    NetworkLayerID= "1",
                    NumMonths= 12,
                    SampleDate= DateTime.Now,
                    CreationDate= DateTime.Now,
                    MarketID= "2",
                    UserID= "6F55DFD1-A235-4BAE-B958-C1A0AB4D5235"
                },
                new Scenario
                {
                    ScenarioID = 6,
                    Name = "Scenario7",
                    Forename= "EDWARD",
                    Surname= "BALDWIN",
                    NetworkLayerID= "1",
                    NumMonths= 12,
                    SampleDate= DateTime.Now,
                    CreationDate= DateTime.Now.AddDays(-3),
                    MarketID= "2",
                    UserID= "ECA4A6AA-72FF-4885-9BEB-5B040FC5EF5C"
                }
            };

            return scenarios;
        }
    }
}