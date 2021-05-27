using OvertimeRequest.Context;
using OvertimeRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Repositories.Data
{
    public class RequestRepository : GeneralRepository<Request, MyContext, int>
    {
        private readonly MyContext myContext;

        public RequestRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
