using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMvc;
using System.ComponentModel.DataAnnotations;

namespace MyMvc.Dal
{
    public class User
    {
        public User()
        {
            Educations = new List<Education>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public DateTime? EmploymentDate { get; set; }

        public IList<Education> Educations{ get; set; }
    }
}
