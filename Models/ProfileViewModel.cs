using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AspNet.Identity.NoEF.Test.Models
{
    public class ChangeAddressViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Address Line 3")]
        public string AddressLine3 { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "State")]
        public string State { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        [Display(Name = "PIN")]
        public string PIN { get; set; }
        public IEnumerable<SelectListItem> CountryList { get; set; }
        public IEnumerable<SelectListItem> StateList { get; set; }
        public IEnumerable<SelectListItem> CityList { get; set; }        

        public string UserId { get; set; }        

        public ChangeAddressViewModel()
        {
            CountryList = new List<SelectListItem>();
            StateList = new List<SelectListItem>();
            CityList = new List<SelectListItem>();
        }

    }
}