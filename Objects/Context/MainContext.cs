using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MySql.Data.Entity;
using RampedUp.Objects.Wins;

namespace RampedUp.Objects.Context
{

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MainContext : DbContext
    {
       public MainContext(string connString) : base(connString) { }
       public MainContext(string connString, bool lazyLoadingEnabled)
            : base(connString)
        {
            this.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
        }

       public DbSet<Opportunity> Opportunities { get; set; }
    }
}
