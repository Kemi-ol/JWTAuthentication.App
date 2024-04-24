using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Authentication.Migrations
{
    /// <inheritdoc />
    public partial class employeedetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeID", "BirthDate", "EmployeeName", "Gender", "HireDate", "JobTitle", "LoginID", "MaritalStatus", "ModifiedDate", "NationalIDNumber", "RowGuid", "SickLeaveHours", "VacationHours" },
                values: new object[,]
                {
                    { 1, new DateTime(1969, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael Westover", "M", new DateTime(2009, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vice President of Sales", "adventure-works\\ken0", "S", new DateTime(2014, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "295847284", new Guid("f01251e5-96a3-448d-981e-0f99d789110d"), (short)69, (short)99 },
                    { 2, new DateTime(1971, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Raeann Santos", "F", new DateTime(2008, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vice President of Engineering", "adventure-works\\terri0", "S", new DateTime(2014, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "245797967", new Guid("45e8f437-670d-4409-93cb-f9424a40d6ee"), (short)20, (short)1 },
                    { 3, new DateTime(1974, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pamela Wambsgans", "M", new DateTime(2007, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Engineering Manager", "adventure-works\\roberto0", "M", new DateTime(2014, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "509647174", new Guid("9bbbfb2c-efbb-4217-9ab7-f97689328841"), (short)21, (short)2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeID",
                keyValue: 3);
        }
    }
}
