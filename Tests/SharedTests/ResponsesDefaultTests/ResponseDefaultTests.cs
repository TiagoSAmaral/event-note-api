
using System.Text.Json;
using event_list.shared.response_default;
using Xunit;
using Moq;
using FluentAssertions;

namespace event_list.Tests.SharedTests.ResponsesDefaultTests;
public class ResponseDefaultTests
{
        [Fact]
        public void Constructor_WithValidParameters_ShouldInitializeProperties()
        {
            // Arrange
            int expectedStatus = 200;
            string expectedMessage = "Success";
            object expectedData = new { Id = 1, Name = "Test" };
        
            // Act
            var response = new ResponseDefault(expectedStatus, expectedMessage, expectedData);
        
            // Assert
            response.Status.Should().Be(expectedStatus);
            response.Message.Should().Be(expectedMessage);
            response.Data.Should().Be(expectedData);
        }
        
        [Fact]
        public void Constructor_WithNullData_ShouldInitializeWithNullData()
        {
            // Arrange
            int expectedStatus = 404;
            string expectedMessage = "Not Found";
            object? expectedData = null;
        
            // Act
            var response = new ResponseDefault(expectedStatus, expectedMessage, expectedData);
        
            // Assert
            response.Status.Should().Be(expectedStatus);
            response.Message.Should().Be(expectedMessage);
            response.Data.Should().BeNull();
        }
        
        [Fact]
        public void Constructor_WithEmptyMessage_ShouldInitializeWithEmptyMessage()
        {
            // Arrange
            int expectedStatus = 400;
            string expectedMessage = "";
            object expectedData = new { Error = "Bad Request" };
        
            // Act
            var response = new ResponseDefault(expectedStatus, expectedMessage, expectedData);
        
            // Assert
            response.Status.Should().Be(expectedStatus);
            response.Message.Should().BeEmpty();
            response.Data.Should().Be(expectedData);
        }
        
        [Fact]
        public void Constructor_WithZeroStatus_ShouldInitializeWithZeroStatus()
        {
            // Arrange
            int expectedStatus = 0;
            string expectedMessage = "Custom Status";
            object expectedData = new { Info = "Custom status code" };
        
            // Act
            var response = new ResponseDefault(expectedStatus, expectedMessage, expectedData);
        
            // Assert
            response.Status.Should().Be(0);
            response.Message.Should().Be(expectedMessage);
            response.Data.Should().Be(expectedData);
        }
        
        [Fact]
        public void Constructor_WithNegativeStatus_ShouldInitializeWithNegativeStatus()
        {
            // Arrange
            int expectedStatus = -1;
            string expectedMessage = "Error";
            object expectedData = new { Code = -1 };
        
            // Act
            var response = new ResponseDefault(expectedStatus, expectedMessage, expectedData);
        
            // Assert
            response.Status.Should().Be(-1);
            response.Message.Should().Be(expectedMessage);
            response.Data.Should().Be(expectedData);
        }
        
        [Fact]
        public void Constructor_WithComplexDataObject_ShouldInitializeCorrectly()
        {
            // Arrange
            int expectedStatus = 201;
            string expectedMessage = "Created";
            var complexData = new
            {
                Id = Guid.NewGuid(),
                Name = "Complex Object",
                Items = new List<string> { "Item1", "Item2" },
                Metadata = new { CreatedAt = DateTime.Now }
            };
        
            // Act
            var response = new ResponseDefault(expectedStatus, expectedMessage, complexData);
        
            // Assert
            response.Status.Should().Be(expectedStatus);
            response.Message.Should().Be(expectedMessage);
            response.Data.Should().BeEquivalentTo(complexData);
        }
        
        [Fact]
        public void Constructor_WithPrimitiveData_ShouldInitializeCorrectly()
        {
            // Arrange
            int expectedStatus = 200;
            string expectedMessage = "OK";
            int expectedData = 42;
        
            // Act
            var response = new ResponseDefault(expectedStatus, expectedMessage, expectedData);
        
            // Assert
            response.Status.Should().Be(expectedStatus);
            response.Message.Should().Be(expectedMessage);
            response.Data.Should().Be(expectedData);
        }
        
