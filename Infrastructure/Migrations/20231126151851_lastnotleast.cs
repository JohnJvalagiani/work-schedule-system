using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class lastnotleast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Jobs_JobId",
                table: "Schedules");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_JobId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Schedules");

            migrationBuilder.AddColumn<int>(
                name: "Job",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Job",
                table: "Schedules");

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "Schedules",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_JobId",
                table: "Schedules",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Jobs_JobId",
                table: "Schedules",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id");
        }
    }
}
