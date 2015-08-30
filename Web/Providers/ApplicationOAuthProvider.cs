using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using RampedUp.Services.AuthService;
using RampedUp.Objects.Auth;
using log4net;
using System.Net;
using System.Web;
 

namespace RampedUp.Web.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(ApplicationOAuthProvider));
        private readonly string _publicClientId;

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
         

            context.Validated();
            return Task.FromResult<object>(null);
        }


        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            AppUser user = null;
            var role = string.Empty;

            using (UserManager _mgr = new UserManager(HttpContext.Current.GetOwinContext().GetUserManager<RampedUp.Services.AuthService.IdentityManager>()))
            {
                user = await _mgr.FindUserAsync(context.UserName, context.Password);
                //if (user != null && user.Roles != null && user.Roles.Count > 0)
                //{
                //    role = _repo.GetRole(user.Roles.First().RoleId).Name;
                //}

            }
            if (user == null)
            {
                context.SetError("invalid_grant", "login failed"); //RampedUp.Resources.Strings.Exceptions.LoginFailed);
                return;
            }
            if (user.StatusId == AppUser.eStatus.PendingActivation)
            {

                context.SetError("invalid_grant", "not active"); //RampedUp.Resources.Strings.Exceptions.LoginUserNotActive);
                 
                return;
            }
            if (user.StatusId != AppUser.eStatus.Active)
            {
                context.SetError("invalid_grant", "not active"); // RampedUp.Resources.Strings.Exceptions.LoginUserNotActive);
                return;
            }

            //if (user.AccountId != null) // this can be refactored after all users have account id
            //{
            //    Account account = null;
            //    using (var _accountMgr = new AccountManager(System.Configuration.ConfigurationManager.ConnectionStrings["S123Admin"].ConnectionString))
            //    {
            //        account = await _accountMgr.GetAccount((Guid)user.AccountId);
            //    }

            //    if (account != null && (account.StatusId == AccountEnums.eAccountStatus.Deleted || account.StatusId == AccountEnums.eAccountStatus.Suspended))
            //    {
            //        context.SetError("invalid_grant", RampedUp.Resources.Strings.Exceptions.LoginAccountNotActive);
            //        return;
            //    }
            //    else
            //    {
            //        //for now, if account is in trial status, simply set all of the account's user to trial status (only in httpcontext/identity)
            //        if (account.StatusId == AccountEnums.eAccountStatus.Trial)
            //        {
            //            role = RampedUp.AuthService.Plumbing.Constants.TrialRole;
            //        }
            //    }
            //}


            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            // identity.AddClaim(new Claim("sub", context.UserName));
            //identity.AddClaim(new Claim("_u", user.FirstName + " " + user.LastName ));
           // identity.AddClaim(new Claim(ClaimTypes.Role, role));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.FirstName));
            // identity.AddClaim(new Claim(ClaimTypes., user.FirstName));
            //   identity.AddClaim(new Claim(ClaimTypes.))

            // identity.AddClaim(new Claim("role", role));

            var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    { 
                        "as:client_id", (context.ClientId == null) ? string.Empty : context.ClientId
                    },
                    { 
                        "userName", user.UserName
                    },
                    { 
                        "userId", user.Id.ToString()
                    },
                    { 
                        "ip", context.OwinContext.Request.RemoteIpAddress
                    }
                });

            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);

            // context.Validated(identity);

        }

        //public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        //{
        //    var userManager = context.OwinContext.GetUserManager<AppUserManager>();

        //    AppUser user = await userManager.FindAsync(context.UserName, context.Password);

        //    if (user == null)
        //    {
        //        context.SetError("invalid_grant", "The user name or password is incorrect.");
        //        return;
        //    }

        //    ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager,
        //       OAuthDefaults.AuthenticationType);
        //    ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(userManager,
        //        CookieAuthenticationDefaults.AuthenticationType);

        //    AuthenticationProperties properties = CreateProperties(user.UserName);
        //    AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
        //    context.Validated(ticket);
        //    context.Request.Context.Authentication.SignIn(cookiesIdentity);
        //}

        //public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        //{
        //    foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
        //    {
        //        context.AdditionalResponseParameters.Add(property.Key, property.Value);
        //    }

        //    return Task.FromResult<object>(null);
        //}

        //public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        //{
        //    // Resource owner password credentials does not provide a client ID.
        //    if (context.ClientId == null)
        //    {
        //        context.Validated();
        //    }

        //    return Task.FromResult<object>(null);
        //}

        //public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        //{
        //    if (context.ClientId == _publicClientId)
        //    {
        //        Uri expectedRootUri = new Uri(context.Request.Uri, "/");

        //        if (expectedRootUri.AbsoluteUri == context.RedirectUri)
        //        {
        //            context.Validated();
        //        }
        //    }

        //    return Task.FromResult<object>(null);
        //}

        //public static AuthenticationProperties CreateProperties(string userName)
        //{
        //    IDictionary<string, string> data = new Dictionary<string, string>
        //    {
        //        { "userName", userName }
        //    };
        //    return new AuthenticationProperties(data);
        //}
    }
}