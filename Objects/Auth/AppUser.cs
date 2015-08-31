using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RampedUp.Objects.Auth
{
     
    public class AppUser : IdentityUser
    {  
        public enum eStatus
        {
            PendingActivation = 0,
            Active = 1,
            Inactive = 2,
            Deleted = 3
        }

        public DateTime? TermsAcceptedOn { get; set; }

        public eStatus StatusId { get; set; }
 
        //  [Required]
        [MaxLength(200)]
        public string FirstName { get; set; }

        // [Required]
        [MaxLength(200)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }

        }

        public Guid? AccountId { get; set; }

        //[MaxLength(200)]
        //public string Company { get; set; }

        [MaxLength(128)]
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [MaxLength(128)]
        public string UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
