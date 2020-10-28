using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_Manager.Models
{
    public class Request
    {

        [Key]
        public int Request_Id { get; set; }
        public int Employee_Id { get; set; }
        public String Vacation_Type { get; set; }
        public int Value { get; set; }

    }
}
