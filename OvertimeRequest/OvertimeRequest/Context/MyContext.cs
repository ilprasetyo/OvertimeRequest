using Microsoft.EntityFrameworkCore;
using OvertimeRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Context
{
    public class MyContext : DbContext
    {
        public MyContext()
        {

        }
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        //public MyContext
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<>
    }
}
