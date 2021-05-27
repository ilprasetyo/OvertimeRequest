using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OvertimeRequest.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_M_Department",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Parameter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Parameter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Request",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartHours = table.Column<DateTime>(nullable: false),
                    EndHours = table.Column<DateTime>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Payroll = table.Column<string>(nullable: true),
                    Quota = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Request", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Position",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Position", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Position_TB_M_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "TB_M_Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Employee",
                columns: table => new
                {
                    NIK = table.Column<string>(nullable: false),
                    ManagerId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    PositionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Employee", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_TB_M_Employee_TB_M_Employee_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "TB_M_Employee",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_M_Employee_TB_M_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "TB_M_Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Account",
                columns: table => new
                {
                    NIK = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Account", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_TB_M_Account_TB_M_Employee_NIK",
                        column: x => x.NIK,
                        principalTable: "TB_M_Employee",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_EmployeeRequest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeNIK = table.Column<string>(nullable: true),
                    RequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_EmployeeRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_T_EmployeeRequest_TB_M_Employee_EmployeeNIK",
                        column: x => x.EmployeeNIK,
                        principalTable: "TB_M_Employee",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_T_EmployeeRequest_TB_M_Request_RequestId",
                        column: x => x.RequestId,
                        principalTable: "TB_M_Request",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_EmployeeRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeNIK = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_EmployeeRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_T_EmployeeRole_TB_M_Employee_EmployeeNIK",
                        column: x => x.EmployeeNIK,
                        principalTable: "TB_M_Employee",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_T_EmployeeRole_TB_M_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "TB_M_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Employee_ManagerId",
                table: "TB_M_Employee",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Employee_PositionId",
                table: "TB_M_Employee",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Position_DepartmentId",
                table: "TB_M_Position",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_EmployeeRequest_EmployeeNIK",
                table: "TB_T_EmployeeRequest",
                column: "EmployeeNIK");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_EmployeeRequest_RequestId",
                table: "TB_T_EmployeeRequest",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_EmployeeRole_EmployeeNIK",
                table: "TB_T_EmployeeRole",
                column: "EmployeeNIK");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_EmployeeRole_RoleId",
                table: "TB_T_EmployeeRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_M_Account");

            migrationBuilder.DropTable(
                name: "TB_M_Parameter");

            migrationBuilder.DropTable(
                name: "TB_T_EmployeeRequest");

            migrationBuilder.DropTable(
                name: "TB_T_EmployeeRole");

            migrationBuilder.DropTable(
                name: "TB_M_Request");

            migrationBuilder.DropTable(
                name: "TB_M_Employee");

            migrationBuilder.DropTable(
                name: "TB_M_Role");

            migrationBuilder.DropTable(
                name: "TB_M_Position");

            migrationBuilder.DropTable(
                name: "TB_M_Department");
        }
    }
}
