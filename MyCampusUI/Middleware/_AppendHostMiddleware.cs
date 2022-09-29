namespace MyCampusUI.Middleware;

public class AppendHostMiddleware
{
    private readonly RequestDelegate _next;

    public AppendHostMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            if (!context.Request.Headers.ContainsKey("Host"))
                context.Request.Headers["Host"] = "UNKNOWN-HOST";

            await _next(context);
        }
        catch { }
    }
}
