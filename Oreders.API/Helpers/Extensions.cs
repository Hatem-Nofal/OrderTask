using Microsoft.AspNetCore.Http;
namespace  Oreders.API.Helpers {
    public static class Extensions {
        public static void AddApplicationError (this HttpResponse respone, string message) {

            respone.Headers.Add ("Application-Error", message);
            respone.Headers.Add ("Access-control-Expose-Header", "Application-Error");
            respone.Headers.Add ("Access-control-Allow-Origin", "*");

        }
    }
}