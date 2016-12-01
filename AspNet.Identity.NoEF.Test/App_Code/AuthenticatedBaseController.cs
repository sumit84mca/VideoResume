using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using Microsoft.AspNet.Identity;

namespace AspNet.Identity.NoEF.Test
{
    public class AfterLoginBaseController : Controller
    {
        public IApplicationSessionStore AppSession;

        public IUserSession UserSession;

        public AfterLoginBaseController()
        {
            AppSession = new ApplicationSession();
            UserSession = AppSession["UserSession"] as IUserSession;
        }
        //protected override void OnAuthentication(AuthenticationContext filterContext)
        //{
        //    base.OnAuthentication(filterContext);

        //    string userid = User.Identity.GetUserId();

        //    if (User.Identity.IsAuthenticated) {
        //        var audit = AppSession["applicationAudit"] as Audit;
        //        if (audit == null)
        //        {
        //            ApplicationAudit = User.Identity.getAuditData(userid);
        //        }
        //    }

        //    //User.Identity.GetUserId();
        //}

    }
}