using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Job.WebMvc.Identity
{
    public class AppDbContext : IdentityDbContext<AppUser> 
    {
        public AppDbContext()
        : base("JobSQLConnectionString")
        {
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }   
    }
}