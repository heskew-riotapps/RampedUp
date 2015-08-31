using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RampedUp.Objects.Interfaces;

namespace RampedUp.Objects.Wins
{
    [Table("Opportunity")]
    public class Opportunity : IAuditable
    {
        public Guid Id { get; set; }
        public DateTime CloseDate { get; set; }
        public DateTime OpportunityCreateDate { get; set; }

        public WinEnums.eOpportunityStatus StatusId { get; set; }
        public int DealLength { get; set; }
        public int Amount { get; set; }

        public int MonthsUnderContract { get; set; }

        public string Competitor { get; set; }

        public string Industry { get; set; }

        /// <summary>
        /// might be a child collection
        /// </summary>
        public string Buyer { get; set; }

        public Guid RepId { get; set; }

        //public int DealTypeId { get; set; }

        public string RepNarrative { get; set; }

        public Guid ManagerId { get; set; }

        public string Source { get; set; }

        public Guid AccountId { get; set; }

        public string Headline { get; set; }

        public Guid CreatedBy{ get; set; }
        
        public DateTime CreatedOn { get; set; }        

        public Guid UpdatedBy { get; set; }
        
        public DateTime UpdatedOn { get; set; }
        
    }
}
