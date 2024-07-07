using MontyHall.Controllers;
using MontyHall.Services;
using FakeItEasy;
using MontyHall.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MontyHall.Test
{
    public class SimulationControllerTest
    {
        [Fact]
        public  void SimulationController_SimulateGame_Return200()
        {
            //Arrange
            var service = A.Fake<IMontyHallSimulationService>();
            var controller = new SimulationController(service);

            var parameters = new SimulationParametersDto
            {
                NumberOfSimulations = 100,
                ChangeDoor = true
            };

            var expectedResults = new SimulationResultsDto
            {
                NumberOfWinsWithoutChanging = 100,
                NumberOfWinsWithChanging = 60,
            };

            A.CallTo(() => service.SimulateGames(parameters.NumberOfSimulations, parameters.ChangeDoor))
            .Returns(expectedResults);

            //Act
            var result =  controller.SimulateGames(parameters);

            //Asscert
            var okResult = result.Result as OkObjectResult;
            var returnValue = Assert.IsType<SimulationResultsDto>(okResult?.Value);
            Assert.Equal(expectedResults.NumberOfWinsWithoutChanging, returnValue.NumberOfWinsWithoutChanging);
            Assert.Equal(expectedResults.NumberOfWinsWithChanging, returnValue.NumberOfWinsWithChanging);
        }

        [Fact]
        public void SimulationController_Simulation_ReturnBadRequest()
        {
            // Arrange
            var service = A.Fake<IMontyHallSimulationService>();
            var controller = new SimulationController(service);

            // Simulate an invalid model state
            controller.ModelState.AddModelError("NumberOfSimulations", "The NumberOfSimulations field is required.");

            var parameters = new SimulationParametersDto
            {
            };

            // Act
            var result = controller.SimulateGames(parameters);

            // Assert
            var badRequestResult = result.Result as BadRequestObjectResult;
            var modelState = Assert.IsType<SerializableError>(badRequestResult!.Value);
            Assert.True(modelState.ContainsKey("NumberOfSimulations"));
        }

    }
}