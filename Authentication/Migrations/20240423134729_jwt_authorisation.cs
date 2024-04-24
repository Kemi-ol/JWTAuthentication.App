using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authentication.Migrations
{
    /// <inheritdoc />
    public partial class jwt_authorisation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NationalIDNumber = table.Column<string>(type: "TEXT", unicode: false, maxLength: 15, nullable: true),
                    EmployeeName = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: true),
                    LoginID = table.Column<string>(type: "TEXT", unicode: false, maxLength: 256, nullable: true),
                    JobTitle = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MaritalStatus = table.Column<string>(type: "TEXT", unicode: false, maxLength: 1, nullable: true),
                    Gender = table.Column<string>(type: "TEXT", unicode: false, maxLength: 1, nullable: true),
                    HireDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    VacationHours = table.Column<short>(type: "INTEGER", nullable: false),
                    SickLeaveHours = table.Column<short>(type: "INTEGER", nullable: false),
                    RowGuid = table.Column<Guid>(type: "TEXT", unicode: false, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DisplayName = table.Column<string>(type: "TEXT", unicode: false, maxLength: 60, nullable: true),
                    UserName = table.Column<string>(type: "TEXT", unicode: false, maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "TEXT", unicode: false, maxLength: 20, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
