using MVCentityFrameworkNewProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Web;

namespace MVCentityFrameworkNewProject.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(): base("conStr")
        {

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}