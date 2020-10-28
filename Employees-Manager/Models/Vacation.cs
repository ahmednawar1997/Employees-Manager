using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_Manager.Models
{
    public class Vacation
    {

        [Key]
        public int Vacation_Id { get; set; }
        public String Vacation_Type { get; set; }
        public int Balance { get; set; }
        public int Used { get; set; }

        public int EmployeeId { get; set; }



    }
}
