using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNet.Identity.NoEF.Test.Controllers
{
    public class CandidateController : Controller
    {
        // GET: Candidate
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}