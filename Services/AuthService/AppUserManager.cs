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

        public async Task<AppUser> RegisterUserAsync(AppUserModel userModel)
        {
            AppUser newUser = null;
            AppUser user = new AppUser
            {
                UserName = userModel.UserName.Trim(),
                FirstName = userModel.FirstName.Trim(),
                LastName = userModel.LastName.Trim(),
                Email = userModel.UserName.Trim(),
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                PhoneNumber = userModel.PhoneNumber,
                StatusId = AppUser.eStatus.PendingActivation,
                TermsAcceptedOn = DateTime.UtcNow
            };

            //save account first, 
      

            var result = await this.CreateAsync(user, userModel.Password);

            //add user to default role
            if (result.Succeeded)
            {
                //newUser = await this.FindUser(user.UserName, userModel.Password);

                //result = await this.AssignUserToRole(newUser.Id, Social123.AuthService.Plumbing.Constants.CustomerRole);

                //account.CreatedBy = new Guid(newUser.Id);
                //account.UpdatedBy = new Guid(newUser.Id);
                //subscription.CreatedBy = new Guid(newUser.Id);
                //subscription.UpdatedBy = new Guid(newUser.Id);

                //await this._adminCtx.SaveChangesAsync();
            }

            return newUser;
        }
 
    }
}
