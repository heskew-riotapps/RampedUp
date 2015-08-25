using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using RampedUp.Web.Models.Auth;

namespace RampedUp.Web.Controllers.WebApi
{
    [RoutePrefix("api/Auth")]
    public class AuthController : ApiController
    {
        [Authorize]
        [Route("AuthenticationCheck")]
        [HttpPost]
        public HttpResponseMessage AuthenticationCheck()
        {

            //technically will never get here is authorization fails. that is ok for now
            var isAuthenticated = HttpContext.Current.User.Identity.IsAuthenticated;

            if (isAuthenticated)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
        }

       // [Authorize]
        [Route("AuthorizationCheck")]
        [HttpPost]
        public HttpResponseMessage AuthorizationCheck(AuthCheckModel model)
        {
            //technically will never get here if authorization fails. that is ok for now
            var roles = model.Role.Split(",".ToCharArray());
            var isAuthenticated = false;

            //make sure user is in at least one of the requested roles
            foreach (var role in roles)
            {
                var isInRole = HttpContext.Current.User.IsInRole(role);
                if (isInRole)
                {
                    isAuthenticated = true;
                    //one success is enough to stop processing
                    break;
                }
                else
                {
                    isAuthenticated = false;
                }
            }

            if (isAuthenticated)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
            }

        }
    }
}
