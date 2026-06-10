using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintConnect.Data.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class JobSequenceNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SequenceNumber",
                table: "Jobs",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SequenceNumber",
                table: "Jobs");
        }
    }
}
