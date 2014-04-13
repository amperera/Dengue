using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NIBMProject.Models
{
    [Table("Patient")]
    public class Patient
    {
        [Required]
        public int PatientId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public String LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime DateStarted { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
    }
}