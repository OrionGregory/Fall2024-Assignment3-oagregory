﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassDemo.Migrations
{
    /// <inheritdoc />
    public partial class addedPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Student",
                type: "BLOB",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Student");
        }
    }
}
