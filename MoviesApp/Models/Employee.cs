using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Models
{
    public partial class Employee
    {

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name required")]
        public string Firstnme { get; set; }

        [Display(Name = "Middle Name")]
        [Required(ErrorMessage = "Middle name required")]
        public string Middle { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name required")]
        public string Lastname { get; set; }

        public string Workdept { get; set; }
      
        [Phone]
        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "phone Number required")]
        public string Phoneno { get; set; }
        public string Job { get; set; }
        public decimal? Salary { get; set; }
        public int Empno { get; set; }
    }
}
