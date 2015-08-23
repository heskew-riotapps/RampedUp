using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.IO;
using RazorEngine.Templating;
//using RazorEngine;
using System.Net.Http.Headers;

namespace RampedUp.Web.Controllers.WebApi
{
    [RoutePrefix("api/Views")]
    public class ViewController : ApiController
    {
        [Route("a/{folder}/{file}")]
        //[Authorize]
        public HttpResponseMessage GetAuthorizedView(string folder, string file)
        {
            try
            {
                return fetchView(folder, file, true);
            }
            catch (System.IO.FileNotFoundException nfE)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, e.Message);
            }
        }

        [Route("u/{folder}/{file}")]
        public HttpResponseMessage GetUnauthorizedView(string folder, string file)
        {
            try
            {
                return fetchView(folder, file, false);
            }
            catch (System.IO.FileNotFoundException nfE)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, e.Message);
            }
        }

        private HttpResponseMessage fetchView(string folder, string file, bool isAuthorized)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            //http://antaris.github.io/RazorEngine/Upgrading.html
            //https://github.com/Antaris/RazorEngine
            var templateKey = string.Format("{0}.{1}", folder, file);

            //try to find view in cache first
            //refactor this to cache/compile at startup
            string parsedView = string.Empty;
            //#if DEBUG
            try
            {
                parsedView = RazorEngine.Engine.Razor.Run(templateKey);
            }
            catch (InvalidOperationException e)
            {
                //from here it will fall through to RunCompile
            }
            //#endif
            if (string.IsNullOrEmpty(parsedView))
            {
                var viewPath = System.Web.Hosting.HostingEnvironment.MapPath(string.Format(@"~/Views/{2}/{0}/{1}.cshtml", folder, file, (isAuthorized ? "Authorized" : "Unauthorized")));
                var template = File.ReadAllText(viewPath);
                parsedView = RazorEngine.Engine.Razor.RunCompile(template, templateKey);
            }

            response.Content = new StringContent(parsedView);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }
    }
}
