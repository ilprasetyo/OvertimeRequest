using Microsoft.EntityFrameworkCore.Migrations;

namespace OvertimeRequest.Migrations
{
    public partial class updateEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quota",
                table: "TB_M_Request");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "TB_M_Request",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Quota",
                table: "TB_M_Employee",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quota",
                table: "TB_M_Employee");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "TB_M_Request",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quota",
                table: "TB_M_Request",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
