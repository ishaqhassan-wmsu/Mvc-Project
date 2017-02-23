using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MyMvc.Dal;
namespace jungkookie.Areas.Security.Models
{
    public class Userview
    {
       public Userview()
       {
           Educations = new List<Education>();
        }
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Min Of 3 Characters")]
        [MaxLength(25, ErrorMessage = "Max Of 25 Characters")]
        public String FirstName { get; set; }


        [Required, Display(Name = "LastName")]
        [MinLength(3, ErrorMessage = "Min Of 3 Characters")]
        [MaxLength(25, ErrorMessage = "Max Of 25 Characters")]
        public String LastName { get; set; }


        public int? Age { get; set; }

        public string Gender { get; set; }
        [Display(Name = "Employement Date")]
        public DateTime? EmploymentDate { get; set; }

        public IList<Education> Educations { get; set; }
    }
}