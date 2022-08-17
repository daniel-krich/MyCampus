using Microsoft.JSInterop;
using MyCampusUI.Enums;

namespace MyCampusUI.Extensions
{
    public static class JsFunctions
    {
        // Vanilla
        public const string RedirectLocation = "document.location.assign";
        public const string NavigateBack = "history.back";

        // campus-core.js
        public const string WriteCookie = "campusCore.writeCookie";
        public const string GetCookie = "campusCore.getCookie";
        public const string DeleteCookie = "campusCore.deleteCookie";

        // campus-streams.js
        public const string CreateObjectBlobUrl = "campusStreams.createObjectBlobUrl";
        public const string ClearBlobUrlObjects = "campusStreams.clearBlobUrlObjects";
        public const string ClearBlobUrlObject = "campusStreams.clearBlobUrlObject";
        public const string DownloadBlob = "campusStreams.downloadBlob";

    }

    public static class JsRuntimeCoreExtensions
    {
        public static async Task TryInvokeVoidAsync(this IJSRuntime js, string identifier, params object?[]? args)
        {
            try { await Task.FromResult(js.InvokeVoidAsync(identifier, args)); }
            catch { }
        }

        public static async Task<TResult?> TryInvokeAsync<TResult>(this IJSRuntime js, string identifier, params object?[]? args)
        {
            try { return await js.InvokeAsync<TResult?>(identifier, args); }
            catch { return await Task.FromResult(default(TResult)); }
        }
    }

    public static class JsExtension
    {
        public static async Task RedirectLocation(this IJSRuntime js, string path)
        {
            await js.TryInvokeVoidAsync(JsFunctions.RedirectLocation, path);
        }

        public static async Task WriteCookie(this IJSRuntime js, string cookieName, string cookieValue, DateTime expireAt)
        {
            await js.TryInvokeVoidAsync(JsFunctions.WriteCookie, cookieName, cookieValue, expireAt.ToUniversalTime().ToString("r"));
        }

        public static async Task DeleteCookie(this IJSRuntime js, string cookieName)
        {
            await js.TryInvokeVoidAsync(JsFunctions.DeleteCookie, cookieName);
        }

        public static async Task NavigateBack(this IJSRuntime js)
        {
            await js.TryInvokeVoidAsync(JsFunctions.NavigateBack);
        }

        public static async Task<string?> CreateObjectBlobUrl(this IJSRuntime js, DotNetStreamReference stream, FileTransferEnum mime = FileTransferEnum.PlainText)
        {
            return await js.TryInvokeAsync<string?>(JsFunctions.CreateObjectBlobUrl, stream, mime.ToMimeString());
        }

        public static async Task ClearBlobUrlObjects(this IJSRuntime js)
        {
            await js.TryInvokeVoidAsync(JsFunctions.ClearBlobUrlObjects);
        }

        public static async Task ClearBlobUrlObject(this IJSRuntime js, string? url)
        {
            await js.TryInvokeVoidAsync(JsFunctions.ClearBlobUrlObject, url); ;
        }

        public static async Task DownloadBlob(this IJSRuntime js, string filename, string url)
        {
            await js.TryInvokeVoidAsync(JsFunctions.DownloadBlob, filename, url);
        }
    }
}
