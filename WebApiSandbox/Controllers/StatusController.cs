using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Web.Http;

namespace WebApiSandbox.Controllers
{
    public class StatusController : ApiController
    {

        [Route("hello")]
        [HttpGet]
        public HttpResponseMessage Hello()
        {
            HttpResponseMessage response
                = Request.CreateResponse(HttpStatusCode.OK);
            string html = "<html><body><h1>Hello!</h1></body></html>";
            response.Content = new StringContent(html, Encoding.Unicode, "text/html");
            return response;
        }

        [Route("check")]
        [HttpGet]
        public HttpResponseMessage Check()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);

            Assembly asm = Assembly.GetExecutingAssembly();
            FileVersionInfo version = FileVersionInfo.GetVersionInfo(asm.Location);

            string html = @"<html><body><h1>Hello!</h1><p>" + asm.FullName + "</p><p>" + version + "</p></body></html>";
            
            response.Content = new StringContent(html, Encoding.Unicode, "text/html");
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                NoCache = true
            };
            var toto = @"<svg xmlns=""http://www.w3.org/2000/svg"" width=""90"" height=""20""><linearGradient id=""a"" x2=""0"" y2=""100%""><stop offset=""0"" stop-color=""#bbb"" stop-opacity="".1""/><stop offset=""1"" stop-opacity="".1""/></linearGradient><rect rx=""3"" width=""90"" height=""20"" fill=""#555""/><rect rx=""3"" x=""37"" width=""53"" height=""20"" fill=""#4c1""/><path fill=""#4c1"" d=""M37 0h4v20h-4z""/><rect rx=""3"" width=""90"" height=""20"" fill=""url(#a)""/><g fill=""#fff"" text-anchor=""middle"" font-family=""DejaVu Sans,Verdana,Geneva,sans-serif"" font-size=""11""><text x=""19.5"" y=""15"" fill=""#010101"" fill-opacity="".3"">build</text><text x=""19.5"" y=""14"">build</text><text x=""62.5"" y=""15"" fill=""#010101"" fill-opacity="".3"">passing</text><text x=""62.5"" y=""14"">passing</text></g></svg>";
            return response;
        }

        [Route("icon")]
        [HttpGet]
        public HttpResponseMessage Icon()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);

            Assembly asm = Assembly.GetExecutingAssembly();
            FileVersionInfo version = FileVersionInfo.GetVersionInfo(asm.Location);

            var svg = @"<svg xmlns=""http://www.w3.org/2000/svg"" width=""90"" height=""20""><linearGradient id=""a"" x2=""0"" y2=""100%""><stop offset=""0"" stop-color=""#bbb"" stop-opacity="".1""/><stop offset=""1"" stop-opacity="".1""/></linearGradient><rect rx=""3"" width=""90"" height=""20"" fill=""#555""/><rect rx=""3"" x=""37"" width=""53"" height=""20"" fill=""#4c1""/><path fill=""#4c1"" d=""M37 0h4v20h-4z""/><rect rx=""3"" width=""90"" height=""20"" fill=""url(#a)""/><g fill=""#fff"" text-anchor=""middle"" font-family=""DejaVu Sans,Verdana,Geneva,sans-serif"" font-size=""11""><text x=""19.5"" y=""15"" fill=""#010101"" fill-opacity="".3"">build</text><text x=""19.5"" y=""14"">build</text><text x=""62.5"" y=""15"" fill=""#010101"" fill-opacity="".3"">passing</text><text x=""62.5"" y=""14"">passing</text></g></svg>";
 
            response.Content = new StringContent(svg, Encoding.Unicode, "image/svg+xml");
            //response.StatusCode = HttpStatusCode.InternalServerError;
            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                NoCache = true
            };
            return response;
        }

    }

}