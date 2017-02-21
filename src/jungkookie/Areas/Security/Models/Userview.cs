using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jungkookie.Areas.Security.Models
{
    public class Userview
    {
       
        public Guid Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Min Of 3 Characters")]
        [MaxLength(25, ErrorMessage = "Max Of 25 Characters")]
        public String FirstName { get; set; }


        [Required, Display(Name = "Family Name")]
        [MinLength(3, ErrorMessage = "Min Of 3 Characters")]
        [MaxLength(25, ErrorMessage = "Max Of 25 Characters")]
        public String LastName { get; set; }


        public int? Age { get; set; }

        public string Gender { get; set; }

    }
}