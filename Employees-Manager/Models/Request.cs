using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_Manager.Models
{
    public class Request : IEntity
    {

        [Key]
        public int Id { get; set; }
        public Employee Employee{ get; set; }
        public String Vacation_Type { get; set; }
        public int Value { get; set; }
    }
}
