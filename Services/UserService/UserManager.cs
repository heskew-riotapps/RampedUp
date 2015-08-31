using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RampedUp.Objects.Auth;
using RampedUp.Objects.Context;
using RampedUp.Services.Common;

namespace RampedUp.Services.UserService
{
    public class UserManager
    {
        MainContext _mainContext;
        
        public UserManager(MainContext mainContext)
        {
            this._mainContext = mainContext;
        }

        public UserManager(string connectionString)
        {
            this._mainContext = new MainContext(connectionString);
        }
        public UserManager()
        {
            this._mainContext = new MainContext(System.Configuration.ConfigurationManager.ConnectionStrings[Constants.MainConnectionStringName].ConnectionString);
        }

        //public async Task<AppUser> GetUserById(Guid id)
        //{
        //    return await this._mainContext.AppUsers.FindAsync(id.ToString());
        //}
    }
}
