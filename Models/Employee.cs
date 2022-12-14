using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCentityFrameworkNewProject.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public int Salary { get; set; }
        [Required]
        [Display(Name="Department")]
        public int DepartmentId {get; set;}
        public Department Department { get; set; }
        [Display(Name = "Designation")]
        public int DesignationId { get; set; }
        public Designation Designation { get; set; }
}
}