using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RampedUp.Objects.Wins;
using RampedUp.Objects.Context;
using RampedUp.Services.Common;
using RampedUp.Services.WinService.Models;
using RampedUp.Services.UserService;
using log4net;

namespace RampedUp.Services.WinService
{
    public class OpportunityManager
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(OpportunityManager));
 
        private MainContext _mainContext;
        private UserManager _userMgr;

        public OpportunityManager(MainContext mainContext)
        {
            this._mainContext = mainContext;
        }

        public OpportunityManager(string connectionString)
        {
            this._mainContext = new MainContext(connectionString);
        }
        public OpportunityManager()
        {
            this._mainContext = new MainContext(System.Configuration.ConfigurationManager.ConnectionStrings[Constants.MainConnectionStringName].ConnectionString);
        }

        private void Init()
        {
            this._userMgr = new UserManager();
        }

        public async Task<Opportunity> GetOpportunityAsync(Guid id)
        {
            return await this._mainContext.Opportunities.FindAsync(id);
        }

        public async Task<Guid> SaveOpportunityAsync(Guid userId, AddOpportunityModel model)
        {
            //TO-DO validate the model

            //commented out for now
            //var user = await this._userMgr.GetUserById(userId);

            var now = DateTime.UtcNow;
            var opportunity = new Opportunity();
            opportunity.Id = Guid.NewGuid();
            opportunity.CreatedBy = userId;
            opportunity.CreatedOn = now;
            opportunity.UpdatedBy = userId;
            opportunity.UpdatedOn = now;
            opportunity.StatusId = WinEnums.eOpportunityStatus.Open;
            opportunity.Competitor = model.Competitor;
            opportunity.Industry = model.Industry;
            opportunity.AccountId = Guid.Empty;  // user.AccountId;
            opportunity.Amount = 0;
            opportunity.Buyer = string.Empty;
            opportunity.DealLength = 2;
            opportunity.Headline = "headline";
            opportunity.ManagerId = Guid.Empty;
            opportunity.MonthsUnderContract = 2;
            opportunity.OpportunityCreateDate = now;
            opportunity.RepId = Guid.Empty;
            opportunity.RepNarrative = string.Empty;
            opportunity.Source = string.Empty;


            this._mainContext.Opportunities.Add(opportunity);

            var result = await this._mainContext.SaveChangesAsync();

            return opportunity.Id;
        }



    }
}
