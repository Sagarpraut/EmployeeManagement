using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Models
{
    public partial class Employee
    {

        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "Employee name required")]
        public string Empno { get; set; }
        public string Firstnme { get; set; }
        public string Middle { get; set; }
        public string Lastname { get; set; }
        public string Workdept { get; set; }
        public string Phoneno { get; set; }
        public DateTime? Hiredate { get; set; }
        public string Job { get; set; }
        public DateTime? Birthdate { get; set; }
        public decimal? Salary { get; set; }
    }
}
