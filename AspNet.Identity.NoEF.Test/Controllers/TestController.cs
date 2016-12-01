using AspNet.Identity.NoEF.Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AspNet.Identity.NoEF.Test.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TestViewModels model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return View("testDisplay",model);

        }

        
    }
}