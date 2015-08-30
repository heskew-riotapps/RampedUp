using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using RampedUp.Objects.Auth;
using System.Data.Entity;
using MySql.Data.Entity;

namespace RampedUp.Objects.Context
{

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class AuthContext : IdentityDbContext<AppUser>
    {

        public AuthContext()
            : base("Main")
        {

        }

        public static AuthContext Create()
        {
            return new AuthContext();
        }
    }
}
