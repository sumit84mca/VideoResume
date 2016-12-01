using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using Microsoft.AspNet.Identity;
namespace AspNet.Identity.NoEF.Test
{
    public class PublicBaseController : Controller
    {
        IApplicationSessionStore AppSession;
        IUserSession UserSession;
        public PublicBaseController()
        {
            AppSession = new ApplicationSession();

            UserSession = new UserSession
            {
                AccountID = Guid.Empty.ToString(),
                Audit = new Audit
                {
                    AuditAccountId = Guid.Empty.ToString(),
                    AuditLoginTrackID = Guid.Empty.ToString(),
                    AuditUserId = Guid.Empty.ToString()
                },
                UserID = Guid.Empty.ToString(),
                UserName = "Guest"
            };
        }
    }
}