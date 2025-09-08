/*
* ExceptionMiddleware.cs 
* event-list 
*
* Created by Tiago Amaral on 06/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
*/

using System.Text.Json;
using event_list.shared.response_default;
using event_list.shared.exceptionsMessage;
using Microsoft.AspNetCore.Http;

namespace event_list.shared.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            // Internal log
            // Console.WriteLine( ex.GetType());
            var responseDefault = new ResponseDefault(context.Response.StatusCode, ex.Message, null);
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(responseDefault));
        }
    }
}