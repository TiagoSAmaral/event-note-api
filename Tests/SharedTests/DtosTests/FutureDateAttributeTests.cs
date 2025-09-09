using System.ComponentModel.DataAnnotations;
using event_list.shared.dtos;
using FluentAssertions;
using Xunit;

namespace event_list.tests.SharedTests.DtosTests;

    public class FutureDateAttributeTests
    {
        private readonly FutureDateAttribute _attribute;

        public FutureDateAttributeTests()
        {
            _attribute = new FutureDateAttribute();
        }

        [Fact]
        public void IsValid_WithFutureDate_ShouldReturnTrue()
        {
            // Arrange
            var futureDate = DateTime.UtcNow.AddDays(1);

            // Act
            var result = _attribute.IsValid(futureDate);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsValid_WithCurrentDate_ShouldReturnFalse()
        {
            // Arrange
            var currentDate = DateTime.UtcNow;

            // Act
            var result = _attribute.IsValid(currentDate);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WithPastDate_ShouldReturnFalse()
        {
            // Arrange
            var pastDate = DateTime.UtcNow.AddDays(-1);

            // Act
            var result = _attribute.IsValid(pastDate);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WithNullValue_ShouldReturnFalse()
        {
            // Arrange
            object? nullValue = null;

            // Act
            var result = _attribute.IsValid(nullValue);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WithNonDateTimeValue_ShouldReturnFalse()
        {
            // Arrange
            var nonDateTimeValue = "not a date";

            // Act
            var result = _attribute.IsValid(nonDateTimeValue);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WithDifferentObjectTypes_ShouldReturnFalse()
        {
            // Arrange
            var objects = new object[]
            {
                123, // int
                123.45, // double
                Guid.NewGuid(), // Guid
                new object(), // object
                TimeSpan.FromHours(1) // TimeSpan
            };

            foreach (var obj in objects)
            {
                // Act
                var result = _attribute.IsValid(obj);

                // Assert
                result.Should().BeFalse($"because {obj.GetType().Name} is not DateTime");
            }
        }

        [Fact]
        public void IsValid_WithDateTimeMinValue_ShouldReturnFalse()
        {
            // Arrange
            var minDate = DateTime.MinValue;

            // Act
            var result = _attribute.IsValid(minDate);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WithDateTimeMaxValue_ShouldReturnTrue()
        {
            // Arrange
            var maxDate = DateTime.MaxValue;

            // Act
            var result = _attribute.IsValid(maxDate);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsValid_WithDateTimeNow_ShouldReturnFalse()
        {
            // Arrange
            var now = DateTime.Now; // Local time

            // Act
            var result = _attribute.IsValid(now);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WithDateTimeToday_ShouldReturnFalse()
        {
            // Arrange
            var today = DateTime.Today; // Date part only

            // Act
            var result = _attribute.IsValid(today);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WithVeryCloseFutureDate_ShouldReturnTrue()
        {
            // Arrange
            var veryCloseFuture = DateTime.UtcNow.AddMilliseconds(1);

            // Act
            var result = _attribute.IsValid(veryCloseFuture);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsValid_WithVeryClosePastDate_ShouldReturnFalse()
        {
            // Arrange
            var veryClosePast = DateTime.UtcNow.AddMilliseconds(-1);

            // Act
            var result = _attribute.IsValid(veryClosePast);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ErrorMessage_ShouldBeAccessible()
        {
            // Arrange
            var customErrorMessage = "Custom error message";
            _attribute.ErrorMessage = customErrorMessage;

            // Act
            var result = _attribute.ErrorMessage;

            // Assert
            result.Should().Be(customErrorMessage);
        }

        [Fact]
        public void FormatErrorMessage_ShouldReturnErrorMessage()
        {
            // Arrange
            var errorMessage = "Test error message";
            _attribute.ErrorMessage = errorMessage;

            // Act
            var result = _attribute.FormatErrorMessage("TestField");

            // Assert
            result.Should().Be(errorMessage);
        }

        [Fact]
        public void Validate_WithValidFutureDate_ShouldNotThrowException()
        {
            // Arrange
            var futureDate = DateTime.UtcNow.AddDays(1);
            var validationContext = new ValidationContext(futureDate);

            // Act & Assert
            _attribute.Invoking(a => a.Validate(futureDate, validationContext))
                     .Should().NotThrow();
        }

        [Fact]
        public void Validate_WithInvalidPastDate_ShouldThrowValidationException()
        {
            // Arrange
            var pastDate = DateTime.UtcNow.AddDays(-1);
            var validationContext = new ValidationContext(pastDate)
            {
                MemberName = "TestDate"
            };

            // Act & Assert
            _attribute.Invoking(a => a.Validate(pastDate, validationContext))
                     .Should().Throw<ValidationException>()
                     .WithMessage("*TestDate*");
        }
    }