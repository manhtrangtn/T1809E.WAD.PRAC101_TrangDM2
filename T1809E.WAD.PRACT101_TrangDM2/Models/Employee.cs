using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace T1809E.WAD.PRACT101_TrangDM2.Models
{
    public class Employee
    {
        [Key]
        [Required]
        [DisplayName("Employee ID")]
        public string Id { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Name must be alphabet character!")]
        [DisplayName("Employee Name")]
        public string Name { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Salary must be number!")]
        public double Salary { get; set; }
    }
}