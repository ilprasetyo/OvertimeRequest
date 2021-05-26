using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Models
{
    [Table("TB_T_EmployeeRequest")]
    public class EmployeeRequest
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}
