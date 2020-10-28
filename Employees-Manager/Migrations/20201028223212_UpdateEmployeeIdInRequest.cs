using Microsoft.EntityFrameworkCore.Migrations;

namespace Employees_Manager.Migrations
{
    public partial class UpdateEmployeeIdInRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Employee_EmployeeId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_EmployeeId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Request");

            migrationBuilder.AddColumn<int>(
                name: "Request_Id",
                table: "Employee",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Request_Id",
                table: "Employee",
                column: "Request_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Request_Request_Id",
                table: "Employee",
                column: "Request_Id",
                principalTable: "Request",
                principalColumn: "Request_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Request_Request_Id",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_Request_Id",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Request_Id",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Request",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Request_EmployeeId",
                table: "Request",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Employee_EmployeeId",
                table: "Request",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
