


using event_list.modules.eventlist.storage;
using Xunit;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace event_list.tests.ModulesTests.StorageTests;

    public class EventListDbContextTests
    {
        [Fact]
        public void Constructor_WithOptions_ShouldInitialize()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<EventListDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Db")
                .Options;

            // Act
            var dbContext = new EventListDbContext(options);

            // Assert
            dbContext.Should().NotBeNull();
            dbContext.Events.Should().NotBeNull();
        }

        [Fact]
        public void Events_Property_ShouldReturnDbSet()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<EventListDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Db")
                .Options;
            
            var dbContext = new EventListDbContext(options);

            // Act
            var eventsDbSet = dbContext.Events;

            // Assert
            eventsDbSet.Should().NotBeNull();
            eventsDbSet.Should().BeAssignableTo<DbSet<EventFormDto>>();
        }

        [Fact]
        public void ModelConfiguration_ShouldConfigureEventFormDtoEntityCorrectly()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<EventListDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Db")
                .Options;
            
            using var dbContext = new EventListDbContext(options);

            // Act - A configuração do modelo é aplicada automaticamente quando o contexto é criado
            var model = dbContext.Model;
            var entityType = model.FindEntityType(typeof(EventFormDto));

            // Assert
            entityType.Should().NotBeNull();

            // Verify primary key
            var primaryKey = entityType.FindPrimaryKey();
            primaryKey.Should().NotBeNull();
            primaryKey.Properties.Should().ContainSingle(p => p.Name == "Id");

            // Verify required properties
            var titleProperty = entityType.FindProperty("Title");
            titleProperty.Should().NotBeNull();
            titleProperty.IsNullable.Should().BeFalse();

            var descriptionProperty = entityType.FindProperty("Description");
            descriptionProperty.Should().NotBeNull();
            descriptionProperty.IsNullable.Should().BeFalse();

            var localeProperty = entityType.FindProperty("Locale");
            localeProperty.Should().NotBeNull();
            localeProperty.IsNullable.Should().BeFalse();
        }

        [Fact]
        public void CanAddAndRetrieveEvent_FromDbContext()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<EventListDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Db")
                .Options;
            
            using var dbContext = new EventListDbContext(options);
            var eventDto = new EventFormDto
            {
                Id = Guid.NewGuid(),
                Title = "Test Event",
                Description = "Test Description",
                Locale = "Test Locale"
            };

            // Act
            dbContext.Events.Add(eventDto);
            dbContext.SaveChanges();

            // Assert
            var savedEvent = dbContext.Events.Find(eventDto.Id);
            savedEvent.Should().NotBeNull();
            savedEvent.Title.Should().Be("Test Event");
            savedEvent.Description.Should().Be("Test Description");
            savedEvent.Locale.Should().Be("Test Locale");
            
            dbContext.Events.Remove(eventDto);
            dbContext.SaveChanges();
        }

        [Fact]
        public void DbContext_ShouldBeDisposable()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<EventListDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Db")
                .Options;
            
            // Act & Assert
            using (var dbContext = new EventListDbContext(options))
            {
                dbContext.Should().NotBeNull();
            }
            // Should not throw on disposal
        }

        [Fact]
        public void ModelConfiguration_ShouldEnforceRequiredFields()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<EventListDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Db")
                .Options;
            
            using var dbContext = new EventListDbContext(options);

            // Act & Assert - Should throw when required fields are null
            var invalidEvent = new EventFormDto
            {
                Id = Guid.NewGuid(),
                Title = null!, // Required field set to null
                Description = "Test Description",
                Locale = "Test Locale"
            };

            dbContext.Events.Add(invalidEvent);
            Action act = () => dbContext.SaveChanges();

            // Assert - Should throw due to required field violation
            act.Should().Throw<DbUpdateException>();
        }

        [Fact]
        public void Events_DbSet_ShouldBeQueryable()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<EventListDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Db")
                .Options;
            
            using var dbContext = new EventListDbContext(options);

            // Add some test data
            var event1 = new EventFormDto { Id = Guid.NewGuid(), Title = "Event 1", Description = "Desc 1", Locale = "Locale 1" };
            var event2 = new EventFormDto { Id = Guid.NewGuid(), Title = "Event 2", Description = "Desc 2", Locale = "Locale 2" };
            
            dbContext.Events.AddRange(event1, event2);
            dbContext.SaveChanges();

            // Act
            var results = dbContext.Events.Where(e => e.Title.Contains("Event")).ToList();

            // Assert
            results.Should().HaveCount(2);
            results.Should().Contain(e => e.Title == "Event 1");
            results.Should().Contain(e => e.Title == "Event 2");
        }

        [Fact]
        public void DbContext_ShouldSupportMultipleInstances()
        {
            // Arrange
            var options1 = new DbContextOptionsBuilder<EventListDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Db_1")
                .Options;
            
            var options2 = new DbContextOptionsBuilder<EventListDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Db_2")
                .Options;

            // Act
            var dbContext1 = new EventListDbContext(options1);
            var dbContext2 = new EventListDbContext(options2);

            // Assert
            dbContext1.Should().NotBeNull();
            dbContext2.Should().NotBeNull();
            dbContext1.Should().NotBeSameAs(dbContext2);
        }

        [Fact]
        public void Events_DbSet_ShouldAllowRemove()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<EventListDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Db")
                .Options;
            
            using var dbContext = new EventListDbContext(options);
            
            var eventDto = new EventFormDto
            {
                Id = Guid.NewGuid(),
                Title = "Test Event",
                Description = "Test Description",
                Locale = "Test Locale"
            };

            dbContext.Events.Add(eventDto);
            dbContext.SaveChanges();

            // Act
            var eventToRemove = dbContext.Events.Find(eventDto.Id);
            dbContext.Events.Remove(eventToRemove);
            dbContext.SaveChanges();

            // Assert
            var result = dbContext.Events.Find(eventDto.Id);
            result.Should().BeNull();
        }

        [Fact]
        public void Should_Handle_Concurrent_Access()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<EventListDbContext>()
                .UseInMemoryDatabase(databaseName: "Concurrent_Test_Db")
                .Options;

            // Act & Assert - Multiple contexts should work independently
            using (var context1 = new EventListDbContext(options))
            using (var context2 = new EventListDbContext(options))
            {
                var event1 = new EventFormDto { Id = Guid.NewGuid(), Title = "Event 1", Description = "Desc 1", Locale = "Locale 1" };
                var event2 = new EventFormDto { Id = Guid.NewGuid(), Title = "Event 2", Description = "Desc 2", Locale = "Locale 2" };

                context1.Events.Add(event1);
                context2.Events.Add(event2);

                context1.SaveChanges();
                context2.SaveChanges();

                // Both contexts should see both events after save
                context1.Events.Count().Should().Be(2);
                context2.Events.Count().Should().Be(2);
            }
        }

        [Fact]
        public void Should_Validate_Required_Properties_On_Save()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<EventListDbContext>()
                .UseInMemoryDatabase(databaseName: "Validation_Test_Db")
                .Options;
            
            using var dbContext = new EventListDbContext(options);

            // Test each required property individually
            var testCases = new[]
            {
                new { Property = "Title", Event = new EventFormDto { Id = Guid.NewGuid(), Title = null!, Description = "Test", Locale = "Test" } },
                new { Property = "Description", Event = new EventFormDto { Id = Guid.NewGuid(), Title = "Test", Description = null!, Locale = "Test" } },
                new { Property = "Locale", Event = new EventFormDto { Id = Guid.NewGuid(), Title = "Test", Description = "Test", Locale = null! } }
            };

            foreach (var testCase in testCases)
            {
                // Act & Assert
                dbContext.Events.Add(testCase.Event);
                Action act = () => dbContext.SaveChanges();
                act.Should().Throw<DbUpdateException>($"because {testCase.Property} is required");
                
                // Cleanup for next test
                dbContext.ChangeTracker.Clear();
            }
        }
    }