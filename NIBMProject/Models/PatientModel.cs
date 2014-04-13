using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NIBMProject.Models
{
    public class PatientModel
    {
        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "LastName")]
        public String LastName { get; set; }
        [Required]
        [Display(Name = "Age")]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Date Started")]
        [DataType(DataType.Date)]
        public DateTime DateStarted { get; set; }

        public string Lat { get; set; }
        public string Long { get; set; }
    }
}