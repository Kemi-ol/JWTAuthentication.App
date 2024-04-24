using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authentication.Migrations
{
    /// <inheritdoc />
    public partial class userinfodetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "UserId", "CreatedDate", "DisplayName", "Email", "Password", "UserName" },
                values: new object[] { 1, new DateTime(2024, 4, 24, 14, 47, 58, 207, DateTimeKind.Unspecified), "Kemi Mo", "admin@abc.com", "$admin@2022", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}
