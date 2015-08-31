using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using RampedUp.Services.WinService;
using RampedUp.Services.WinService.Models;
using RampedUp.Web.Models.Common;
using log4net;


namespace RampedUp.Web.Controllers.WebApi
{
    [RoutePrefix("api/Win")]
    public class WinController : ApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(WinController));
        private OpportunityManager _opportunityMgr;
        public WinController()
        {
            //TO-DO dependency injection
            this._opportunityMgr = new OpportunityManager();
        }

        [Route("AddOpportunity")]
      //  [Authorize(Roles = "Admin,AccountAdmin,AccountUser")]  TO-DO add authorization
        public async Task<HttpResponseMessage> AddOpportunity(AddOpportunityModel model)
        {
            try
            {
                //var userId = HttpContext.Current.User.Identity.GetUserId();  coming soon
                var userId = Guid.NewGuid();

                var result = await this._opportunityMgr.SaveOpportunityAsync(userId, model);

                return Request.CreateResponse(HttpStatusCode.OK, new IdOutputModel(result));
            }
            catch (Exception e)
            {
                logger.Debug(e);
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorResultModel(e.Message));
            }

        }
    }
}
