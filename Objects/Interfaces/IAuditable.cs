using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RampedUp.Objects.Interfaces
{
    public interface IAuditable
    {
        Guid CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }

        Guid UpdatedBy { get; set; }
        DateTime UpdatedOn { get; set; }
    }
}
