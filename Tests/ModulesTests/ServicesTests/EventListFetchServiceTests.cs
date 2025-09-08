

using event_list.modules.eventlist.services;
using event_list.modules.eventlist.storage;
using event_list.tests.Tests.Mocks;
using Xunit;
using Moq;
using FluentAssertions;

namespace event_list.tests.Tests.ModulesTests.ServicesTests;

public class EventListFetchServiceTests
{
    private readonly Mock<IEventListStorage> _mockStorage;
    private readonly EventListFetchService _service;
    
    public EventListFetchServiceTests()
    {
        _mockStorage = new Mock<IEventListStorage>();
        _service = new EventListFetchService(_mockStorage.Object);
    }

    [Fact]
    public void FetchEvents_WhenFounded()
    {
        // Arrange
        var expectedEvents = new MockManager().GetEvents()!;

        _mockStorage
            .Setup(request => request.GetAllAsync())
            .Returns(expectedEvents);
        
        // Act
        var response = _service.Fetch();
        
        // Assert
        response.Should().NotBeNull();
        response.Count().Should().Be(expectedEvents.Count);
        response.First().Id.Should().Be(expectedEvents.First().Id);
    }
}