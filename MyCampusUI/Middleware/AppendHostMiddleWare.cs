namespace MyCampusUI.Middleware;

public class AddMissingHeadersMiddleWare
{
    private readonly RequestDelegate _next;

    public AddMissingHeadersMiddleWare(RequestDelegate next)
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
