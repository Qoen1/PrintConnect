using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintConnect.Data.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class JobStatusTimestamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Progress",
                table: "Jobs");

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishedAt",
                table: "Jobs",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartedAt",
                table: "Jobs",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinishedAt",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "StartedAt",
                table: "Jobs");

            migrationBuilder.AddColumn<int>(
                name: "Progress",
                table: "Jobs",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
