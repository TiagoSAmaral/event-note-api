using System.Text.Json;
using event_list.shared.Middlewares;
using event_list.shared.response_default;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace event_list.tests.SharedTests.MiddlewaresTests;

public class ExceptionMiddlewareTests
{
    [Fact]
    public async Task InvokeAsync_Should_CallNext_WhenNoException()
    {
        // Arrange
        var context = new DefaultHttpContext();
        var wasCalled = false;
        RequestDelegate next = ctx =>
        {
            wasCalled = true;
            return Task.CompletedTask;
        };

        var middleware = new ExceptionMiddleware(next);

        // Act
        await middleware.InvokeAsync(context);

        // Assert
        wasCalled.Should().BeTrue("o delegate seguinte deve ser chamado quando não há exceção");
    }

    [Fact]
    public async Task InvokeAsync_Should_HandleException_AndReturnJsonResponse()
    {
        // Arrange
        var context = new DefaultHttpContext();
        context.Response.Body = new MemoryStream();

        var expectedMessage = "Test exception";
        RequestDelegate next = ctx => throw new InvalidOperationException(expectedMessage);

        var middleware = new ExceptionMiddleware(next);

        // Act
        await middleware.InvokeAsync(context);

        // Resetar posição do stream para ler o que foi escrito
        context.Response.Body.Seek(0, SeekOrigin.Begin);
        using var reader = new StreamReader(context.Response.Body);
        var responseBody = await reader.ReadToEndAsync();

        // Assert
        context.Response.ContentType.Should().Be("application/json");

        var responseObj = JsonSerializer.Deserialize<ResponseDefault>(responseBody);
        responseObj.Should().NotBeNull();
        responseObj!.Message.Should().Be(expectedMessage);
        responseObj.Data.Should().BeNull();
    }
}