using Employees_Manager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_Manager.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        
        public String Email { get; set; }

        [Required]
        public DateTime Dob { get; set; }

        public ICollection<Vacation> Vacations { get; set; }
    }
}
