using OvertimeRequest.Context;
using OvertimeRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Repositories.Data
{
    public class RoleRepository: GeneralRepository<Role, MyContext, int>
    {
        private readonly MyContext myContext;

        public RoleRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
