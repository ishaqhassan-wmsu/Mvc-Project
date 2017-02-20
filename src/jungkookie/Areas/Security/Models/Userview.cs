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
        [MinLength(5, ErrorMessage = "Min Of 5 Characters")]
        [MaxLength(10, ErrorMessage = "Max Of 5 Characters")]
        public String FirstName { get; set; }

        [Required, Display(Name = "Family Name")]
        public String LastName { get; set; }


        public int? Age { get; set; }

        public string Gender { get; set; }

    }
}