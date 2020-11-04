using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_Manager.Models
{
    public class Vacation : IEntity
    {

        [Key]
        public int Id { get; set; }
        public String Vacation_Type { get; set; }
        public int Balance { get; set; }
        public int Used { get; set; }

        public int EmployeeId { get; set; }
    }
}
