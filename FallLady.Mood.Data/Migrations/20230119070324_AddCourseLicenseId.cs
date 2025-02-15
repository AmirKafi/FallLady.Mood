﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FallLady.Mood.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseLicenseId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LicenseId",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicenseId",
                table: "Courses");
        }
    }
}
