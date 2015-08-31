using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RampedUp.Web.Models.Common
{
    public class ErrorResultModel
    {
        public ErrorResultModel(string message)
        {
            this.StackTrace = string.Empty;
            this.Message = message;
        }
        public ErrorResultModel(string message, string stackTrace)
        {
            this.StackTrace = stackTrace;
            this.Message = message;
        }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}