using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalMIS_WebApi.Models
{
    public class PatientInfo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Address { get; set; }
    }
}