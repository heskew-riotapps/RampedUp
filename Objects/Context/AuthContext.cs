using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using RampedUp.Objects.Auth;

namespace RampedUp.Objects.Context
{
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
