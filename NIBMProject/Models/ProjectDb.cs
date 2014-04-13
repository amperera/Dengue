using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NIBMProject.Models
{
    public class ProjectDb : DbContext
    {
        public DbSet<UserDetails> Userdetail { get; set; }
        public DbSet<Patient> Patients { get; set; }

    }
}