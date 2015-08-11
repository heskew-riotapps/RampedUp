using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RampedUp.Objects.Interfaces
{
    public interface IAuditable
    {
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
