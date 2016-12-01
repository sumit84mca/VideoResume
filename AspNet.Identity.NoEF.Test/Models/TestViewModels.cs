using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNet.Identity.NoEF.Test.Models
{
    public class TestViewModels
    {
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Range(minimum: 10, maximum: 99, ErrorMessage = "Age should be between 10 to 99")]
        public int Age { get; set; }

    }
}