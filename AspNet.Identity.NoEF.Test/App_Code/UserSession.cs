using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet.Identity.NoEF.Test
{
    public class UserSession : IUserSession
    {
        public string AccountID { get; set; }
        public Audit Audit { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Name { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
    }
}