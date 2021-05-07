using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MalaikaSchool.Migrations
{
    public partial class duration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "SchedulerEvents");

            migrationBuilder.AddColumn<decimal>(
                name: "Duration",
                table: "SchedulerEvents",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "SchedulerEvents");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "SchedulerEvents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
