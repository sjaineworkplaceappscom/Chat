using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ewApps.Chat.Service.Models
{
    public class AutenticateRequest
    {
        public int AuthenticationType { get; set; }
        public string LoginEmail { get; set; }
        public string Password { get; set; }
        public int RequesterType { get; set; }
        public string RequesterId { get; set; }
        public string RequesterTimeZone { get; set; }
        public string RequesterRegion { get; set; }
    }
}