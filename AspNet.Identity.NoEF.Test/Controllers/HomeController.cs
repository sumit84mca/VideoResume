using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace AspNet.Identity.NoEF.Test.Controllers
{
    public class HomeController : Controller
    {
        IApplicationSessionStore AppSession;
        IUserSession UserSession;
        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            base.OnAuthentication(filterContext);
            if (User.Identity.IsAuthenticated)
            {
                string userid = User.Identity.GetUserId();
                UserSession = CreateLoginSession(userid);
                AppSession["UserSession"] = UserSession;


            }

            //User.Identity.GetUserId();
        }
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewData["UserName"] = UserSession.Name;
            }
            return View();
        }
        public ActionResult Welcome()
        {
            string url = Request.QueryString["url"];
            if (!string.IsNullOrEmpty(url)) return Redirect(url); 
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult Approach()
        {
            return View();
        }
        public ActionResult Vision()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }

        public HomeController()
        {
            AppSession = new ApplicationSession();
        }

        private IdentityUserManager _userManager;

        public IdentityUserManager UserManager
        {
            get
            {
                if (_userManager == null) _userManager = HttpContext.GetOwinContext().GetUserManager<IdentityUserManager>();
                return _userManager;
            }
        }
        
        private string CreateLoginTrackID(string userID)
        {
            UserSessionStore userSessionStore = new UserSessionStore();
            return userSessionStore.CreateLoginTrack
                (
                new LoginTrack
                {
                    Id = Guid.NewGuid().ToString(),
                    IPAddress = Request.UserHostAddress,
                    UserID = userID
                }
            );
        }
        private IUserSession CreateLoginSession(string userID)
        {
            IUserSession userSession = new UserSession();
            IdentityUser user = UserManager.FindByIdAsync(userID).Result;
            userSession.AccountID = user.AccountUserId;
            userSession.Email = user.Email;
            userSession.Audit = new Audit { AuditAccountId = user.AccountUserId, AuditLoginTrackID = CreateLoginTrackID(userID), AuditUserId = userID };
            userSession.Mobile = user.PhoneNumber;
            userSession.Name = user.Name;
            userSession.UserID = user.Id;
            userSession.UserName = user.UserName;
            return userSession;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}