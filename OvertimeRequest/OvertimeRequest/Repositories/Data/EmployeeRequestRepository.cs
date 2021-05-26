using OvertimeRequest.Context;
using OvertimeRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Repositories.Data
{
    public class EmployeeRequestRepository: GeneralRepository<EmployeeRequest, MyContext, int>
    {
        private readonly MyContext myContext;

        public EmployeeRequestRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
