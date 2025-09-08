
using event_list.modules.eventlist.services;
using event_list.modules.eventlist.storage;
using event_list.shared.exceptionsMessage;
using Xunit;
using Moq;
using FluentAssertions;

namespace event_list.tests.Tests.ModulesTests.ServicesTests;

public class EventListFetchByIdentifierServiceTests
{
    private readonly Mock<IEventListStorage> _mockStorage;
    private readonly EventListFetchByIdentifierService _service;

    public EventListFetchByIdentifierServiceTests()
    {
        _mockStorage = new Mock<IEventListStorage>();
        _service = new EventListFetchByIdentifierService(_mockStorage.Object);
    }

    [Fact]
    public async Task FetchEventListByIdentifier_ShouldReturnEvent_WhenFounded()
    {
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

        var response = await _service.Fetch(mockGuid);
        
        response.Should().NotBeNull();
        response.Title.Should().Be("Festa da Bananada!");
    }
    
    [Fact]
    public async Task FetchEventListByIdentifier_ShouldReturnNull_WhenIdIsInvalid()
    {
        var mockGuid = Guid.NewGuid();
        _mockStorage.Setup(request => request.GetByIdAsync(mockGuid)).ReturnsAsync((EventFormDto?)null);
        
        Func<Task> action = async () => await _service.Fetch(mockGuid);
        
        // Assert
        await action.Should().ThrowAsync<KeyNotFoundException>().WithMessage(ExceptionsMessages.EventNotFounded);
    }
}