using OvertimeRequest.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Handlers
{
    public class SimpleAuthentication
    {
        private readonly MyContext context;
        public SimpleAuthentication(MyContext context)
        {
            this.context = context;
        }
        public bool Check(string application, string token)
        {
            var get = context.Parameters.SingleOrDefault(p => p.Name == application);
            if (get.Value == token)
            {
                return true;
            }
            return false;

        }
    }
}
