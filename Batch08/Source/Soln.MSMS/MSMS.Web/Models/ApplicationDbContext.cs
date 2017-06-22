using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MSMS.Web.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Institute> Institute { get; set; }
        public DbSet<ClassInfo> ClassInfo { get; set; }
        public DbSet<FeeSettings> Feesettings { get; set; }

        public DbSet<Lookup> Lookup { get; set; }

        public DbSet<Subject> Subject { get; set; }
        
        public DbSet<Student> Student { get; set; }
        
        /*
        public DbSet<Guardian> Guardian { get; set; }
        */
    }
}