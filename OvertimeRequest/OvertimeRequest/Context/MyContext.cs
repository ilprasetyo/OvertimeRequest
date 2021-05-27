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
        public DbSet<Position> Positions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<EmployeeRequest> EmployeeRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Employee-EmployeeRole
            modelBuilder.Entity<EmployeeRole>()
                .HasOne(EmployeeRole => EmployeeRole.Employee)
                .WithMany(Employee => Employee.EmployeeRoles)
                .OnDelete(DeleteBehavior.Cascade);

            //Employee-EmployeeRequest
            modelBuilder.Entity<EmployeeRequest>()
                .HasOne(EmployeeRequest => EmployeeRequest.Employee)
                .WithMany(Employee => Employee.EmployeeRequests)
                .OnDelete(DeleteBehavior.Cascade);

            //Request-EmployeeRequest
            modelBuilder.Entity<EmployeeRequest>()
               .HasOne(EmployeeRequest => EmployeeRequest.Request)
               .WithMany(Employee => Employee.EmployeeRequests)
               .OnDelete(DeleteBehavior.Cascade);

            //Role-EmployeeRole
            modelBuilder.Entity<EmployeeRole>()
              .HasOne(EmployeeRole => EmployeeRole.Role)
              .WithMany(Role => Role.EmployeeRoles)
              .OnDelete(DeleteBehavior.Cascade);

            //Account-Employee
            modelBuilder.Entity<Account>()
           .HasOne(Account => Account.Employee)
           .WithOne(Employee => Employee.Account)
           .HasForeignKey<Account>(Account => Account.NIK)
           .OnDelete(DeleteBehavior.Cascade);

            //Position-Employee
            modelBuilder.Entity<Employee>()
           .HasOne(Employee => Employee.Position)
           .WithMany(Position => Position.Employees)
           .OnDelete(DeleteBehavior.Cascade);

            //Department-Position
            modelBuilder.Entity<Position>()
            .HasOne(Position => Position.Department)
            .WithMany(Department => Department.Positions)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>()
            .HasOne(Employee => Employee.Manager)
            .WithMany()
            .HasForeignKey(Manager => Manager.ManagerId);
        }
    }
}
