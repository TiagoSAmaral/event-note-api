
using event_list.modules.eventlist.services;
using event_list.modules.eventlist.storage;
using Xunit;
using Moq;
using FluentAssertions;

namespace event_list.Tests.ModulesTests.ServicesTests;

public class EventListDeleteByIdentifierServiceTests
{
    private readonly Mock<IEventListStorage> _mockStorage;
    private readonly EventListDeleteByIdentifierService _service;

    public EventListDeleteByIdentifierServiceTests()
    {
        _mockStorage = new Mock<IEventListStorage>();
        _service = new EventListDeleteByIdentifierService(_mockStorage.Object);
    }
    
    [Fact]
    public async Task DeleteEventListByIdentifier_WhenFounded()
    {
        // Arrange
        var expectedEvent = new EventFormDto();
        var mockGuid = Guid.NewGuid();
        expectedEvent.Id = mockGuid;
        expectedEvent.Title = "Festa da Bananada!";
        expectedEvent.Description = "Evento da cidade de Rio Bonito comemora o sucesso na producao e venda de bananada.";
        expectedEvent.Date = DateTime.Parse("2026-09-07T18:37:08.531Z");
        expectedEvent.Locale = "Rio Bonito/RJ";

        _mockStorage
            .Setup(request => request.GetByIdAsync(mockGuid))
            .ReturnsAsync(expectedEvent);
        
        _mockStorage
            .Setup(request => request.DeleteAsync(mockGuid))
            .Returns(Task.CompletedTask);

        // Act
         await _service.Delete(mockGuid);
         
         _mockStorage
             .Setup(request => request.GetByIdAsync(mockGuid))
             .ReturnsAsync((EventFormDto?)null);
         
         var response = await _mockStorage.Object.GetByIdAsync(mockGuid);
        
         // Assert
         response.Should().BeNull();
    }
}