        [Fact]
        public void Constructor_WithStringData_ShouldInitializeCorrectly()
        {
            // Arrange
            int expectedStatus = 200;
            string expectedMessage = "Success";
            string expectedData = "Hello World";
        
            // Act
            var response = new ResponseDefault(expectedStatus, expectedMessage, expectedData);
        
            // Assert
            response.Status.Should().Be(expectedStatus);
            response.Message.Should().Be(expectedMessage);
            response.Data.Should().Be(expectedData);
        }
        
        [Fact]
        public void Constructor_WithCollectionData_ShouldInitializeCorrectly()
        {
            // Arrange
            int expectedStatus = 200;
            string expectedMessage = "List";
            var expectedData = new List<int> { 1, 2, 3, 4, 5 };
        
            // Act
            var response = new ResponseDefault(expectedStatus, expectedMessage, expectedData);
        
            // Assert
            response.Status.Should().Be(expectedStatus);
            response.Message.Should().Be(expectedMessage);
            response.Data.Should().BeEquivalentTo(expectedData);
        }
        
        [Fact]
        public void Properties_ShouldBeSettable()
        {
            // Arrange
            var response = new ResponseDefault(200, "Initial", null);
        
            // Act
            response.Status = 404;
            response.Message = "Updated";
            response.Data = new { Value = "New Data" };
        
            // Assert
            response.Status.Should().Be(404);
            response.Message.Should().Be("Updated");
            response.Data.Should().BeEquivalentTo(new { Value = "New Data" });
        }
        
        [Fact]
        public void DefaultPropertyValues_ShouldBeAsExpected()
        {
            // Arrange & Act
            var response = new ResponseDefault(0, "", null);
        
            // Assert
            response.Status.Should().Be(0);
            response.Message.Should().Be("");
            response.Data.Should().BeNull();
        }
        
        [Fact]
        public void MessageProperty_DefaultValue_ShouldBeEmptyString()
        {
            // Arrange
            var response = new ResponseDefault(200, "Test", null);
        
            // Act
            response.Message = string.Empty;
        
            // Assert
            response.Message.Should().BeEmpty();
            response.Message.Should().NotBeNull();
        }
        
        [Fact]
        public void DataProperty_CanBeSetToDifferentTypes()
        {
            // Arrange
            var response = new ResponseDefault(200, "Test", null);
        
            // Act & Assert - String
            response.Data = "String";
            response.Data.Should().Be("String");
        
            // Act & Assert - Number
            response.Data = 123;
            response.Data.Should().Be(123);
        
            // Act & Assert - Object
            var obj = new { Test = "Value" };
            response.Data = obj;
            response.Data.Should().BeEquivalentTo(obj);
        
            // Act & Assert - Null
            response.Data = null;
            response.Data.Should().BeNull();
        }
        
        [Fact]
        public void ToString_ShouldReturnMeaningfulRepresentation()
        {
            // Arrange
            var response = new ResponseDefault(200, "Success", new { Id = 1 });
        
            // Act
            var result = JsonSerializer.Serialize(response);
        
            // Assert
            result.Should().Contain("{\"Status\":200,\"Message\":\"Success\",\"Data\":{\"Id\":1}}");
        }
        
        [Fact]
        public void Instance_ShouldNotBeNull()
        {
            // Arrange & Act
            var response = new ResponseDefault(200, "Test", null);
        
            // Assert
            response.Should().NotBeNull();
        }
        
        [Fact]
        public void Constructor_WithVeryLongMessage_ShouldInitializeCorrectly()
        {
            // Arrange
            int expectedStatus = 200;
            string expectedMessage = new string('A', 1000); // Long message
            object expectedData = null;
        
            // Act
            var response = new ResponseDefault(expectedStatus, expectedMessage, expectedData);
        
            // Assert
            response.Status.Should().Be(expectedStatus);
            response.Message.Should().Be(expectedMessage);
            response.Message.Length.Should().Be(1000);
            response.Data.Should().BeNull();
        }
    }
