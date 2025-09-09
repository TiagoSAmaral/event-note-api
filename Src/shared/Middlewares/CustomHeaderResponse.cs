namespace event_list.shared.Middlewares;

public class CustomHeaderResponse
{
    private readonly RequestDelegate _next;

    public CustomHeaderResponse(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.Headers.Remove("Server");
        context.Response.Headers.Remove("X-Powered-By");
        await _next(context);
    }
}