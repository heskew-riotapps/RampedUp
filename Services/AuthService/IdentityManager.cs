using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using RampedUp.Objects.Auth;
using RampedUp.Objects.Context;
using RampedUp.Services.AuthService.Models;

namespace RampedUp.Services.AuthService
{
    public class IdentityManager : UserManager<AppUser>
    {

        public IdentityManager(IUserStore<AppUser> store)
            : base(store)
        {
            //http://stackoverflow.com/questions/26726750/identity-email-with-dash-in-asp-net-mvc
            this.UserValidator = new UserValidator<AppUser>(this) { AllowOnlyAlphanumericUserNames = false };
        }
       
        public static IdentityManager Create(IdentityFactoryOptions<IdentityManager> options, IOwinContext context)
        {
            var manager = new IdentityManager(new UserStore<AppUser>(context.Get<AuthContext>()));

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<AppUser>(dataProtectionProvider.Create("PasswordReset"));
            }
            return manager;
        }
 
    }
}
