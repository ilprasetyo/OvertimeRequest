using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Models
{
    [Table("TB_T_EmployeeRole")]
    public class EmployeeRole
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
