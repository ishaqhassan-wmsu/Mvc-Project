using MyMvc.Dal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvc.Dal
{
    public class DatabaseContext: DbContext
    {
        public DbSet<User> Users{ get; set; }

        public DatabaseContext()
            : base("DefaultConnection")
    {
        
    }

    }
}
