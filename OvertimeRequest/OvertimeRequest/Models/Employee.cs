using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Models
{
    [Table("TB_M_Employee")]
    public class Employee
    {
        [Key, ForeignKey(nameof(Manager))]
        public string NIK { get; set; }
        #nullable enable
        public string? ManagerId { get; set; }
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Status { get; set; }
        public Account? Account { get; set; }
        public Position? Position { get; set; }
        public ICollection<EmployeeRole>? EmployeeRoles { get; set; }
        public ICollection<EmployeeRequest>? EmployeeRequests { get; set; }
        public virtual Employee? Manager { get; set; }

    }
}
