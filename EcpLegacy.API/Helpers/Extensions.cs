using Microsoft.AspNetCore.Http;

namespace EcpLegacy.API.Helpers
{
    public static class Extensions
    {
        // Extend global exception handler so we get a specific Application Error header back to the client/frontEnd
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-ExposeHeaders", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}