using Day_26_DI_Testing_in_Dot_NET_Core.Controllers;
using Day_26_DI_Testing_in_Dot_NET_Core.Dtos;
using Day_26_DI_Testing_in_Dot_NET_Core.Models;
using Day_26_DI_Testing_in_Dot_NET_Core.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Day_26_Test_Case.Controller
{
    public class VendorControllerTests
    {

        private readonly Mock<IVendorRepository> _mockRepo;
        private readonly Mock<ILogger<VendorController>> _mockLogger;
        private readonly VendorController _controller;
        public VendorControllerTests()
        {
            _mockRepo = new Mock<IVendorRepository>();
            _mockLogger = new Mock<ILogger<VendorController>>();
            _controller = new VendorController(_mockRepo.Object, _mockLogger.Object);
        }

        //Get All vendors
        [Fact]
        public async Task GetAllVendors_ReturnsOk_WithList()
        {
            var fakeList = new List<VendorResponseDto>
            {
                new VendorResponseDto { Id = 1, BusinessName = "Niotechone Software Solutions", TaxId = "ABCD1234E", ContactEmail = "vendors@niotechone.com", CreditLimit = 45000, PaymentTerms = "Net30", OnboardedAt = DateTime.UtcNow },
                new VendorResponseDto { Id = 2, BusinessName = "TechFlow Automation Lab", TaxId = "XYZW9876K", ContactEmail = "billing@techflow.io", CreditLimit = 25000, PaymentTerms = "Net60", OnboardedAt = DateTime.UtcNow }
            };

            _mockRepo.Setup(m => m.GetallVendorsAsync()).ReturnsAsync(fakeList);
            var result = await _controller.GetAllVendors();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        //Get Vendor By Id
        [Fact]
        public async Task GetVendorById_ReturnsOk_WhenFound()
        {
            var fakeVendor = new VendorResponseDto { Id = 1, BusinessName = "Niotechone Software Solutions", TaxId = "ABCD1234E", ContactEmail = "vendors@niotechone.com", CreditLimit = 45000, PaymentTerms = "Net30", OnboardedAt = DateTime.UtcNow };

            _mockRepo.Setup(m => m.GetVendroByIdAsync(1)).ReturnsAsync(fakeVendor);
            var result = await _controller.GetVendorById(1);

            var okresult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okresult.Value);
        }

        [Fact]
        public async Task GetVendorById_ReturnsNotFound_WhenMissing()
        {
            _mockRepo.Setup(m => m.GetVendroByIdAsync(99)).ReturnsAsync((VendorResponseDto?)null);
            var result = await _controller.GetVendorById(99);
            Assert.IsType<NotFoundObjectResult>(result);
        }

        //Create a new Vendor
        [Fact]
        public async Task CreateVendor_ReturnsCreated()
        {
            var fakeVendorDto = new VendorRequestDto { BusinessName = "Niotechone Software Solutions", TaxId = "ABCD1234E", ContactEmail = "vendors@niotechone.com", CreditLimit = 45000, PaymentTerms = "Net30" };
            var fakeVendor = new VendorResponseDto { Id = 1, BusinessName = "Niotechone Software Solutions", TaxId = "ABCD1234E", ContactEmail = "vendors@niotechone.com", CreditLimit = 45000, PaymentTerms = "Net30", OnboardedAt = DateTime.UtcNow };

            _mockRepo.Setup(m => m.CreateVendorAsync(fakeVendorDto)).ReturnsAsync(fakeVendor);
            var result = await _controller.CreateVendor(fakeVendorDto);
            var createdAtAction = Assert.IsType<CreatedAtActionResult>(result);
            Assert.NotNull(createdAtAction);
        }

        //Update Vendor
        [Fact]
        public async Task UpdateVendor_ReturnsOk_WhenFound()
        {
            var fakeVendorDto = new VendorRequestDto { BusinessName = "Niotechone Software Solutions", TaxId = "ABCD1234E", ContactEmail = "vendors@niotechone.com", CreditLimit = 50000, PaymentTerms = "Net30" };
            var fakeVendor = new VendorResponseDto { Id = 1, BusinessName = "Niotechone Software Solutions", TaxId = "ABCD1234E", ContactEmail = "vendors@niotechone.com", CreditLimit = 50000, PaymentTerms = "Net30", OnboardedAt = DateTime.UtcNow };

            _mockRepo.Setup(m => m.UpdateVendorAsync(1, fakeVendorDto)).ReturnsAsync(fakeVendor);
            var result = await _controller.UpdateVendor(1, fakeVendorDto);
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task UpdateVendor_ReturnsNotFound_WhenMissing()
        {
            var fakeVendorDto = new VendorRequestDto { BusinessName = "Niotechone Software Solutions", TaxId = "ABCD1234E", ContactEmail = "vendors@niotechone.com", CreditLimit = 45000, PaymentTerms = "Net30" };
            _mockRepo.Setup(m => m.UpdateVendorAsync(99, fakeVendorDto)).ReturnsAsync((VendorResponseDto?)null);

            var result = await _controller.UpdateVendor(99, fakeVendorDto);
            Assert.IsType<NotFoundObjectResult>(result);
        }

        //Delete Vendor(soft delete)
        [Fact]
        public async Task DeleteVendor_ReturnsNoContent_WhenFound()
        {
            _mockRepo.Setup(m => m.DeleteVendorAsync(1)).ReturnsAsync(true);
            var result = await _controller.DeleteVendor(1);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteVendor_ReturnsNotFound_WhenMissing()
        {
            _mockRepo.Setup(m => m.DeleteVendorAsync(99)).ReturnsAsync(false);
            var result = await _controller.DeleteVendor(99);
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
