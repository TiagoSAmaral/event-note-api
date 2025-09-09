using event_list.modules.eventlist.infra;
using event_list.modules.eventlist.services;
using event_list.modules.eventlist.storage;
using event_list.shared.exceptionsMessage;
using event_list.shared.response_default;
using event_list.tests.Tests.Mocks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace event_list.tests.ModulesTests.InfraTests;

public class EventListControllerTests
    {
        private readonly Mock<IEventListServices> _serviceMock;
        private readonly EventListController _controller;

        public EventListControllerTests()
        {
            _serviceMock = new Mock<IEventListServices>();
            _controller = new EventListController(_serviceMock.Object);
        }

        [Fact]
        public void GetAll_ShouldReturnListOfEvents()
        {
            // Arrange
            var events = new MockManager().GetEvents()!;// new List<EventFormDto> { "event1", "event2" };
            _serviceMock.Setup(s => s.GetAll()).Returns(events);

            // Act
            var result = _controller.GetAllAsync() as OkObjectResult;

            // Assert
            result.Should().NotBeNull();
            var response = result!.Value as ResponseDefault;
            response!.Data.Should().BeEquivalentTo(events);
            response.Status.Should().Be(200);
        }

        [Fact]
        public async Task GetById_ShouldReturnEvent()
        {
            // Arrange
            var eventId = Guid.NewGuid();
            var expectedEvent = new EventFormDto() { Id = eventId, Title = "Test Event" };
            _serviceMock.Setup(s => s.GetByIdAsync(eventId)).ReturnsAsync(expectedEvent);

            // Act
            var result = await _controller.GetById(eventId) as OkObjectResult;

            // Assert
            result.Should().NotBeNull();
            var response = result!.Value as ResponseDefault;
            response!.Data.Should().BeEquivalentTo(expectedEvent);
            response.Status.Should().Be(200);
        }

        [Fact]
        public async Task Create_ShouldCallServiceAndReturnSuccess()
        {
            // Arrange
            var dto = new EventFormDto { Title = "Novo Evento" };
            _serviceMock.Setup(s => s.CreateAsync(dto)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Create(dto) as OkObjectResult;

            // Assert
            result.Should().NotBeNull();
            var response = result!.Value as ResponseDefault;
            response!.Message.Should().Be(ExceptionsMessages.SuccessCreateEvent);
            _serviceMock.Verify(s => s.CreateAsync(dto), Times.Once);
        }

        [Fact]
        public async Task DeleteById_ShouldCallServiceAndReturnSuccess()
        {
            // Arrange
            var eventId = Guid.NewGuid();
            _serviceMock.Setup(s => s.DeleteAsync(eventId)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteById(eventId) as OkObjectResult;

            // Assert
            result.Should().NotBeNull();
            var response = result!.Value as ResponseDefault;
            response!.Message.Should().Be(ExceptionsMessages.SuccessDeleteEvent);
            _serviceMock.Verify(s => s.DeleteAsync(eventId), Times.Once);
        }

        [Fact]
        public async Task Create_ShouldReturnBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            var dto = new EventFormDto { Title = "" };
            _controller.ModelState.AddModelError("Title", "Required");

            // Act
            var result = await _controller.Create(dto);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
            _serviceMock.Verify(s => s.CreateAsync(It.IsAny<EventFormDto>()), Times.Never);
        }
    }