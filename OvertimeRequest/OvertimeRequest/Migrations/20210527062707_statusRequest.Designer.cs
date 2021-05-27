﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OvertimeRequest.Context;

namespace OvertimeRequest.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210527062707_statusRequest")]
    partial class statusRequest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OvertimeRequest.Models.Account", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NIK");

                    b.ToTable("TB_M_Account");
                });

            modelBuilder.Entity("OvertimeRequest.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TB_M_Department");
                });

            modelBuilder.Entity("OvertimeRequest.Models.Employee", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManagerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PositionId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NIK");

                    b.HasIndex("ManagerId");

                    b.HasIndex("PositionId");

                    b.ToTable("TB_M_Employee");
                });

            modelBuilder.Entity("OvertimeRequest.Models.EmployeeRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmployeeNIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("RequestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeNIK");

                    b.HasIndex("RequestId");

                    b.ToTable("TB_T_EmployeeRequest");
                });

            modelBuilder.Entity("OvertimeRequest.Models.EmployeeRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmployeeNIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeNIK");

                    b.HasIndex("RoleId");

                    b.ToTable("TB_T_EmployeeRole");
                });

            modelBuilder.Entity("OvertimeRequest.Models.Parameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TB_M_Parameter");
                });

            modelBuilder.Entity("OvertimeRequest.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("TB_M_Position");
                });

            modelBuilder.Entity("OvertimeRequest.Models.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndHours")
                        .HasColumnType("datetime2");

                    b.Property<int>("Payroll")
                        .HasColumnType("int");

                    b.Property<int>("Quota")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartHours")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TB_M_Request");
                });

            modelBuilder.Entity("OvertimeRequest.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TB_M_Role");
                });

            modelBuilder.Entity("OvertimeRequest.Models.Account", b =>
                {
                    b.HasOne("OvertimeRequest.Models.Employee", "Employee")
                        .WithOne("Account")
                        .HasForeignKey("OvertimeRequest.Models.Account", "NIK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OvertimeRequest.Models.Employee", b =>
                {
                    b.HasOne("OvertimeRequest.Models.Employee", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");

                    b.HasOne("OvertimeRequest.Models.Position", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OvertimeRequest.Models.EmployeeRequest", b =>
                {
                    b.HasOne("OvertimeRequest.Models.Employee", "Employee")
                        .WithMany("EmployeeRequests")
                        .HasForeignKey("EmployeeNIK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OvertimeRequest.Models.Request", "Request")
                        .WithMany("EmployeeRequests")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OvertimeRequest.Models.EmployeeRole", b =>
                {
                    b.HasOne("OvertimeRequest.Models.Employee", "Employee")
                        .WithMany("EmployeeRoles")
                        .HasForeignKey("EmployeeNIK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OvertimeRequest.Models.Role", "Role")
                        .WithMany("EmployeeRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OvertimeRequest.Models.Position", b =>
                {
                    b.HasOne("OvertimeRequest.Models.Department", "Department")
                        .WithMany("Positions")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
