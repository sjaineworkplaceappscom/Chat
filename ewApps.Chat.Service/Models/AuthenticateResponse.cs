
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ewApps.Chat.Service.Models
{
    public class AuthenticateResponse
    {
        public int Result { get; set; }
        public string AccessToken { get; set; }
        public bool MultiTenant { get; set; }
        public Guid UserId { get; set; }
        public Guid TenantId { get; set; }
        public List<KeyValuePair<string, string>> TenantList { get; set; }
        public List<string> ApplicationList { get; set; }
    }
}