using event_list.modules.eventlist.services;
using event_list.modules.eventlist.storage;
using event_list.tests.Tests.Mocks;
using FluentAssertions;
using Moq;
using Xunit;

namespace event_list.tests.Tests.ModulesTests.ServicesTests;

public class EventListServicesTests
{ 
    private readonly Mock<IEventListDeleteByIdentifierService> _mockDeleteService;
    private readonly Mock<IEventListFetchByIdentifierService> _mockFetchByIdService;
    private readonly Mock<IEventListFetchService> _mockFetchService;
    private readonly Mock<IEventListSaveService> _mockSaveService;
    private readonly EventListServices _services;

    public EventListServicesTests()
    {
        _mockDeleteService = new Mock<IEventListDeleteByIdentifierService>();
        _mockFetchByIdService = new Mock<IEventListFetchByIdentifierService>();
        _mockFetchService = new Mock<IEventListFetchService>();
        _mockSaveService = new Mock<IEventListSaveService>();

        _services = new EventListServices(
            _mockDeleteService.Object,
            _mockFetchByIdService.Object,
            _mockFetchService.Object,
            _mockSaveService.Object
        );
    }

    [Fact]
    public void Constructor_WithValidDependencies_ShouldInitialize()
    {
        // Arrange & Act
        var services = new EventListServices(
            _mockDeleteService.Object,
            _mockFetchByIdService.Object,
            _mockFetchService.Object,
            _mockSaveService.Object
        );

        // Assert
        services.Should().NotBeNull();
    }

    [Fact]
    public async Task CreateAsync_ShouldCallSaveServiceAdd()
    {
        // Arrange
        var eventDto = new MockManager().GetEvents()!.First(); // new EventFormDto { Id = Guid.NewGuid(), Name = "Test Event" };

        // Act
        await _services.CreateAsync(eventDto);

        // Assert
        _mockSaveService.Verify(s => s.Add(eventDto), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallDeleteServiceDelete()
    {
        // Arrange
        var eventId = Guid.NewGuid();

        // Act
        await _services.DeleteAsync(eventId);

        // Assert
        _mockDeleteService.Verify(d => d.Delete(eventId), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_WithEmptyGuid_ShouldCallDeleteService()
    {
        // Arrange
        var emptyId = Guid.Empty;

        // Act
        await _services.DeleteAsync(emptyId);

        // Assert
        _mockDeleteService.Verify(d => d.Delete(emptyId), Times.Once);
    }

    [Fact]
    public void GetAll_ShouldCallFetchServiceFetch()
    {
        // Arrange
        var expectedEvents = new MockManager().GetEvents()!;
        
        _mockFetchService.Setup(f => f.Fetch()).Returns(expectedEvents);

        // Act
        var result = _services.GetAll();

        // Assert
        _mockFetchService.Verify(f => f.Fetch(), Times.Once);
        result.Should().BeEquivalentTo(expectedEvents);
    }

    [Fact]
    public void GetAll_WhenNoEvents_ShouldReturnEmptyCollection()
    {
        // Arrange
        var emptyEvents = Enumerable.Empty<EventFormDto>();
        _mockFetchService.Setup(f => f.Fetch()).Returns(emptyEvents);

        // Act
        var result = _services.GetAll();

        // Assert
        _mockFetchService.Verify(f => f.Fetch(), Times.Once);
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallFetchByIdServiceFetch()
    {
        // Arrange
        
        var expectedEvent = new MockManager().GetEvents()!.First();
        var eventId = expectedEvent.Id ?? Guid.NewGuid();
        
        _mockFetchByIdService.Setup(f => f.Fetch(eventId)).ReturnsAsync(expectedEvent);

        // Act
        var result = await _services.GetByIdAsync(eventId);

        // Assert
        _mockFetchByIdService.Verify(f => f.Fetch(eventId), Times.Once);
        result.Should().BeEquivalentTo(expectedEvent);
    }

    [Fact]
    public async Task GetByIdAsync_WithNonExistingId_ShouldReturnNull()
    {
        // Arrange
        var nonExistingId = Guid.NewGuid();
        _mockFetchByIdService.Setup(f => f.Fetch(nonExistingId)).ReturnsAsync((EventFormDto?)null);

        // Act
        var result = await _services.GetByIdAsync(nonExistingId);

        // Assert
        _mockFetchByIdService.Verify(f => f.Fetch(nonExistingId), Times.Once);
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetByIdAsync_WithEmptyGuid_ShouldCallFetchByIdService()
    {
        // Arrange
        var emptyId = Guid.Empty;
        _mockFetchByIdService.Setup(f => f.Fetch(emptyId)).ReturnsAsync((EventFormDto?)null);

        // Act
        var result = await _services.GetByIdAsync(emptyId);

        // Assert
        _mockFetchByIdService.Verify(f => f.Fetch(emptyId), Times.Once);
        result.Should().BeNull();
    }

    [Fact]
    public void GetAll_WhenFetchServiceReturnsNull_ShouldReturnEmptyCollection()
    {
        // Arrange
        _mockFetchService.Setup(f => f.Fetch()).Returns((IEnumerable<EventFormDto>?)null);

        // Act
        var result = _services.GetAll();

        // Assert
        _mockFetchService.Verify(f => f.Fetch(), Times.Once);
        result.Should().BeNullOrEmpty();
    }

    [Fact]
    public async Task CreateAsync_ShouldPropagateExceptionsFromSaveService()
    {
        // Arrange
        var eventDto = new MockManager().GetEvents()!.First();
        var expectedException = new InvalidOperationException("Database error");

        _mockSaveService.Setup(s => s.Add(eventDto)).ThrowsAsync(expectedException);

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() => _services.CreateAsync(eventDto));
        _mockSaveService.Verify(s => s.Add(eventDto), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ShouldPropagateExceptionsFromDeleteService()
    {
        // Arrange
        var eventId = Guid.NewGuid();
        var expectedException = new InvalidOperationException("Delete error");

        _mockDeleteService.Setup(d => d.Delete(eventId)).ThrowsAsync(expectedException);

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() => _services.DeleteAsync(eventId));
        _mockDeleteService.Verify(d => d.Delete(eventId), Times.Once);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldPropagateExceptionsFromFetchByIdService()
    {
        // Arrange
        var eventId = Guid.NewGuid();
        var expectedException = new InvalidOperationException("Fetch error");

        _mockFetchByIdService.Setup(f => f.Fetch(eventId)).ThrowsAsync(expectedException);

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() => _services.GetByIdAsync(eventId));
        _mockFetchByIdService.Verify(f => f.Fetch(eventId), Times.Once);
    }
}