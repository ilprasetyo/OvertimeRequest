﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.ViewModels
{
    public class ApproveVM
    {
        public int RequestId { get; set; }
        public string NIK { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }

    }
}
