using OvertimeRequest.Context;
using OvertimeRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Repositories.Data
{
    public class PositionRepository: GeneralRepository<Position, MyContext, int>
    {
        private readonly MyContext myContext;

        public PositionRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
