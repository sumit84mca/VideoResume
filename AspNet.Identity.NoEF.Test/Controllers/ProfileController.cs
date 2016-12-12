using AspNet.Identity.NoEF.Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNet.Identity.NoEF.Test.Controllers
{
    public class ProfileController : AfterLoginBaseController
    {
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProfileIndex()
        {
            var model = new RegisterViewModel
            {
                Name = UserSession.Name,
                MobileNo = UserSession.Mobile,
                Email = UserSession.Email
            };
            return View(model);
        }
    }
}