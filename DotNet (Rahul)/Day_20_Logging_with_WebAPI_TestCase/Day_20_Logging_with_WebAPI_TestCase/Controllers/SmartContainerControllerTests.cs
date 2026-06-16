using Day_20_Logging_with_WebAPI.Controllers;
using Day_20_Logging_with_WebAPI.Dtos;
using Day_20_Logging_with_WebAPI.Models;
using Day_20_Logging_with_WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Day_20_Logging_with_WebAPI_TestCase.Controllers
{
    public class SmartContainerControllerTests
    {
        private readonly Mock<ISmartContainerServices> _mockService;
        private readonly Mock<ILogger<SmartContainerController>> _mockLogger;
        private readonly SmartContainerController _controller;

        public SmartContainerControllerTests()
        {
            _mockService = new Mock<ISmartContainerServices>();
            _mockLogger = new Mock<ILogger<SmartContainerController>>();
            _controller = new SmartContainerController(_mockService.Object, _mockLogger.Object);
        }

        //Get All SmartContainer Test case
        [Fact]
        public async Task GetAllSmartContainer_ReturnsOk_WithList()
        {
            var fakeList = new List<SmartContainer>
            {
                new SmartContainer { Id = 1, TelemetryCode = "CON-BOM-1234", CurrentTemperature = -18.5m, HumidityPercentage = 45, DestinationPort = "Mumbai Port" },
                new SmartContainer { Id = 2, TelemetryCode = "CON-RTM-5678",CurrentTemperature = 4.2m, HumidityPercentage = 60, DestinationPort = "Rotterdam Port" }
            };

            _mockService.Setup(x => x.GetAllSmartContainers()).ReturnsAsync(fakeList);
            var result = await _controller.GetAllSmartContainer();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        //Get SmartContainer By Id Test case
        [Fact]
        public async Task GetSmartContainerById_ReturnsOk_WhenFound()
        {
            var fakeContainer = new SmartContainer { Id = 1, TelemetryCode = "CON-BOM-1234", CurrentTemperature = -18.5m, HumidityPercentage = 45, DestinationPort = "Mumbai Port" };
            _mockService.Setup(x => x.GetSmartContainerById(1)).ReturnsAsync(fakeContainer);

            var result = await _controller.GetSmartContainerById(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task GetSmartContainerById_ReturnsNotFound_WhenMissing()
        {
            _mockService.Setup(x => x.GetSmartContainerById(99)).ReturnsAsync((SmartContainer?)null);
            var result = await _controller.GetSmartContainerById(99);

            Assert.IsType<NotFoundObjectResult>(result);
        }

        //Create SmartContainer Test case
        [Fact]
        public async Task CreateSmartContainer_ReturnsCreated()
        {
            var fakeContainerDto = new SmartContainerDto { TelemetryCode = "CON-BOM-1234", CurrentTemperature = -18.5m, HumidityPercentage = 45, DestinationPort = "Mumbai Port" };

            var fakeContainer = new SmartContainer { Id = 1, TelemetryCode = "CON-BOM-1234", CurrentTemperature = -18.5m, HumidityPercentage = 45, DestinationPort = "Mumbai Port" };

            _mockService.Setup(x => x.CreateSmartContainer(fakeContainerDto)).ReturnsAsync(fakeContainer);
            var result = await _controller.CreateSmartContainer(fakeContainerDto);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.NotNull(createdAtActionResult);
        }

        //Update SmartContainer Test case
        [Fact]
        public async Task UpdateSmartContainer_ReturnsOk_WhenFound()
        {
            // Arrange
            var fakeDto = new SmartContainerDto { TelemetryCode = "CON-BOM-1234", CurrentTemperature = -18.5m, HumidityPercentage = 45, DestinationPort = "Mumbai Port" };
            var fakeUpdated = new SmartContainer { Id = 1, TelemetryCode = "CON-BOM-1234", CurrentTemperature = -18.5m, HumidityPercentage = 45, DestinationPort = "Mumbai Port" };

            _mockService.Setup(x => x.UpdateSmartContainer(1, fakeDto)).ReturnsAsync(fakeUpdated);

            var result = await _controller.UpdateSmartContainer(1, fakeDto);
            var okresult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okresult);
        }

        [Fact]
        public async Task UpdateSmartContainer_ReturnsNotFound_WhenMissing()
        {
            var fakeDto = new SmartContainerDto { TelemetryCode = "CON-BOM-1234", CurrentTemperature = -18.5m, HumidityPercentage = 45, DestinationPort = "Mumbai Port" };

            _mockService.Setup(x => x.UpdateSmartContainer(999, fakeDto)).ReturnsAsync((SmartContainer?)null);
            var result = await _controller.UpdateSmartContainer(999, fakeDto);
            Assert.IsType<NotFoundObjectResult>(result);
        }

        //Delete SmartContainer Test case
        [Fact]
        public async Task DeleteSmartContainer_ReturnsNoContent_WhenFound()
        {
            var fakeContainer = new SmartContainer { Id = 1, TelemetryCode = "CON-BOM-1234", CurrentTemperature = -18.5m, HumidityPercentage = 45, DestinationPort = "Mumbai Port" };

            _mockService.Setup(x => x.DeleteSmartContainerById(1)).ReturnsAsync(true);
            var result = await _controller.DeleteSmartContainer(1);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteSmartContainer_ReturnsNotFound_WhenMissing()
        {
            _mockService.Setup(x => x.DeleteSmartContainerById(99)).ReturnsAsync(false);

            var result = await _controller.DeleteSmartContainer(99);
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
