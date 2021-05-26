using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Models
{
    [Table("TB_M_Position")]
    public class Position
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Department Department { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}