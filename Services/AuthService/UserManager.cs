﻿using System;
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
    public interface IAuthManager
    {
      //  async Task<AppUser> RegisterUserAsync(AppUserModel userModel)
    }
    public class AppUserManager : IAuthManager, IDisposable
    {
        
        private MainContext _mainCtx;

        private IdentityManager _identityManager;
        private RoleManager<IdentityRole> _roleManager;

        public AppUserManager(IdentityManager identityManager)
        {
            this._identityManager = identityManager;
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

            var result = await this._identityManager.CreateAsync(user, userModel.Password);

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

        public async Task<AppUser> FindUserAsync(string userName, string password)
        {
            AppUser user = await _identityManager.FindAsync(userName, password);

            return user;
        }

        //public async Task<AppUser> FindUserByIdAsync(Guid id)
        //{
        //    AppUser user = await _identityManager.fin(id.ToString());

        //    return user;
        //}

        public void Dispose()
        {
            this._identityManager = null;
        }
    }
}
