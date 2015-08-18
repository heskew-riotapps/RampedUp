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
    public class AppUserManager : UserManager<AppUser>
    {
        private AuthContext _authCtx;
        private MainContext _mainCtx;

        private AppUserManager _userManager;
 
        private RoleManager<IdentityRole> _roleManager;

        public AppUserManager(IUserStore<AppUser> store)
            : base(store)
        {
            //http://stackoverflow.com/questions/26726750/identity-email-with-dash-in-asp-net-mvc
            this.UserValidator = new UserValidator<AppUser>(this) { AllowOnlyAlphanumericUserNames = false };

            var mainConnectString = System.Configuration.ConfigurationManager.ConnectionStrings["Main"].ConnectionString;
            _authCtx = new AuthContext();
            _mainCtx = new MainContext(mainConnectString);
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_authCtx));
      
        }
        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            // var authContext = new AuthContext();
            var manager = new AppUserManager(new UserStore<AppUser>(context.Get<AuthContext>()));


            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<AppUser>(dataProtectionProvider.Create("PasswordReset"));
            }
            return manager;
        }
 
    }
}
