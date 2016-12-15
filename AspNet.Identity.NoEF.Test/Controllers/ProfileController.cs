using AspNet.Identity.NoEF.Test.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var model = new RegisterViewModel()
            {
                Name = UserSession.Name,
                MobileNo = UserSession.Mobile,
                Email = UserSession.Email,
                AddressView = UserProfile.GetUserAddress(UserSession.UserID)
            };
            return View(model);
        }
        public ActionResult ChangeAddress()
        {
            var model = new ChangeAddressViewModel();

            model.CountryList = new SelectList(Masters.GetCountryList(), "CountryId", "CountryName");

            return View(model);
        }
        public JsonResult GetStates(int countryid)
        {
            return Json(new SelectList(Masters.GetStateList(countryid), "StateId", "StateName"));
        }
        public JsonResult GetCities(int stateid)
        {
            return Json(new SelectList(Masters.GetCityList(stateid), "CityId", "CityName"));
        }

        //
        // POST: /Profile/ChangeAddress
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeAddress(ChangeAddressViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.UserId = UserSession.UserID;
            int result = UserProfile.UpdateAddress(model);
            if (result == 1)
            {
                //TODO: Success message
                return RedirectToAction("ProfileIndex", "Profile");
            }

            return View(model);
        }
    }
}