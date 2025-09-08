using event_list.modules.eventlist.services;
using event_list.modules.eventlist.storage;
using event_list.shared.exceptionsMessage;
using Xunit;
using Moq;
using FluentAssertions;
using Xunit.Abstractions;

namespace event_list.Tests.ModulesTests.ServicesTests;

public class EventListSaveServiceTestes
{
    private readonly Mock<IEventListStorage> _mockStorage;
    private readonly EventListSaveService _service;
    
    private readonly ITestOutputHelper _output;

    public EventListSaveServiceTestes(ITestOutputHelper output)
    {
        _mockStorage = new Mock<IEventListStorage>();
        _service = new EventListSaveService(_mockStorage.Object);
        _output = output;
    }

    [Fact]
    public async Task SaveNewEvent_WhenIsValid()
    {
        // Arrange
        var expectedEvent = new MockManager().GetEvents()!.First();
        
        _mockStorage
            .Setup(request => request.CreateAsync(It.IsAny<EventFormDto>()))
            .Returns(Task.FromResult(expectedEvent));
        
        _mockStorage
            .Setup(request => request.GetByIdAsync(expectedEvent.Id ?? Guid.Empty))
            .ReturnsAsync(expectedEvent);
        
        if (expectedEvent?.Id == null)
        {
            Assert.Fail("Event Id not found");
            return;
        }

        var expectedGuid = expectedEvent!.Id ?? Guid.Empty;
        
        // Act
        await _service.Add(expectedEvent);
        var result = await _mockStorage.Object.GetByIdAsync(expectedGuid);
        
        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(expectedEvent.Id);
    }
}