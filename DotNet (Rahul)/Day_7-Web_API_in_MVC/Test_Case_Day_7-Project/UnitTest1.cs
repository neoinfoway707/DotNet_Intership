using Day_7_Web_API_in_MVC.API.Controllers;
using Day_7_Web_API_in_MVC.Application.Dto;
using Day_7_Web_API_in_MVC.Application.Interface;
using Day_7_Web_API_in_MVC.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Security.AccessControl;

namespace Test_Case_Day_7_Project
{
    public class UnitTest1
    {
        private readonly Mock<IServerRepo> _mockRepo; public readonly ServersController _controller;

        public UnitTest1()
        {
            _mockRepo = new Mock<IServerRepo>();
            _controller = new ServersController(_mockRepo.Object);
        }

        //Get All Server
        [Fact]
        public async Task GetAll_ReturnsOk_WithListOfServers()
        {
            var fakeServer = new List<Server>
            {
                new Server { Id = 1, Name = "Server1", IpAddress = "192.168.1.1", RamGb = 8, IsOnline = true },
                new Server { Id = 2, Name = "Server2", IpAddress = "192.168.1.2", RamGb = 16, IsOnline = false }
            };
            _mockRepo.Setup(r => r.GetAll()).ReturnsAsync(fakeServer);

            var result = await _controller.GetAllServer();

            var okresult = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsType<List<Server>>(okresult.Value);
            Assert.Equal(2, data.Count);
        }


        //Get Server By Id
        [Fact]
        public async Task GetById_ReturnsOk_WithListOfServers()
        {
            var fakeServer = new Server { Id = 1, Name = "Server1", IpAddress = "192.168.1.1", RamGb = 8, IsOnline = true };

            _mockRepo.Setup(r => r.GetById(1)).ReturnsAsync(fakeServer);
            var result = await _controller.GetServerById(1);

            var okresult = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsType<Server>(okresult.Value);
            Assert.Equal(1, data.Id);
        }

        [Fact]
        public async Task GetById_ReturnsNotFound_WhenServerNotExists()
        {
            _mockRepo.Setup(r => r.GetById(99)).ReturnsAsync((Server?)null);
            var result = await _controller.GetServerById(99);

            Assert.IsType<NotFoundObjectResult>(result);
        }

        //Add Server
        [Fact]
        public async Task AddServer_ReturnsOk_WhenServerAdded()
        {
            var dto = new ServerDto { Name = "Server1", IpAddress = "192.168.1.1", RamGb = 8, IsOnline = true };
            var fakeServer = new Server { Id = 1, Name = "Server1", IpAddress = "192.168.1.1", RamGb = 8, IsOnline = true };

            _mockRepo.Setup(r => r.AddServer(dto)).ReturnsAsync(fakeServer);

            var result = await _controller.AddServer(dto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task AddServer_ReturnsConflict_WhenIpAlreadyExists()
        {
            var dto = new ServerDto { Name = "Server1", IpAddress = "192.168.1.1", RamGb = 8, IsOnline = true };
            _mockRepo.Setup(r => r.AddServer(dto)).ReturnsAsync((Server?)null);

            var result = await _controller.AddServer(dto);

            Assert.IsType<ConflictObjectResult>(result);
        }

        //Update Server
        [Fact]
        public async Task UpdateServer_ReturnsOk_WhenServerUpdated()
        {
            var dto = new ServerDto { Name = "Updated", IpAddress = "192.168.1.10", RamGb = 16, IsOnline = true };
            var updatedServer = new Server { Id = 1, Name = "Updated", IpAddress = "192.168.1.10", RamGb = 16, IsOnline = true };

            _mockRepo.Setup(r => r.UpdateServer(1, dto)).ReturnsAsync(updatedServer);
            var result = await _controller.UpdateServer(1, dto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }


        [Fact]
        public async Task UpdateServer_ReturnsBadRequest_WhenIdIsZeroOrNegative()
        {
            var dto = new ServerDto { Name = "Updated", IpAddress = "192.168.1.10", RamGb = 16, IsOnline = true };

            var result = await _controller.UpdateServer(0, dto);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task UpdateServer_ReturnsNotFound_WhenServerNotExists()
        {
            var dto = new ServerDto { Name = "Updated", IpAddress = "192.168.1.10", RamGb = 16, IsOnline = true };

            _mockRepo.Setup(r => r.UpdateServer(99, dto)).ReturnsAsync((Server?)null);

            _mockRepo.Setup(r=> r.GetById(99)).ReturnsAsync((Server?)null);

            var result = await _controller.UpdateServer(99, dto);

            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task UpdateServer_ReturnsConflict_WhenIpAlreadyExistsOnAnotherServer()
        {
            var dto = new ServerDto { Name = "Updated", IpAddress = "192.168.1.10", RamGb = 16, IsOnline = true };
            var existingServer = new Server { Id = 1, Name = "Server1", IpAddress = "192.168.1.1", RamGb = 8, IsOnline = true };

            _mockRepo.Setup(r => r.UpdateServer(1, dto)).ReturnsAsync((Server?)null);
            _mockRepo.Setup(r=>r.GetById(1)).ReturnsAsync(existingServer);

            var result = await _controller.UpdateServer(1, dto);

            Assert.IsType<ConflictObjectResult>(result);
        }

        //Delete Server
        [Fact]
        public async Task DeleteServer_ReturnsOk_WhenServerDeleted()
        {
            var fakeServer = new Server { Id = 1, Name = "Server1", IpAddress = "192.168.1.1", RamGb = 8, IsOnline = true };

            _mockRepo.Setup(r => r.DeleteServer(1)).ReturnsAsync(fakeServer);

            var result = await _controller.DeleteServer(1);
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task DeleteServer_ReturnsNotFound_WhenServerNotExists()
        {
            _mockRepo.Setup(r => r.DeleteServer(99)).ReturnsAsync((Server?)null);

            var result = await _controller.DeleteServer(99);

            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task DeleteServer_ReturnsBadRequest_WhenIdIsZeroOrNegative()
        {
            var result = await _controller.DeleteServer(0);

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
