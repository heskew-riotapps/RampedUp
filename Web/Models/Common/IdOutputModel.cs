using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RampedUp.Web.Models.Common
{
    public class IdOutputModel
    {
        public IdOutputModel(string id)
        {
            this.Id = id;
        }
        public IdOutputModel(Guid id)
        {
            this.Id = id.ToString();
        }
        public string Id { get; set; }
    }
}