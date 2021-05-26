﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Models
{
    [Table("TB_M_Department")]
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
